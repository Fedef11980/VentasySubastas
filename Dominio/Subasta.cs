using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Subasta : Publicacion, IComparable<Subasta>
    {
        // Atributos específicos de la clase Subasta
        private List<Oferta> _ofertas;  // Lista de ofertas realizadas por clientes
        private decimal _precioFinal;
        private Cliente _cliente;
        private Administrador _usuario;

        //Propiedades solo de lectura para acceder a los atributos
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

        // Constructor de la clase Subasta
        public Subasta(string nombre, DateTime fechaPublicacion, DateTime fechaFinalizacion, Cliente cliente, List<Articulo> articulos, Estado estado, decimal precioFinal, Administrador admin, List<Oferta> ofertas)
       : base(nombre, fechaPublicacion, fechaFinalizacion, cliente, articulos, estado)
        {
            _precioFinal = precioFinal;
            _usuario = admin;
            _ofertas = ofertas ?? new List<Oferta>();  
        }

  

        public void AgregarOferta(Oferta nuevaOferta) 
        {
            if (nuevaOferta == null) throw new Exception("La oferta no puede ser nula");
            nuevaOferta.Validar();

            bool existeCliente = false;
            foreach (var ofe in _ofertas)
            {
                if (ofe.TieneCliente(nuevaOferta.Cliente))
                {
                    existeCliente = true;
                }
                break;
            }
            if (!existeCliente)

            // Verificar si hay ofertas previas
            if (_ofertas.Count > 0) // Si hay al menos una oferta
            {
                // Tomar la última oferta (la más alta debería ser la última agregada)
                Oferta ofertaActual = _ofertas[_ofertas.Count - 1]; // Última oferta en la lista

                // Comparar el monto de la nueva oferta con la última oferta
                if (nuevaOferta.Monto <= ofertaActual.Monto)
                {
                    throw new Exception("La nueva oferta debe ser mayor que la oferta actual.");
                }
            }
            

            // Si la nueva oferta es válida, agregarla a la lista
            _ofertas.Add(nuevaOferta);
            _precioFinal = nuevaOferta.Monto;

        }


        //oferta mayor y cliente que no haya otra oferta

        // Método ToString para faciilitar la visualización
        public override string ToString()
        {
            return $"Subasta: {Nombre}, Precio Final: {_precioFinal}, Ofertas: {Ofertas.Count}";
        }
        public override void Validar()
        {
            base.Validar();
        }

        public override decimal CalcularPrecio()
        {
            if (_ofertas == null || _ofertas.Count == 0) return 0;
            Oferta ultimaOferta = _ofertas[_ofertas.Count - 1];
            return ultimaOferta.Monto;
        }

        public override string TipoDePublicacion()
        {
            return "Subasta";
        }

     

        public decimal Precio { get; set; } 

        public int CompareTo(Subasta other)
        {
            if (other == null) return 1;

            // Ordenar de mayor a menor precio
            return other.FechaPublic.CompareTo(this.FechaPublic);
        }
        public List<Oferta> ObtenerOfertas()
        {
            // Crear una nueva lista para no modificar la lista original
            List<Oferta> ofertasOrdenadas = new List<Oferta>(_ofertas);

            // Insertion Sort: ordenar las ofertas en orden descendente por monto
            for (int i = 1; i < ofertasOrdenadas.Count; i++)
            {
                Oferta ofertaActual = ofertasOrdenadas[i];
                int j = i - 1;

                // Desplazar las ofertas que son menores que la oferta actual
                while (j >= 0 && ofertasOrdenadas[j].Monto < ofertaActual.Monto)
                {
                    ofertasOrdenadas[j + 1] = ofertasOrdenadas[j];
                    j--;
                }

                // Insertar la oferta actual en su posición ordenada
                ofertasOrdenadas[j + 1] = ofertaActual;
            }

            return ofertasOrdenadas;
        }


        public override void FinalizarPublicacion(Publicacion p, Usuario usuarioFinal, DateTime fechaFinalizacion)
        {
            // Verificar que la publicación sea una subasta
            Subasta s = p as Subasta;
            if (s == null)
            {
                throw new Exception("La publicación no es una subasta.");
            }

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
                Usuario usuarioOferta = oferta.Cliente;
                Cliente cliente = usuarioOferta as Cliente;

                if (cliente != null && cliente.Saldo >= oferta.Monto)
                {
                    comprador = cliente;
                    precioFinal = oferta.Monto;
                }
                else
                {
                    throw new Exception("Saldo insuficente ");
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
                    throw new Exception("No se encontró un comprador con saldo suficiente.");
                }

               
                {
                    throw new Exception("Saldo insuficiente para realizar la compra");
                }
            }

            // Realizar la transacción
            comprador.Saldo -= precioFinal;
            p.Estado = Estado.CERRADA;
            p.UsuarioFinaliza = usuarioFinal;
            p.FechaFinaliz = fechaFinalizacion;
        }


    }
}



