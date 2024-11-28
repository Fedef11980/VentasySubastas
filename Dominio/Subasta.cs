using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Subasta : Publicacion
    {

        private List<Oferta> _ofertas = new List<Oferta>();
        private decimal _precioFinal;
        private Cliente _cliente;
        private Administrador _usuario;


        public Subasta(string nombre, DateTime fechaPublic, DateTime fechaFinaliz, Cliente cliente, List<Articulo> articulos, Estado estado, decimal precioFinal, Administrador admin, List<Oferta> ofertas)
            : base (nombre, fechaPublic, fechaFinaliz, cliente, articulos, estado)
        {
            _precioFinal = precioFinal;
            _usuario = admin;
            _ofertas = ofertas ?? new List<Oferta>();
        }

        //Getters
        public List<Oferta> Ofertas
        {
            get { return _ofertas; }
        }

        public decimal PrecioFinal
        {
            get { return _precioFinal; }
        }

        public Cliente Cliente
        {
            get { return _cliente; }
        }

        public Administrador Administrador
        {
            get { return _usuario; }
        }

        public override string ToString()
        {
            return $"Subasta: {Nombre}, Precio Final: {_precioFinal}, Ofertas: {Ofertas.Count}";
        }

        public void Validar()
        {
            base.Validar();
        }

        public void AgregarOferta(Oferta oferta) // Hacemos un alta de Oferta por medio del método Contains con Add
        {
            if (oferta == null) throw new Exception("La oferta no puede ser vacia");
            oferta.Validar();

            if (_ofertas.Contains(oferta)) throw new Exception("Ya existe la oferta");            

            if (_ofertas.Count > 0)
            {
                Oferta ofertaActual = _ofertas[_ofertas.Count - 1];
                if (oferta.Monto <= ofertaActual.Monto) throw new Exception ("La nueva oferta debe ser mayor que la oferta actual");
            }
            _ofertas.Add(oferta);
        }

        public override decimal CalcularPrecio()
        {
            if (_ofertas == null || _ofertas.Count == 0) return 0;
            Oferta ultimaOferta = _ofertas [_ofertas.Count - 1];
            return ultimaOferta.Monto;
        }

        public override string TipoDePublicacion()
        {
            return "Subasta";
        }
        
        public override void FinalizarPublicacion(Publicacion p, Usuario usuarioFinal, DateTime fechaFinalizacion)
        {
            // Verificar que la publicación sea una subasta
            Subasta s = p as Subasta;
            if (s == null) throw new Exception("La publicación no es una subasta.");

            // Obtener las ofertas ordenadas
            List<Oferta> ofertasOrdenadas = s.ObtenerOfertas();

            // Buscar un comprador con saldo suficiente
            Cliente comprador = null;
            decimal precioFinal = 0;

            // Iterar sobre las ofertas y encontrar un comprador con saldo suficiente
            int i = 0;
            while (i < ofertasOrdenadas.Count && comprador == null)
            {
                Oferta oferta = ofertasOrdenadas[i];
                Usuario usuarioOferta = oferta.Clientes;
                Cliente cliente = usuarioOferta as Cliente;

                if (cliente != null && cliente.SaldoDisponibleBilletera >= oferta.Monto)
                {
                    comprador = cliente;
                    precioFinal = oferta.Monto;
                }
                i++;
            }

            // Si no se encontró un comprador válido
            if (comprador == null)
            {
                p.Estado = Estado.CANCELADA;
                if (ofertasOrdenadas.Count == 0)
                {
                    throw new Exception("No hay compradores en la subasta.");
                }
                else
                {
                    throw new Exception("No se encontró un comprador válido con saldo suficiente.");
                }
            }

            // Realizar la transacción
            comprador.SaldoDisponibleBilletera -= precioFinal;
            p.Estado = Estado.CERRADA;
            p.UsuarioFinaliza = usuarioFinal;
            p.FechaFinaliz = fechaFinalizacion;
        }
                
        public List<Oferta> ObtenerOfertas()
        {
            List<Oferta> ofertasOrdenadas = new List<Oferta>(_ofertas);                      
            for (int i = 1; i < ofertasOrdenadas.Count; i++) //las ofertas en orden descendente por monto
            {
                Oferta ofertaActual = ofertasOrdenadas[i];
                int j = i - 1;               
                while (j >= 0 && ofertasOrdenadas[j].Monto < ofertaActual.Monto) //quito las ofertas que son menores
                {
                    ofertasOrdenadas[j + 1] = ofertasOrdenadas[j];
                    j--;
                }               
                ofertasOrdenadas[j + 1] = ofertaActual; //oferta actual en su posición ordenada
            }
            return ofertasOrdenadas;
        }

        public Oferta CerrarSubasta(Administrador admin, DateTime fechaFinalizacion) //nuevo método
        {
            if (Estado != Estado.ABIERTA) throw new Exception("La subasta ya está cerrada o no está activa.");
                        
            List<Oferta> ofertasOrdenadas = ObtenerOfertas();

            if (ofertasOrdenadas.Count == 0)
            {
                Estado = Estado.CANCELADA;
                throw new Exception("No hay ofertas en la subasta. Se ha cancelado.");
            }

            // Buscar al cliente ganador con saldo suficiente
            Cliente clienteGanador = null;
            decimal montoFinal = 0;
            foreach (Oferta o in ofertasOrdenadas)
            {
                Cliente cliente = o.Clientes as Cliente;
                if (cliente != null)
                {
                    if (cliente.SaldoDisponibleBilletera >= o.Monto)
                    {
                        clienteGanador = cliente;
                        montoFinal = o.Monto;
                        break;
                    }
                }
            }

            if (clienteGanador == null)
            {
                Estado = Estado.CANCELADA;
                throw new Exception("No se encontró un cliente válido con saldo suficiente.");
            }
            
            clienteGanador.SaldoDisponibleBilletera -= montoFinal;
            _cliente = clienteGanador;
            _precioFinal = montoFinal;
                        
            Estado = Estado.CERRADA; //pasa a estado cerrada
            _usuario = admin;
            FechaFinaliz = fechaFinalizacion;

            foreach (Oferta o in ofertasOrdenadas)
            {
                if (o.Clientes == clienteGanador) return o; // Retornar la oferta que corresponde al cliente ganador                
            }
            return null;
        }
    }
}
