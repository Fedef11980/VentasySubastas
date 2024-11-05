using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract class Publicacion : IValidable
    {
        protected int _id;
        protected static int ultId = 1;
        protected string _nombre;
        protected DateTime _fechaPublic;
        protected DateTime _fechaFinaliz;
        protected Usuario _cliente;
        protected List<Articulo> _articulos = new List<Articulo>();
        protected Estado _estado;

        public Publicacion (string nombre, DateTime fechaPublic, DateTime fechaFinaliz, Estado estado)
        {
            _id = ultId++;
            _nombre = nombre;
            _fechaPublic = fechaPublic;
            _fechaFinaliz = fechaFinaliz;
            _estado = estado;
        }

        public int Id
        { 
            get { return _id; } 
        } 
        
        public string Estado
        {
            get { return _estado.ToString(); }
        }

        public string Nombre
        {
            get { return _nombre; }
        }

        public List<Articulo> Articulos
        { 
            get { return _articulos; } 
        }

        public DateTime FechaPublic
        {
            get { return _fechaPublic; }
        }

        public DateTime FechaFinaliz
        {
            get { return _fechaFinaliz; }
        }
        
        public virtual void Validar()
        {
            if (string.IsNullOrEmpty(_nombre)) throw new Exception("El nombre no puede ser vacio");
            if (_fechaFinaliz <= _fechaPublic) throw new Exception ("La fecha de finalización debe ser posterior a la fecha de publicación."); //VALIDACIONES BASICAS.
            if (_cliente == null) throw new Exception("El cliente no puede ser nulo.");    //FALTA INCREMENTAR ID
        }
        
        public override string ToString()
        {
            return $"Publicación: {_nombre}, Estado: {_estado}, Artículos: {Articulos.Count}";
        }

        public override bool Equals (object obj)
        {
            Publicacion publicacion = obj as Publicacion;
            return publicacion != null && this._id == publicacion._id;
        }


        // Método para agregar artículos a la publicación
        public void AgregarArticulo(Articulo articulo)
        {
            if (!_articulos.Contains(articulo))
            {
                 _articulos.Add(articulo);
            } 
            else
            {
                 throw new Exception("El artículo ya está asociado a esta publicación");
            }
        }
        

    }
}

