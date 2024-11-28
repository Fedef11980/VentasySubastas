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
        private int _id;
        private static int s_ultId = 1;
        private string _nombre;
        private DateTime _fechaPublic;
        private DateTime _fechaFinaliz;
        private Usuario _usuarioFinaliza;
        private Cliente _usuarioComprador;
        private List<Articulo> _articulos = new List<Articulo>();
        private Estado _estado;

        public Publicacion( string name, DateTime fechaPublic, DateTime fechaFinaliz, Cliente cliente, List<Articulo> articulos, Estado estado)
        {
            _nombre = name;
            _id = s_ultId;
            s_ultId++;
            _fechaPublic = fechaPublic;
            _fechaFinaliz = fechaFinaliz;
            _usuarioFinaliza = cliente;
            _articulos = articulos;
            _estado = estado;
        }


        public Estado Estado 
        { 
            get { return _estado; } 
            set { _estado = value; } 
        }

        public int Id
        { 
            get { return _id; } 
        }

        public Usuario UsuarioFinaliza 
        { 
            get { return _usuarioFinaliza; } 
            set { _usuarioFinaliza = value; } 
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
            set { _fechaFinaliz = value; } 
        }

        public virtual void Validar()
        {
            if (string.IsNullOrEmpty(_nombre)) throw new ArgumentNullException("El nombre no puede ser vacio");

            if (_fechaFinaliz <= _fechaPublic) throw new Exception ("La fecha de finalización debe ser posterior a la fecha de publicación."); //VALIDACIONES BASICAS.
        }

        public override string ToString()
        {
            return $"Publicación: Id: {_id}Nombre: {_nombre},  Estado: {_estado}, Artículos: {Articulos.Count} Precio: {CalcularPrecio}";
        }

        public void AgregarOferta(Oferta oferta)
        {

        }
               
        public void AgregarArticulo(Articulo articulo)
        {           
            //validarr
            _articulos.Add(articulo);
        }

        public abstract string TipoDePublicacion();

        public abstract decimal CalcularPrecio();

        public abstract void FinalizarPublicacion(Publicacion p, Usuario usuarioFinal, DateTime fechaFinalizacion);



    }
}

