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
        public decimal _saldo { get; set; }

        // Constructor que llama al constructor de la clase base (Usuario)
        public Cliente(string nombre, string apellido, string email, string contrasena, decimal saldo)
         : base(nombre, apellido, email, contrasena)
        {
            _saldo = saldo;
        }

        // Constructor sin saldo (inicializa el saldo en 0)
        public Cliente(string nombre, string apellido, string email, string contrasena)
            : base(nombre, apellido, email, contrasena)
        {
            _saldo = 0;
        }

        public void AgregarSaldo(decimal nuevoSaldo)
        {
            if (nuevoSaldo < 0) throw new Exception("El saldo tiene que ser mayor que cero");
            _saldo += nuevoSaldo;
        }

        public decimal Saldo 
        { 
            get { return _saldo; } 
            set { _saldo = value; } 
        }

        public override string ToString()
       {
            return $"{Nombre}, Saldo: {_saldo}";
        }

        public override void Validar()
        {
            base.Validar();

        }

        public override string Rol()
        {
            return "Cliente";
        }
    }
}

