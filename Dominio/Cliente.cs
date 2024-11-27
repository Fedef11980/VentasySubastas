using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Cliente : Usuario, IValidable
    {
        private decimal _saldoDispBill;        

        public Cliente(string nombre, string apellido, string email, string contrasenia, decimal saldoDispBill):
            base(nombre, apellido, email, contrasenia)
        {
            _saldoDispBill = saldoDispBill;            
        }

        // Constructor sin saldo (inicializa el saldo en 0)
        public Cliente (string nombre, string apellido, string email, string contrasena)
            : base(nombre, apellido, email, contrasena)
        {
            _saldoDispBill = 0;
        }

        //Getter
        public decimal SaldoDisponibleBilletera
        {
            get {  return _saldoDispBill; }            
        }

        public void AgregarSaldo (decimal nuevoSaldo)
        {
            if (nuevoSaldo < 0) throw new Exception("El saldo tiene que ser mayor que cero");
            _saldoDispBill += nuevoSaldo;
        }

        public override void Validar()
        {           
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
        
        public override string Rol()
        {
            return "Cliente";
        }

    }
}
