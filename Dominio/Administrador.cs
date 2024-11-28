using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Administrador : Usuario, IValidable
    {

        public Administrador(string nombre, string apellido, string email, string contrasena)
            : base(nombre, apellido, email, contrasena)
        {
           
        }

        public override string ToString()
        {
            return $"{Nombre}"; // CORREGIR
        }
       
        public override void Validar()
        {
            base.Validar();
        }
        
        public override string Rol()
        {
            return "Admin";
        }
    }
}

