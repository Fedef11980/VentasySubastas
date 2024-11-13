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
        private static int ultId = 1;
        private Usuario _admin;
        private double _monto;
        private DateTime _fechaOferta;

        public Oferta (Usuario admin, double monto, DateTime fechaOferta)
        {
            _admin = admin;
            _monto = monto;
            _fechaOferta = fechaOferta;
        }

        public void Validar()
        {
            if (object.Equals(_admin, null));
            if (_monto < 0) throw new Exception("El monto debe ser mayor a 0");    //VALIDACIONES BASICAS.
        }
    }
}
