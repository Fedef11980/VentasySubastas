﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Sistema
    {
        private List<Articulo> _articulos = new List<Articulo>();
        private List<Usuario> _usuarios = new List<Usuario>();
        private List<Publicacion> _publicaciones = new List<Publicacion>();

        public Sistema() 
        {
            PrecargarArticulos();
            PrecargarPublicaciones();
            PrecargarUsuarios();
            PreCargarOfertas();
        }

        public Articulo ObtenerCategoria(string categoria) // buscar articulos
        {
            Articulo buscada = null;
            int i = 0;
            while (i < _articulos.Count && buscada == null)
            {
                if (_articulos[i].Categoria.ToUpper() == categoria.ToUpper())
                buscada = _articulos[i];
                i++;
            }
            return buscada;
        }

        private void PrecargarArticulos()
        {
            AltaArticulo(new Articulo("Pelota futbol", "deporte", 100));
            AltaArticulo(new Articulo("Pelota volleyball", "Deporte", 100));
            AltaArticulo(new Articulo("Raqueta de tenis", "Deporte", 150));
            AltaArticulo(new Articulo("Bicicleta", "Deporte", 300));
            AltaArticulo(new Articulo("Pesas 10kg", "Deporte", 80));
            AltaArticulo(new Articulo("Balón de básquet", "Deporte", 120));
            AltaArticulo(new Articulo("Teléfono móvil", "Tecnología", 500));
            AltaArticulo(new Articulo("Laptop", "Tecnología", 1000));
            AltaArticulo(new Articulo("Tablet", "Tecnología", 300));
            AltaArticulo(new Articulo("Auriculares inalámbricos", "Tecnología", 200));
            AltaArticulo(new Articulo("Monitor 24 pulgadas", "Tecnología", 250));
            AltaArticulo(new Articulo("Sofá", "Hogar", 700));
            AltaArticulo(new Articulo("Mesa de comedor", "Hogar", 400));
            AltaArticulo(new Articulo("Lámpara de pie", "Hogar", 100));
            AltaArticulo(new Articulo("Refrigerador", "Hogar", 1200));
            AltaArticulo(new Articulo("Microondas", "Hogar", 150));
            AltaArticulo(new Articulo("Muñeca", "Juguetería", 30));
            AltaArticulo(new Articulo("Coche de juguete", "Juguetería", 40));
            AltaArticulo(new Articulo("Rompecabezas 1000 piezas", "Juguetería", 25));
            AltaArticulo(new Articulo("Videojuego", "Juguetería", 60));
            AltaArticulo(new Articulo("Juguete de construcción", "Juguetería", 90));
            AltaArticulo(new Articulo("Reloj inteligente", "Tecnología", 300));
            AltaArticulo(new Articulo("Cámara fotográfica", "Tecnología", 700));
            AltaArticulo(new Articulo("Teclado mecánico", "Tecnología", 120));
            AltaArticulo(new Articulo("Mouse inalámbrico", "Tecnología", 80));
            AltaArticulo(new Articulo("Impresora", "Tecnología", 200));
            AltaArticulo(new Articulo("Cama", "Hogar", 500));
            AltaArticulo(new Articulo("Silla de oficina", "Hogar", 150));
            AltaArticulo(new Articulo("Aspiradora", "Hogar", 180));
            AltaArticulo(new Articulo("Cafetera", "Hogar", 90));
            AltaArticulo(new Articulo("Tostadora", "Hogar", 50));
            AltaArticulo(new Articulo("Patineta", "Deporte", 100));
            AltaArticulo(new Articulo("Casco de bicicleta", "Deporte", 50));
            AltaArticulo(new Articulo("Zapatillas deportivas", "Deporte", 120));
            AltaArticulo(new Articulo("Cinta para correr", "Deporte", 800));
            AltaArticulo(new Articulo("Guantes de boxeo", "Deporte", 60));
            AltaArticulo(new Articulo("Drone", "Tecnología", 500));
            AltaArticulo(new Articulo("Consola de videojuegos", "Tecnología", 600));
            AltaArticulo(new Articulo("Smart TV", "Tecnología", 900));
            AltaArticulo(new Articulo("Cargador portátil", "Tecnología", 40));
            AltaArticulo(new Articulo("Router WiFi", "Tecnología", 120));
            AltaArticulo(new Articulo("Silla de comedor", "Hogar", 100));
            AltaArticulo(new Articulo("Ventilador", "Hogar", 60));
            AltaArticulo(new Articulo("Estufa", "Hogar", 200));
            AltaArticulo(new Articulo("Planchita de ropa", "Hogar", 70));
            AltaArticulo(new Articulo("Cortinas", "Hogar", 40));
            AltaArticulo(new Articulo("Juego de mesa", "Juguetería", 50));
            AltaArticulo(new Articulo("Pelota de playa", "Juguetería", 15));
            AltaArticulo(new Articulo("Peluche", "Juguetería", 25));
            AltaArticulo(new Articulo("Lego", "Juguetería", 100));            
        }
        
        private void PrecargarPublicaciones()
        {   //Subastas
            AltaPublicacion(new Subasta("Vacaciones en la Playa", new DateTime(2023, 05, 11), new DateTime(2023, 06, 11), Estado.ABIERTA)); 
            AltaPublicacion(new Subasta("Paseo en Bicicleta", new DateTime(2023, 05, 11), new DateTime(2023, 06, 11), Estado.ABIERTA));
            AltaPublicacion(new Subasta("Juego de Tenis", new DateTime(2023, 02, 20), new DateTime(2023, 03, 20), Estado.ABIERTA));
            AltaPublicacion(new Subasta("Set de Tecnología", new DateTime(2023, 04, 01), new DateTime(2023, 05, 01), Estado.ABIERTA));
            AltaPublicacion(new Subasta("Muebles de Hogar", new DateTime(2023, 06, 15), new DateTime(2023, 07, 15), Estado.ABIERTA));
            AltaPublicacion(new Subasta("Juguetería Premium", new DateTime(2023, 07, 01), new DateTime(2023, 08, 01), Estado.ABIERTA));
            AltaPublicacion(new Subasta("Subasta de Deportes", new DateTime(2023, 03, 10), new DateTime(2023, 04, 10), Estado.ABIERTA));
            AltaPublicacion(new Subasta("Tecnología de Vanguardia", new DateTime(2023, 08, 01), new DateTime(2023, 09, 01), Estado.ABIERTA));
            AltaPublicacion(new Subasta("Accesorios de Oficina", new DateTime(2023, 09, 15), new DateTime(2023, 10, 15), Estado.ABIERTA));
            AltaPublicacion(new Subasta("Hogar y Confort", new DateTime(2023, 11, 01), new DateTime(2023, 12, 01), Estado.ABIERTA));
            //Ventas
            AltaPublicacion(new Venta("Jugando al Fútbol", new DateTime(2023, 01, 10), new DateTime(2023, 02, 10), Estado.ABIERTA, false));
            AltaPublicacion(new Venta("Salir a Pasear en Bicicleta", new DateTime(2023, 03, 15), new DateTime(2023, 04, 15), Estado.ABIERTA, true));  // Oferta relámpago
            AltaPublicacion(new Venta("Mirar la Compu", new DateTime(2023, 05, 01), new DateTime(2023, 06, 01), Estado.ABIERTA, true));  // Oferta relámpago
            AltaPublicacion(new Venta("Momento relax", new DateTime(2023, 07, 01), new DateTime(2023, 08, 01), Estado.ABIERTA, false));
            AltaPublicacion(new Venta("Reloj Inteligente", new DateTime(2023, 08, 10), new DateTime(2023, 09, 10), Estado.ABIERTA, false));
            AltaPublicacion(new Venta("Hablando por celular", new DateTime(2023, 09, 15), new DateTime(2023, 10, 15), Estado.ABIERTA, true));  // Oferta relámpago
            AltaPublicacion(new Venta("Jugando con la Tablet", new DateTime(2023, 10, 01), new DateTime(2023, 11, 01), Estado.ABIERTA, false));
            AltaPublicacion(new Venta("Cámara Fotográfica", new DateTime(2023, 11, 05), new DateTime(2023, 12, 05), Estado.ABIERTA, true));  // Oferta relámpago
            AltaPublicacion(new Venta("Silla de Oficina", new DateTime(2023, 12, 01), new DateTime(2024, 01, 01), Estado.ABIERTA, false));
            AltaPublicacion(new Venta("Zapatillas Deportivas", new DateTime(2023, 10, 10), new DateTime(2023, 11, 10), Estado.ABIERTA, true));  // Oferta relámpago
        }

        private void PrecargarArticulosPublicaciones()
        {
            // Precarga de Subastas            
            AsignarArticuloAPublicacion(1, 1);  // Pelota fútbol
            AsignarArticuloAPublicacion(1, 4);  // Bicicleta
            AsignarArticuloAPublicacion(1, 33); // Casco de bicicleta        
            AsignarArticuloAPublicacion(2, 34); // Zapatillas deportivas
            AsignarArticuloAPublicacion(2, 5);  // Pesas 10kg
            AsignarArticuloAPublicacion(2, 7);  // Teléfono móvil
            AsignarArticuloAPublicacion(3, 9);  // Tablet
            AsignarArticuloAPublicacion(3, 10); // Auriculares inalámbricos
            AsignarArticuloAPublicacion(3, 11); // Monitor 24 pulgadas
            AsignarArticuloAPublicacion(4, 2);  // Pelota fútbol
            AsignarArticuloAPublicacion(4, 3);  // Raqueta de tenis
            AsignarArticuloAPublicacion(5, 23); // Cámara fotográfica
            AsignarArticuloAPublicacion(5, 24); // Teclado mecánico
            AsignarArticuloAPublicacion(5, 8);  // Laptop
            AsignarArticuloAPublicacion(6, 12); // Sofá
            AsignarArticuloAPublicacion(6, 13); // Mesa de comedor
            AsignarArticuloAPublicacion(6, 15); // Microondas
            AsignarArticuloAPublicacion(7, 5);  // Pesas 10kg
            AsignarArticuloAPublicacion(7, 6);  // Balón de básquet
            AsignarArticuloAPublicacion(7, 29); // Cinta para correr
            AsignarArticuloAPublicacion(8, 22); // Cámara fotográfica
            AsignarArticuloAPublicacion(8, 24); // Teclado mecánico
            AsignarArticuloAPublicacion(8, 35); // Drone
            AsignarArticuloAPublicacion(9, 12); // Sofá
            AsignarArticuloAPublicacion(9, 31); // Aspiradora
            AsignarArticuloAPublicacion(9, 32); // Cafetera
            AsignarArticuloAPublicacion(10, 18); // Coche de juguete
            AsignarArticuloAPublicacion(10, 19); // Rompecabezas 1000 piezas
            AsignarArticuloAPublicacion(10, 50); // Pelota de playa

            // Precarga de Ventas
            AsignarArticuloAPublicacion(1, 37); // Consola de videojuegos
            AsignarArticuloAPublicacion(1, 19); // Videojuego
            AsignarArticuloAPublicacion(2, 14); // Lámpara de pie
            AsignarArticuloAPublicacion(2, 42); // Cortinas
            AsignarArticuloAPublicacion(2, 13); // Mesa de comedor
            AsignarArticuloAPublicacion(3, 17); // Muñeca
            AsignarArticuloAPublicacion(3, 20); // Rompecabezas 1000 piezas
            AsignarArticuloAPublicacion(3, 49); // Lego
            AsignarArticuloAPublicacion(4, 25); // Mouse inalámbrico
            AsignarArticuloAPublicacion(4, 21); // Reloj inteligente
            AsignarArticuloAPublicacion(4, 26); // Impresora
            AsignarArticuloAPublicacion(5, 7);  // Teléfono móvil
            AsignarArticuloAPublicacion(5, 9);  // Tablet
            AsignarArticuloAPublicacion(5, 16); // Microondas
            AsignarArticuloAPublicacion(6, 40); // Estufa
            AsignarArticuloAPublicacion(6, 27); // Silla de oficina
            AsignarArticuloAPublicacion(6, 28); // Cama
            AsignarArticuloAPublicacion(7, 38); // Smart TV
            AsignarArticuloAPublicacion(7, 37); // Consola de videojuegos
            AsignarArticuloAPublicacion(7, 39); // Cargador portátil
            AsignarArticuloAPublicacion(8, 12); // Monitor 24 pulgadas
            AsignarArticuloAPublicacion(8, 11); // Laptop
            AsignarArticuloAPublicacion(8, 26); // Impresora
            AsignarArticuloAPublicacion(9, 17); // Muñeca
            AsignarArticuloAPublicacion(9, 21); // Juguete de construcción
            AsignarArticuloAPublicacion(9, 49); // Lego
            AsignarArticuloAPublicacion(10, 14); // Lámpara de pie
            AsignarArticuloAPublicacion(10, 42); // Cortinas
            AsignarArticuloAPublicacion(10, 43); // Juego de mesa
        }

        private void PrecargarUsuarios()
        {
            AltaUsuario(new Cliente("Marcio", "Pérez", "marcio@example.com", "password123", 500));
            AltaUsuario(new Cliente("Federico", "Cuello", "fede@example.com", "fede123", 1500));
            AltaUsuario(new Cliente("Carlos", "Gómez", "carlos@example.com", "passCarlos",1200));
            AltaUsuario(new Cliente("Sofia", "Rodríguez", "sofia@example.com", "passSofia",850));
            AltaUsuario(new Cliente("Diego", "Martínez", "diego@example.com", "passDiego",980));
            AltaUsuario(new Cliente("Laura", "Fernández", "laura@example.com", "passLaura",1350));
            AltaUsuario(new Cliente("Pablo", "Sánchez", "pablo@example.com", "passPablo",1180));
            AltaUsuario(new Cliente("Lucía", "Hernández", "lucia@example.com", "passLucia",980));
            AltaUsuario(new Cliente("Javier", "Ramírez", "javier@example.com", "passJavier",1000));
            AltaUsuario(new Cliente("Valentina", "Ruiz", "valentina@example.com", "passValentina",1100));
            AltaUsuario(new Administrador("Marcio", "Huertas", "marcio@example.com", "marcio"));
            AltaUsuario(new Administrador("Federico", "Gallo", "federico@example.com", "fede"));
        }

        public void PreCargarOfertas()
        {
            AgregarOfertaAUnaSubasta(1, 1, 500, new DateTime(2023, 05, 11));
            AgregarOfertaAUnaSubasta(2, 1, 600, new DateTime(2023, 06, 12));
        }

        public void AltaArticulo(Articulo articulo)
        {
            if (articulo == null) throw new Exception("El articulo no puede ser nulo");
            articulo.Validar();
            _articulos.Add(articulo);
        }

        public void AltaPublicacion(Publicacion publicacion)
        {
            if(publicacion == null) throw new Exception ("La publicación no puede ser nula");
            publicacion.Validar();
            if (_publicaciones.Contains (publicacion)) throw new Exception("Ya existe esa publicacion en sistema");
            _publicaciones.Add(publicacion);
        }

        public Articulo AsignarArticulo(int idArticulo)
        {
            Articulo articuloBuscado = null;
            int j = 0;
            while (j < _articulos.Count && articuloBuscado == null)
            {
                if (_articulos[j].Id == idArticulo) articuloBuscado = _articulos[j];
                j++;
            }
            return articuloBuscado;
        }

        public Publicacion AsignarPublicacion(int idPublicacion)
        {
            Publicacion publicacionBuscada = null;
            int i = 0;
            while (i < _publicaciones.Count && publicacionBuscada == null)
            {
                if (_publicaciones[i].Id == idPublicacion) publicacionBuscada = _publicaciones[i]; 
                i++;
            }
            return publicacionBuscada;
        }

        public void AsignarArticuloAPublicacion(int idPublicacion, int idArticulo)
        {            
            Publicacion publicacionBuscada = AsignarPublicacion(idPublicacion);
            if (publicacionBuscada == null) throw new Exception("La publicación no fue encontrada o no es válida.");// Buscar la publicación y validar

            Articulo articuloBuscado = AsignarArticulo(idArticulo);
            if (articuloBuscado == null) throw new Exception("El artículo no fue encontrado o no es válido."); // Buscar el artículo y validar
          
            publicacionBuscada.AgregarArticulo(articuloBuscado);  // Asignar el artículo a la publicación
        }

        public void AltaUsuario(Usuario usuario)
        {
            if (usuario == null) throw new Exception("el usuario no puede ser nulo");
            usuario.Validar();
            _usuarios.Add(usuario);
        }

        public Articulo ObtenerArticuloPorId(int id)
        {
            Articulo buscada = null;
            int i = 0;
            while (i < _articulos.Count && buscada == null)
            {
                if (_articulos[i].Id == id) buscada = _articulos[i];
                i++;
            }
            return buscada;
        }

        public List<Articulo> ListarArticulosPorCategoria(string categoriaBuscada)
        {
            string categoriaBuscadaLower = categoriaBuscada.ToLower();// Convertir la categoría buscada a minúsculas

            List<Articulo> articulosFiltrados = new List<Articulo>();
            foreach (Articulo art in _articulos)
            {
               if (art.Categoria.ToLower() == categoriaBuscadaLower) articulosFiltrados.Add(art);// Convertir las categorías almacenadas a minúsculas para la comparación
            }
            return articulosFiltrados;
        }

        public List<Publicacion> ListarPublicaciones(DateTime fecha1, DateTime fecha2)
        {
            List<Publicacion> publicaciones = new List<Publicacion>();
            foreach(Publicacion p in _publicaciones)
            {
                if (p.FechaPublic.Date >= fecha1.Date && p.FechaFinaliz.Date <= fecha2.Date) publicaciones.Add(p);                    
            }
            return publicaciones;
        }

        public List<Cliente> ListarClientes()
        {
            List<Cliente> buscado = new List<Cliente>();
            foreach (Usuario usuario in _usuarios)
            {
                if (usuario is Cliente cliente) buscado.Add(cliente);
            }
            return buscado;
        }

        public Cliente ObtenerUsuarioPorId(int id)
        {
            Cliente buscada = null;
            int i = 0;
            while (i < _usuarios.Count && buscada == null)
            {
                if (_usuarios[i].Id == id && _usuarios[i] is Cliente) buscada = _usuarios[i] as Cliente; // Convertimos el usuario en cliente
                i++;
            }
            return buscada;
        }

        public Subasta ObternerSubastaPorId (int id)
        {
            Subasta buscada = null;
            int i = 0;
            while (i < _publicaciones.Count && buscada == null)
            {
                if(_publicaciones[i].Id == id && _publicaciones[i] is Subasta) buscada = _publicaciones[i] as Subasta; // Convertimos la publicación en subasta
                i++;
            }
            return buscada;
        }

        public void AgregarOfertaAUnaSubasta(int idCliente, int idSubasta, double monto, DateTime fecha)
        {
            Cliente clientebuscado = ObtenerUsuarioPorId(idCliente);
            Subasta subastaBuscada = ObternerSubastaPorId(idSubasta);
            if (clientebuscado == null) throw new Exception("El id de ususario no existe");
            if (subastaBuscada == null) throw new Exception("El id de subasta no existe");
            //if (monto <= 0) throw new Exception("El monto tiene que ser mayor que cero");
            //if (fecha.Year > 2020) throw new Exception("La fecha tiene que ser posterior a 2020");
            Oferta ofertas = new Oferta(clientebuscado, monto, fecha);
            subastaBuscada.AgregarOferta(ofertas);
        }       
    }
}
