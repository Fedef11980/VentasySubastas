using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Articulo : IValidable
    {
        private int _id;
        private static int s_ultId = 1;
        public string _nombre { get; set; }
        private string _categoria;
        private decimal _precio;

        public Articulo( string nombre, string categoria, decimal precio)
        {
            _id = s_ultId;
            s_ultId++;
            _nombre = nombre;
            _categoria = categoria;
            _precio = precio;
        }
       
        public string Categoria
        {
            get { return _categoria; }
        }

        public decimal Precio
        {
            get { return _precio; }

        }

        public int Id
        {
            get { return _id; }

        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(_nombre)) throw new ArgumentNullException("El nombre no puede estar vacio");
            if (string.IsNullOrEmpty(_categoria)) throw new ArgumentNullException("la categoria puede estar vacio");   //VALIDACIONES BASICAS.
            if (_precio < 0) throw new ArgumentOutOfRangeException("El precio no puede ser negativo");


        }

        public override string ToString()
        {
            return $"Nombre: {_nombre}, Categoría: {_categoria}, Precio: {_precio}";
        }
    }

}