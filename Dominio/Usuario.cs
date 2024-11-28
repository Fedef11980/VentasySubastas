using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract class Usuario : IValidable
    {
        private int id;
        private static int s_ultId = 1;
        private string _nombre;
        private string _apellido;
        private string _email;
        private string _contrasena;
        

        protected Usuario( string nombre, string apellido, string email, string contrasena)
        {
            id = s_ultId;
            s_ultId++;
            _nombre = nombre;
            _apellido = apellido;
            _email = email;
            _contrasena = contrasena;
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Contrasena
        {
            get { return _contrasena; }
            set { _contrasena = value; }
        }

        public int Id
        { 
            get { return id; } 
        }  
        
        public virtual void Validar()
        {
            if (string.IsNullOrEmpty(_nombre)) throw new ArgumentNullException("El nombre no puede ser vacio");
            if (string.IsNullOrEmpty(_apellido)) throw new ArgumentNullException("El apellido no puede ser vacio");
            if (string.IsNullOrEmpty(Contrasena)) throw new Exception("La contraseña no puede estar vacia");

            if (string.IsNullOrEmpty(_email)) throw new ArgumentNullException("El emial no puede ser vacio");
        }

        public abstract string Rol();
    }
}
