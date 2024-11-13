using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Oferta : IValidable
    {
        private int _id;
        private static int s_ultId = 1;
        private Cliente _cliente;            
        private double _monto;
        private DateTime _fechaOferta;

        public Oferta (Cliente cliente , double monto, DateTime fechaOferta)
        {
            _id = s_ultId;
            s_ultId++;
            _cliente = cliente;
            _monto = monto;
            _fechaOferta = fechaOferta;
        }

        public void Validar()
        {
            if (object.Equals(_cliente, null))
            if (_monto < 0) throw new Exception("El monto debe ser mayor a cero");    
        }


        public override bool Equals(object? obj) // equals de oferta para dar de alta una oferta en subasta
        {
            Oferta of = obj as Oferta;
            return of != null && of._cliente.Equals(_cliente);
        }

        public double Monto
        {
            get { return _monto; }
        }

        public int Id
        {
            get { return _id; }
        }
    }

   
}
