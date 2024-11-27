using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Subasta : Publicacion
    {

        private List<Oferta> _ofertas = new List<Oferta>();
        

        public Subasta ( string nombre, DateTime fechaPublic, DateTime fechaFinaliz, Estado estado):
             base(nombre,fechaPublic, fechaFinaliz,estado)
        {
           
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

        public override double CalcularPrecio()
        {
            if (_ofertas == null || _ofertas.Count == 0) return 0;
            Oferta ultimaOferta = _ofertas [_ofertas.Count - 1];
            return ultimaOferta.Monto;
        }

        public override string TipoDePublicacion()
        {
            return "Subasta";
        }






        // Todo lo referido a ofertas lo maneja subasta
        //Sistema tendra que buscar subasta y cliente. Con el cliente, el monto y la fecha te creas una Oferta. Esa oferta se la pasas al metodo AgregarOferta de la subasta que buscaste
        //EL equals y el metodo agrtegar oferta me parece que está bien
        //En agregar oferta deberias mover el add a la ultima linea, agregas la oferta a la subasta solo cuando se verificaron todas las demas cosas





        // que el cliente no se repita
        // agregar a la lista

    }
}
