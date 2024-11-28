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
        private decimal _monto;
        private DateTime _fechaOferta;

        public Oferta (Cliente cliente , decimal monto, DateTime fechaOferta)
        {
            _id = s_ultId;
            s_ultId++;
            _cliente = cliente;
            _monto = monto;
            _fechaOferta = fechaOferta;
        }

        //Getters
        public decimal Monto
        {
            get { return _monto; }
        }

        public int Id
        {
            get { return _id; }
        }

        public Cliente Clientes
        {
            get { return _cliente; }
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
    }   
}
