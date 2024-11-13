using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Cliente : Usuario
    {
        private decimal _saldoDispBill;        

        public Cliente(string nombre, string apellido, string email, string contrasenia, decimal saldoDispBill) :
            base(nombre, apellido, email, contrasenia)
        {
            _saldoDispBill = saldoDispBill;            
        }

        public override void Validar()
        {
            if (_saldoDispBill <= 0) throw new Exception("El saldo no puede ser negativo o menor que cero");
            base.Validar();
        }

        public override string ToString()
        {
            return base.ToString() + $"Saldo: ${_saldoDispBill}"; 
        }

        public override bool Equals(object? obj)
        {
            Cliente cl = obj as Cliente;
            return cl != null && this._id == cl._id;
        }



    }
}
