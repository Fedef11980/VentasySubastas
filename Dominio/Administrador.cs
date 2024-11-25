using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Administrador : Usuario, IValidable
    {
        public Administrador(string nombre, string apellido, string email, string contrasenia)
            : base(nombre, apellido, email, contrasenia) 
        {
            
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
