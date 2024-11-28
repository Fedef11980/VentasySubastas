using Dominio;
using System.Text.RegularExpressions;

namespace Consola
{
    internal class Program
    {
        private static Sistema miSistema;

        static void Main(string[] args)
        {
            miSistema = new Sistema();

            string opcion = "";

            while (opcion != "0")
            {
                MostrarMenu();
                opcion = PedirPalabras("Ingrese una opcion -> ");

                switch (opcion)
                {
                    case "1":
                        ListarClientes();
                        break;
                    case "2":
                        ListarArticulosPorCategoria();
                        break;
                    case "3":
                        AltaArticulo(); 
                        break;
                        case "4":
                        ListarPublicacionesEntreFechas();
                        break;
                    case "0":
                        Console.WriteLine("Saliendo ...");
                        break;
                    default:
                        Console.WriteLine("Opcion incorrecta");
                        break;
                }
            }
        }

        #region METODOS AUXILIARES

        static void MostrarMenu()
        {
            Console.Clear();
            MostrarMensajeColor(ConsoleColor.Cyan, "****************");
            MostrarMensajeColor(ConsoleColor.Cyan, "      MENU      ");
            MostrarMensajeColor(ConsoleColor.Cyan, "****************");
            Console.WriteLine();
            Console.WriteLine("1 - Listar Clientes");
            Console.WriteLine("2 - Listado de Articulos por Categoria");
            Console.WriteLine("3 - Alta Articulo");
            Console.WriteLine("4 - Listado de Publicaciones dada 2 fechas"); //MENU CONSOLA

            Console.WriteLine("0 - Salir");
        }

        static string PedirPalabras(string mensaje)
        {
            Console.Write(mensaje);
            string datos = Console.ReadLine();
            return datos;
        }

        static int PedirNumeros(string mensaje)
        {
            bool exito = false;
            int valorConvertido = 0;

            while (!exito)
            {
                Console.Write(mensaje);
                exito = int.TryParse(Console.ReadLine(), out valorConvertido);

                if (!exito)
                {
                    MostrarError("ERROR: Debe ingresar solo numeros");
                }
            }

            return valorConvertido;
        }

        static DateTime PedirFecha(string mensaje)
        {
            bool exito = false;
            DateTime fecha = new DateTime();

            while (!exito)
            {
                Console.Write($"{mensaje} [dd/MM/yyyy]:");
                exito = DateTime.TryParse(Console.ReadLine(), out fecha);

                if (!exito)
                {
                    MostrarError("ERROR: La fecha no respeta el formato dd/MM/yyyy");
                }
            }

            return fecha;
        }

        static double PedirNumerosDouble(string mensaje)
        {
            bool exito = false;
            double valorConvertido = 0;

            while (!exito)
            {
                Console.Write(mensaje);
                exito = double.TryParse(Console.ReadLine(), out valorConvertido);

                if (!exito)
                {
                    MostrarError("ERROR: Debe ingresar solo numeros");
                }
            }

            return valorConvertido;
        }

        static void MostrarMensajeColor(ConsoleColor color1, string mensaje)
        {
            Console.ForegroundColor = color1;
            Console.WriteLine(mensaje);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        static void MostrarError(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(mensaje);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        static void MostrarExito(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(mensaje);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        static void PressToContinue()
        {
            Console.WriteLine();
            Console.WriteLine("Presione cualquier tecla para volver al menu...");
            Console.ReadKey();
        }

        #endregion

        #region METODOS DE MENU

        static void Saludo()
        {
            Console.Clear();
            MostrarMensajeColor(ConsoleColor.Yellow, "FUNCIONALIDAD SALUDO");
            Console.WriteLine();

            Console.Write("Ingrese nombre: ");
            string nombre = Console.ReadLine();
            Console.WriteLine($"Bienvenido {nombre}");

            PressToContinue();
        }
        static void ListarClientes()
        {
            Console.Clear();
            MostrarMensajeColor(ConsoleColor.Yellow, "Lista de Clientes");
            Console.WriteLine();

            try
            {
                // Obtener la lista de clientes desde el sistema
                List<Cliente> todosLosClientes = miSistema.ListarClientes();

                // Verificar si la lista está vacía
                if (todosLosClientes == null || todosLosClientes.Count == 0)
                {
                    MostrarError("No existen Clientes en el sistema.");
                }
                else
                {
                    // Mostrar los clientes en formato limpio
                    foreach (Cliente cliente in todosLosClientes)
                    {
                        Console.WriteLine(cliente.ToString());  // Asume que tienes un método ToString en Cliente
                    }
                }
            }
            catch (Exception ex)
            {
                MostrarError($"Error al listar los clientes: {ex.Message}");
            }

            PressToContinue();  // Esperar para continuar
        }



        static void ListarArticulosPorCategoria()
        {
            Console.Clear();
            MostrarMensajeColor(ConsoleColor.Yellow, "Lista de Artículos por Categoría");
            Console.WriteLine();

            try
            {
                // Pedir la categoría al usuario
                string categoriaBuscada = PedirPalabras("Ingrese la categoría: ");

                // Obtener artículos filtrados por categoría
                List<Articulo> articulosFiltrados = miSistema.ListarArticulosPorCategoria(categoriaBuscada);

                // Verificar si no hay artículos en la categoría buscada
                if (articulosFiltrados == null || articulosFiltrados.Count == 0)
                {
                    MostrarError($"No hay artículos en la categoría '{categoriaBuscada}'.");
                }
                else
                {
                    // Mostrar los artículos filtrados
                    foreach (Articulo articulo in articulosFiltrados)
                    {
                        Console.WriteLine(articulo.ToString());  // Asume que tienes un método ToString en Articulo
                    }
                }
            }
            catch (Exception ex)
            {
                MostrarError($"Error al listar los artículos por categoría: {ex.Message}");
            }

            PressToContinue();  // Esperar para continuar
        }

        static void AltaArticulo()
        {
            Console.Clear();
            MostrarMensajeColor(ConsoleColor.Yellow, "Alta de Articulos");
            Console.WriteLine();

            string nombre = PedirPalabras("Ingrese nombre : ");
            string categoria = PedirPalabras("Ingrese categoria: ");
            double precio = PedirNumerosDouble("Ingrese precio: ");

            try
            {
                if (string.IsNullOrWhiteSpace(nombre)) // Valida si el nombre está vacío o es solo espacios
                {
                    throw new Exception("El nombre no puede estar vacío.");
                }

                if (string.IsNullOrWhiteSpace(categoria)) // Valida si la categoría está vacía o es solo espacios
                {
                    throw new Exception("La categoría no puede estar vacía.");
                }

                if (precio <= 0) // Valida que el precio sea mayor que cero
                {
                    throw new Exception("El precio debe ser mayor a cero.");
                }

                miSistema.AltaArticulo(new Articulo(nombre, categoria, precio));
                MostrarExito("Artículo registrado exitosamente.");
            }
            catch (Exception ex)
            {
                MostrarError($"Error: {ex.Message}");
            }

            PressToContinue();
        }

        static void ListarPublicacionesEntreFechas()
        {
            Console.Clear();
            MostrarMensajeColor(ConsoleColor.Yellow, "Listar Publicaciones entre Fechas");
            Console.WriteLine();

            DateTime fecha1 = PedirFecha("Ingrese la primera fecha: ");
            DateTime fecha2 = PedirFecha("Ingrese la segunda fecha: ");

            try
            {
                List<Publicacion> publicacionesFiltradas = miSistema.ListarPublicaciones( fecha1, fecha2);
                if (publicacionesFiltradas == null || publicacionesFiltradas.Count == 0)
                {
                    throw new Exception("No hay publicaciones entre esas fechas.");
                }

                foreach (Publicacion publicacion in publicacionesFiltradas)
                {
                    Console.WriteLine($"{publicacion.Id} - {publicacion.Nombre} - {publicacion.Estado} - {publicacion.FechaPublic}");
                }
            }
            catch (Exception ex)
            {
                MostrarError(ex.Message);
            }

            PressToContinue();
        }



      
        


        #endregion
    }
}
