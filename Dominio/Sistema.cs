using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Sistema
    {

        private static Sistema s_instancia;
        //LISTAS GENERALES DE SISTEMA
        private List<Articulo> _articulos = new List<Articulo>();
        private List<Oferta> _ofertas = new List<Oferta>();
        private List<Usuario> _usuarios = new List<Usuario>();
        private List<Publicacion> _publicaciones = new List<Publicacion>();

        private Sistema()
        {
            PrecargarUsuarios();
            PrecargarArticulos();
            PrecargarPublicaciones();
        }


        //Getters
        public static Sistema Instancia
        {
            get
            {
                if (s_instancia == null) s_instancia = new Sistema();
                return s_instancia;
            }
        }

        public List<Usuario> Usuarios
        {
            get { return _usuarios; }
        }

        public List<Articulo> Articulos
        {
            get { return _articulos; }
        }

        public List<Publicacion> Publicaciones
        {
            get { return _publicaciones; }
        }


        //Metodos
        public Usuario ObtenerUsuarioPorId(int id)
        {
            Usuario buscada = null;
            int i = 0;
            while (i < _usuarios.Count && buscada == null)
            {
                if (_usuarios[i].Id == id) buscada = _usuarios[i];
                i++;
            }

            return buscada;
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

        public Publicacion ObtenerPublicacionPorId(int id)
        {
            Publicacion buscada = null;
            int i = 0;
            while (i < _publicaciones.Count && buscada == null)
            {
                if (_publicaciones[i].Id == id) buscada = _publicaciones[i];
                i++;
            }
            return buscada;
        }

        //precarga de articulos
        private void PrecargarArticulos()
        {
            AltaArticulo(new Articulo("Pelota futbol", "deporte", 100));
            AltaArticulo(new Articulo("Pelota futbol", "Deporte", 100));
            AltaArticulo(new Articulo("Raqueta de tenis", "Deporte", 150));
            AltaArticulo(new Articulo("Bicicleta", "Deporte", 300));
            AltaArticulo(new Articulo("Pesas 10kg", "Deporte", 80));
            AltaArticulo(new Articulo("Balón de básquet", "Deporte", 120));

            AltaArticulo(new Articulo("Teléfono móvil", "Tecnología", 500));
            AltaArticulo(new Articulo("Laptop", "Tecnología", 1000));
            AltaArticulo(new Articulo("Tablet", "Tecnología", 300));                             //precargas de articulos
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

            AltaArticulo(new Articulo("Patinete", "Deporte", 100));
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
            AltaArticulo(new Articulo("Trompo", "Juguetería", 5));
        }

        //precarga de usuarios(clientes y administradores)
        private void PrecargarUsuarios()
        {
            AltaUsuario(new Cliente("Marcio", "Pérez", "marcio@example.com", "password123", 10000));
            AltaUsuario(new Cliente("Federico", "Cuello", "fede@example.com", "fede123", 3000));
            AltaUsuario(new Cliente("Carlos", "Gómez", "carlos@example.com", "passCarlos", 5700));
            AltaUsuario(new Cliente("Sofia", "Rodríguez", "sofia@example.com", "passSofia", 200));
            AltaUsuario(new Cliente("Diego", "Martínez", "diego@example.com", "passDiego", 600)); //Precarga de usuarios
            AltaUsuario(new Cliente("Laura", "Fernández", "laura@example.com", "passLaura", 400));
            AltaUsuario(new Cliente("Pablo", "Sánchez", "pablo@example.com", "passPablo", 350));
            AltaUsuario(new Cliente("Lucía", "Hernández", "lucia@example.com", "passLucia", 800));
            AltaUsuario(new Cliente("Javier", "Ramírez", "javier@example.com", "passJavier", 150));
            AltaUsuario(new Cliente("Valentina", "Ruiz", "valentina@example.com", "passValentina", 550));
            AltaUsuario(new Administrador("Marcio", "Huertas", "marciohuertasrial1995@outlook.com", "marcio"));
            AltaUsuario(new Administrador("Fede", "Gallo", "fede@outlook.com", "fede"));

        }
       
        public void PrecargarPublicaciones()
        {
            List<Articulo> listaArticulos1 = new List<Articulo> { _articulos[1], _articulos[2] };
            List<Articulo> listaArticulos4 = new List<Articulo> { _articulos[1], _articulos[2] };
            List<Articulo> listaArticulos5 = new List<Articulo> { _articulos[1], _articulos[2] };
            List<Articulo> listaArticulos6 = new List<Articulo> { _articulos[1], _articulos[2] };
            List<Articulo> listaArticulos7 = new List<Articulo> { _articulos[1], _articulos[2] };
            List<Articulo> listaArticulos8 = new List<Articulo> { _articulos[1], _articulos[2] };

            List<Oferta> listaOfertas = new List<Oferta>();

            Cliente cliente1 = (Cliente)ObtenerUsuarioPorId(1);
            Administrador admin1 = (Administrador)ObtenerUsuarioPorId(12);

            if (cliente1 == null || admin1 == null)
                throw new Exception("Cliente o administrador no encontrado");

            // Precargar 8 publicaciones de venta
            AltaPublicacion(new Venta("Electrodomesticos", new DateTime(2024, 10, 12), new DateTime(2024, 12, 12), (Cliente)ObtenerUsuarioPorId(2), listaArticulos1, Estado.ABIERTA, false));
            AltaPublicacion(new Venta("Juegos recreativos", new DateTime(2024, 11, 01), new DateTime(2024, 12, 25), cliente1, listaArticulos4, Estado.ABIERTA, false));
            AltaPublicacion(new Venta("Ropa antigua", new DateTime(2024, 09, 15), new DateTime(2024, 11, 30), (Cliente)ObtenerUsuarioPorId(3), listaArticulos8, Estado.ABIERTA, false));
            AltaPublicacion(new Venta("Ludos retro", new DateTime(2024, 08, 20), new DateTime(2024, 10, 20), cliente1, listaArticulos8, Estado.ABIERTA, false));
            AltaPublicacion(new Venta("Gamer pc y mas", new DateTime(2024, 12, 01), new DateTime(2025, 01, 01), (Cliente)ObtenerUsuarioPorId(4), listaArticulos5, Estado.ABIERTA, false));
            AltaPublicacion(new Venta("Jueto de baño", new DateTime(2024, 07, 10), new DateTime(2024, 09, 10), cliente1, listaArticulos6, Estado.ABIERTA, false));
            AltaPublicacion(new Venta("Juego de pesas", new DateTime(2024, 06, 05), new DateTime(2024, 08, 05), (Cliente)ObtenerUsuarioPorId(5), listaArticulos1, Estado.ABIERTA, false));
            AltaPublicacion(new Venta("Instrumentos", new DateTime(2024, 05, 15), new DateTime(2024, 07, 15), cliente1, listaArticulos8, Estado.ABIERTA, false));
            AltaPublicacion(new Venta("CD`s antiguos", new DateTime(2024, 05, 15), new DateTime(2024, 07, 15), cliente1, listaArticulos7, Estado.ABIERTA, false));
            AltaPublicacion(new Venta("Kit basket", new DateTime(2024, 05, 15), new DateTime(2024, 07, 15), cliente1, listaArticulos5, Estado.ABIERTA, false));

            // Precargar subasta con ofertas como ejemplo adicional
            Subasta subasta1 = new Subasta("Kit Montaña", new DateTime(2024, 05, 10), new DateTime(2025, 01, 01), cliente1, listaArticulos1, Estado.ABIERTA, 0, admin1, listaOfertas);
            AltaPublicacion(subasta1);

            // Agregar ofertas a la primera subasta
            AgregarOfertaAUnaSubasta(cliente1.Id, subasta1.Id, 500, new DateTime(2023, 05, 11));
            AgregarOfertaAUnaSubasta(2, subasta1.Id, 600, new DateTime(2023, 06, 12));

            // Precargar una nueva subasta con ofertas
            List<Articulo> listaArticulos2 = new List<Articulo> { _articulos[3], _articulos[4] };

            Subasta subasta2 = new Subasta("Pack Hogar", new DateTime(2024, 06, 01), new DateTime(2025, 02, 01), cliente1, listaArticulos2, Estado.ABIERTA, 0, admin1, new List<Oferta>());
            AltaPublicacion(subasta2);

            // Agregar ofertas a la nueva subasta
            AgregarOfertaAUnaSubasta(cliente1.Id, subasta2.Id, 800, new DateTime(2024, 06, 15));
            AgregarOfertaAUnaSubasta(3, subasta2.Id, 900, new DateTime(2024, 06, 20));
            AgregarOfertaAUnaSubasta(4, subasta2.Id, 1000, new DateTime(2024, 07, 01));
            List<Articulo> listaArticulos3 = new List<Articulo> { _articulos[3], _articulos[4] };

            // Creación de las subastas
            Subasta subasta3 = new Subasta("Juegos de mesa", new DateTime(2024, 05, 10), new DateTime(2025, 01, 01), cliente1, listaArticulos2, Estado.ABIERTA, 0, admin1, new List<Oferta>());
            AltaPublicacion(subasta3);

            Subasta subasta4 = new Subasta("Pack Acuatico", new DateTime(2024, 06, 01), new DateTime(2025, 02, 01), cliente1, listaArticulos2, Estado.ABIERTA, 0, admin1, new List<Oferta>());
            AltaPublicacion(subasta4);

            Subasta subasta5 = new Subasta("Colección de Arte", new DateTime(2024, 07, 01), new DateTime(2025, 03, 01), cliente1, listaArticulos2, Estado.ABIERTA, 0, admin1, new List<Oferta>());
            AltaPublicacion(subasta5);

            Subasta subasta6 = new Subasta("Instrumentos Musicales", new DateTime(2024, 08, 01), new DateTime(2025, 04, 01), cliente1, listaArticulos2, Estado.ABIERTA, 0, admin1, new List<Oferta>());
            AltaPublicacion(subasta6);

            Subasta subasta7 = new Subasta("Electrodomésticos", new DateTime(2024, 09, 01), new DateTime(2025, 05, 01), cliente1, listaArticulos2, Estado.ABIERTA, 0, admin1, new List<Oferta>());
            AltaPublicacion(subasta7);

            Subasta subasta8 = new Subasta("Antigüedades", new DateTime(2024, 10, 01), new DateTime(2025, 06, 01), cliente1, listaArticulos2, Estado.ABIERTA, 0, admin1, new List<Oferta>());
            AltaPublicacion(subasta8);

            Subasta subasta9 = new Subasta("Equipos de Camping", new DateTime(2024, 11, 01), new DateTime(2025, 07, 01), cliente1, listaArticulos2, Estado.ABIERTA, 0, admin1, new List<Oferta>());
            AltaPublicacion(subasta9);

            Subasta subasta10 = new Subasta("Colección de Libros", new DateTime(2024, 12, 01), new DateTime(2025, 08, 01), cliente1, listaArticulos2, Estado.ABIERTA, 0, admin1, new List<Oferta>());
            AltaPublicacion(subasta10);   
        }

        public void AgregarOfertaAUnaSubasta(int idCliente, int idSubasta, decimal monto, DateTime fecha)
        {
            Cliente clientebuscado = (Cliente)ObtenerUsuarioPorId(idCliente);
            if (clientebuscado == null) throw new Exception("El id del usuario no existe");
            Publicacion subastaBuscada = ObtenerPublicacionPorId(idSubasta);
            if (subastaBuscada == null) throw new Exception("El id de la subasta no existe");
            if (!(subastaBuscada is Subasta subasta)) throw new Exception("La publicación no es una subasta");
            Oferta oferta = new Oferta(clientebuscado, monto, fecha);

            // Agregar la oferta a la subasta
            subasta.AgregarOferta(oferta);
        }

        //Metodo que devuelve una lista de Clientes
        public List<Cliente> ListarClientes()
        {
            // Crear una lista de clientes filtrando la liista de usuarios
            List<Cliente> clientesFiltrados = new List<Cliente>();

            foreach (Usuario usuario in _usuarios)
            {
                if (usuario is Cliente cliente)
                {
                    clientesFiltrados.Add(cliente);
                }
            }

            return clientesFiltrados;
        }

        public void AltaArticulo(Articulo articulo)
        {
            if (articulo == null) throw new Exception("El articulo no puede ser nulo");
            articulo.Validar();

            _articulos.Add(articulo);
        }
       
        public void AltaUsuario(Usuario usuario)
        {
            if (usuario == null) throw new ArgumentNullException("El usuario no puede ser nulo");
            usuario.Validar();
            _usuarios.Add(usuario);
        }

        public void AltaVenta(Venta publicacion)
        {
            if (publicacion == null) throw new Exception("La publicacion no puede ser nuka");
            publicacion.Validar();
            _publicaciones.Add(publicacion);
        }

        public void AltaPublicacion(Publicacion publicacion)
        {
            if (publicacion == null) throw new Exception("La publicacion no puede ser nula");
            publicacion.Validar();
            _publicaciones.Add(publicacion);
        }

        public List<Articulo> ListarArticulosPorCategoria(string categoriaBuscada)
        {
            // convertimos la categoría buscada a minúsculas
            string categoriaBuscadaLower = categoriaBuscada.ToLower();

            List<Articulo> articulosFiltrados = new List<Articulo>();
            foreach (Articulo art in _articulos)
            {
                if (art.Categoria.ToLower() == categoriaBuscadaLower) //si las categoria coincide con la categoria ingresada como parametro, agregamos a la lista el articulo
                {
                    articulosFiltrados.Add(art);
                }
            }
            return articulosFiltrados;
        }

        public List<Publicacion> ListarPublicaciones(DateTime fecha1, DateTime fecha2)
        {
            List<Publicacion> publicaciones = new List<Publicacion>();

            foreach (Publicacion p in _publicaciones)
            {
                if (p.FechaPublic >= fecha1 && p.FechaFinaliz <= fecha2)
                    publicaciones.Add(p);
            }



            return publicaciones;
        }

        public List<Publicacion> ObtenerPublicacionPorTipo(string tipoPublicacion)
        {
            List<Publicacion> buscadas = new List<Publicacion>();
            foreach (Publicacion p in _publicaciones)
            {
                if (p.TipoDePublicacion().ToLower() == tipoPublicacion.ToLower()) buscadas.Add(p);
            }
            return buscadas;
        }

        public void AgregarArticuloAPublicacion(int IdArticulo, int idPublicacion)
        {
            Articulo articuloBuscado = ObtenerArticuloPorId(IdArticulo);
            if (articuloBuscado == null) throw new Exception("El articulo no puedr ser vacio");
            Publicacion publicacionBuscada = ObtenerPublicacionPorId(idPublicacion);
            if (publicacionBuscada == null) throw new Exception("La publicacion no puede ser vacio");
            publicacionBuscada.AgregarArticulo(articuloBuscado);
        }

        public Usuario Login(string email, string pass)
        {
            Usuario usuarioBuscado = null;
            int i = 0;
            while (usuarioBuscado == null && i < _usuarios.Count)
            {
                if (_usuarios[i].Email == email && _usuarios[i].Contrasena == pass) usuarioBuscado = _usuarios[i];
                i++;
            }
            return usuarioBuscado;
        }

        public List<Subasta> ListadoSubastas()
        {
            // Lista para almacenar subastas encontradas
            List<Subasta> subastasEncontradas = new List<Subasta>();

            // Filtrar solo las publicaciones que sean del tipo Subasta
            foreach (var publicacion in _publicaciones)
            {
                if (publicacion is Subasta subasta)
                {
                    subastasEncontradas.Add(subasta);
                }
            }

            // Ordenar por fecha de publicación (asume que Subasta tiene un atributo FechaPublicacion)
            subastasEncontradas.Sort();
            return subastasEncontradas;
        }

        public void CargarSaldoEnBilletera(int idCliente, decimal nuevoSaldo)
        {
            Usuario clienteBuscado = ObtenerUsuarioPorId(idCliente);
            if (clienteBuscado == null) throw new Exception("El cliente no se encontró");
            if (clienteBuscado is Cliente cliente) cliente.AgregarSaldo(nuevoSaldo);
            else throw new Exception("El usuario encontrado no es un cliente");            
        }
    }
}