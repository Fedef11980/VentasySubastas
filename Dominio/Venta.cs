using Dominio.Interfaces;
using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Venta : Publicacion, IValidable
    {
        private bool _ofertaRelampago;
        //private decimal _precioFinal;
        private Usuario _comprador;

        // Atributos específicos de la clase Venta
        public bool OfertaRelampago
        {
            get { return _ofertaRelampago; }
        }

        //public decimal PrecioFinal
        //{
        //    get { return _precioFinal; }
        //    set { _precioFinal = value; }
        //}

        public Venta(string nombre, DateTime fechaPublicacion, DateTime fechaFinalizacion, Cliente cliente, List<Articulo> articulos, Estado estado, bool ofertaRelampago)
            : base(nombre, fechaPublicacion, fechaFinalizacion, cliente, articulos, estado) // Llama al constructor de Publicacion
        {
            _ofertaRelampago = ofertaRelampago;
            //_precioFinal = precioFinal;
        }

        public override void Validar()
        {
            base.Validar();
        }



        public override decimal CalcularPrecio()
        {
            decimal precioFinal = 0;

            foreach (Articulo articulo in Articulos)
            {
                precioFinal += articulo.Precio;
            }

            // Aplicar el 20% de descuento si es ofertrelampago
            if (OfertaRelampago)
            {
                precioFinal *= 0.8m; // Multiplica por 0.8 para aplicar el descuento
            }



            return precioFinal;
        }



        // Método ToString para facilitar la visualización
        public override string ToString()
        {
            return $"Venta: {Nombre}, Precio Final, Oferta Relámpago: {_ofertaRelampago}";
        }

        public override string TipoDePublicacion()
        {
            return "Venta";
        }

        public override void FinalizarPublicacion(Publicacion p, Usuario usuarioFinal, DateTime fechaFinalizacion)


        {
            if(p.Estado != Estado.ABIERTA)
            {
                throw new Exception("L publicacion esta cerrada");

            }

            decimal precio = p.CalcularPrecio();

            Cliente cliente  = usuarioFinal as Cliente;

            if (cliente == null)
            {
                throw new Exception ("El usuario no existe en el sistema");
            }

            if (cliente.Saldo < precio)
            {
                throw new Exception("Saldo insuficiente para realziar la compra");
            }

            cliente.Saldo -= precio;
            p.Estado = Estado.CERRADA;
            p.UsuarioFinaliza = usuarioFinal;
            p.FechaFinaliz = DateTime.Now;
        }
    }
        

    }
 
