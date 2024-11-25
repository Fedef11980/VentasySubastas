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
        protected static int s_ultId = 1;
        protected string _nombre;
        protected DateTime _fechaPublic;
        protected DateTime _fechaFinaliz;
        protected List<Articulo> _articulos = new List<Articulo>();
        protected Estado _estado;

        public Publicacion (string nombre, DateTime fechaPublic, DateTime fechaFinaliz, Estado estado)
        {
            _id = s_ultId;
            s_ultId++;
            _nombre = nombre;
            _fechaPublic = fechaPublic;
            _fechaFinaliz = fechaFinaliz;            
            _estado = estado;
        }

        public int Id
        {
            get { return _id; }
        }

        public string Nombre
        {
            get { return _nombre; }
        }

        public DateTime FechaPublic
        {
            get { return _fechaPublic; }
        }

        public DateTime FechaFinaliz
        {
            get { return _fechaFinaliz; }
        }

        public string Estado
        {
            get { return _estado.ToString(); }
        }       

        public List<Articulo> Articulos
        { 
            get { return _articulos; } 
        }
        
        public virtual void Validar()
        {
            if (string.IsNullOrEmpty(_nombre)) throw new Exception("El nombre no puede ser vacio");
            if (_fechaFinaliz <= _fechaPublic) throw new Exception ("La fecha de finalización debe ser posterior a la fecha de publicación."); 
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
            if (articulo == null) throw new Exception("El articulo no puede ser vacío");   
            if (!_articulos.Contains(articulo))
            {
                 _articulos.Add(articulo);
            } 
            else
            {
                 throw new Exception("El artículo ya está asociado a esta publicación");
            }
        }
                
        public abstract string TipoDePublicacion();
        
        public abstract double CalcularPrecio();

      


    }
}

