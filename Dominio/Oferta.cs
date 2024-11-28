using Dominio.Interfaces;
using System;

namespace Dominio
{
    public class Oferta : IValidable, IComparable<Oferta>
    {
        private int _id;
        private static int s_ultId = 1;

        private Cliente _cliente;
        private decimal _monto;
        private DateTime _fechaOferta;

        public Oferta(Cliente cliente, decimal monto, DateTime fechaOferta)
        {
            _id = s_ultId;
            s_ultId++;
            _cliente = cliente;
            _monto = monto;
            _fechaOferta = fechaOferta;
        }

        public int Id
        {
            get { return _id; }
        }

        public Cliente Cliente
        {
            get { return _cliente; }
        }

        public decimal Monto
        {
            get { return _monto; }
        }

        public bool TieneCliente(Cliente cli)
        {
            return _cliente.Equals(cli);
        }

        public void Validar()
        {
            if (_cliente == null)
                throw new Exception("El cliente no puede ser nulo.");
            if (_monto < 0)
                throw new Exception("El monto debe ser mayor a 0.");
        }
        public string TipoPublicacion()
        {
            return "Oferta";
        }
        public int CompareTo(Oferta other)
        {
            if (other == null) return 1;

            // Ordenar por monto descendente
            return other.Monto.CompareTo(this.Monto);
        }
    }
}
