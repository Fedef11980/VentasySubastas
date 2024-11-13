using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dominio
{
    public abstract class Usuario : IValidable
    {
        protected int id;
        protected static int s_ultId = 1;
        protected string _nombre;
        protected string _apellido;
        protected string _email;
        protected string _contrasena;
       

        public Usuario( string nombre, string apellido, string email, string contrasena)
        {
            _nombre = nombre;
            _apellido = apellido;
            _email = email;
            _contrasena = contrasena;            
        }

        public virtual void Validar()
        {
            if (string.IsNullOrEmpty(_nombre)) throw new Exception("El nombre no puede ser vacio");
            if (string.IsNullOrEmpty(_apellido)) throw new Exception("El nombre no puede ser vacio");
            if (string.IsNullOrEmpty(_contrasena)) throw new Exception("La contraseña  no puede ser vacio");       //VALIDACIONES BASICAS.
            if (string.IsNullOrEmpty(_email)) throw new Exception("El emial no puede ser vacio");            
        }

        public override string ToString()
        {
            return $"Nombre:{_nombre} - Apellido:{_apellido} y E-mail: {_email}";
        }
    }
}
