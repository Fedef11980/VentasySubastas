﻿using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dominio
{
    public class Articulo : IValidable
    {
        private int _id;
        private static int ultId = 1;
        private string _nombre;
        private string _categoria;
        private double _precio;

        public Articulo( string nombre, string categoria, double precio)
        {
            _nombre = nombre;
            _categoria = categoria;
            _precio = precio;
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(_nombre)) throw new Exception("El nombre no puede estar vacio");
            if (string.IsNullOrEmpty(_categoria)) throw new Exception("la categoria puede estar vacio");   //VALIDACIONES BASICAS.
            if (_precio < 0) throw new Exception("El precio no puede ser negativo");
        }

        public override string ToString()
        {
            return $"Categoría: {_categoria} - Nombre: {_nombre} - Precio: ${_precio}";
        }

        //Getters
        public string Categoria
        {
            get { return _categoria; }

        }

        public string Nombre
        {
            get { return _nombre; }
        }

        public int Id
        {
            get { return _id; }
        }


        public override bool Equals(object obj)
        {
            Articulo articulos = obj as Articulo;
            return articulos != null && this._id == articulos._id;
        }

    }

}