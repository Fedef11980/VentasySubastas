using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Interfaces;

namespace Dominio
{
    public class Venta : Publicacion, IValidable
    {
        private bool _ofertaRelampago = false;

        public Venta(string nombre, DateTime fechaPublicacion, DateTime fechaFinalizacion, Cliente cliente, List<Articulo> articulos, Estado estado, bool ofertaRelampago)
            : base(nombre, fechaPublicacion, fechaFinalizacion, cliente, articulos, estado) // Llama al constructor de Publicacion
        {
            _ofertaRelampago = ofertaRelampago;
            //_precioFinal = precioFinal;
        }

        public bool OfertaRelampago
        {
            get { return _ofertaRelampago; }
        }

        public override decimal CalcularPrecio()
        {
            decimal precioFinal = 0;
            foreach (Articulo a in _articulos )
            {
                 precioFinal += a.Precio; 
            }
            if (OfertaRelampago)
            { 
                precioFinal *= 0.8m; 
            }
            return precioFinal;
        }

        public override string TipoDePublicacion()
        {
            return "Venta";
        }

        public override void FinalizarPublicacion(Publicacion p, Usuario usuarioFinal, DateTime fechaFinalizacion)
        {
            if (p.Estado != Estado.ABIERTA) throw new Exception("L publicacion esta cerrada");
            decimal precio = p.CalcularPrecio();
            Cliente cliente = usuarioFinal as Cliente;

            if (cliente == null) throw new Exception("El usuario no existe en el sistema");
            if (cliente.SaldoDisponibleBilletera < precio) throw new Exception("Saldo insuficiente para realziar la compra");

            cliente.SaldoDisponibleBilletera -= precio;
            p.Estado = Estado.CERRADA;
            p.UsuarioFinaliza = usuarioFinal;
            p.FechaFinaliz = DateTime.Now;
        }
    }
}

