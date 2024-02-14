using System;

namespace Examen1
{
    class Program
    {
        static void Main(string[] args)
        {
            ClsBiblioteca biblioteca = new ClsBiblioteca();
            LibrosEnEstante(biblioteca);

            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("  ===  BIBLIOTECA MUNICIPAL  ===  ");
                Console.WriteLine("");
                Console.WriteLine("1. AGREGAR LIBRO");
                Console.WriteLine("2. ELIMINAR UN LIBRO");
                Console.WriteLine("3. REPORTE DE TODOS LOS LIBROS");
                Console.WriteLine("4. BUSCAR LIBRO");
                Console.WriteLine("5. LIBROS DE MAYOR PRECIO");
                Console.WriteLine("6. LIBROS DE MENOR PRECIO");
                Console.WriteLine("7. SALIR");
                Console.WriteLine("");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();
                Console.WriteLine();

                switch (opcion)
                {
                    case "1":
                        try
                        {
                            ClsLibro nuevoLibro = CrearNuevoLibro();
                            biblioteca.AgregarLibro(nuevoLibro);
                            Console.WriteLine("");
                            Console.WriteLine("Libro agregado a la biblioteca.");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Ocurrio un error al usar esta opcion");
                        }
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("===  ELIMINAR LIBRO  ===");
                        Console.WriteLine("Ingrese el título del libro a eliminar, libros disponibes: ");
                        Console.WriteLine("");
                        biblioteca.MostrarLibros();
                        string tituloEliminar = Console.ReadLine();
                        if (biblioteca.EliminarLibro(tituloEliminar))
                        {
                            Console.WriteLine("Libro eliminado correctamente.");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("No se encontró ningún libro con ese título.");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                    case "3":
                        biblioteca.MostrarLibros();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "4":
                        Console.Write("Ingrese el nombre del libro: ");
                        string nombreLibro = Console.ReadLine();
                        biblioteca.BuscarLibros(nombreLibro);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "5":
                        biblioteca.LibroMasCaro();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "6":
                        biblioteca.LibrosMasBaratos();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "7":
                        salir = true;
                        Console.WriteLine("¡Hasta luego!");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }

                Console.WriteLine();
            }
        }

        static ClsLibro CrearNuevoLibro()
        {
            ClsLibro nuevoLibro = null;
            bool datosIncorrectos = false;

            do
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("===  NUEVO LIBRO  ===");
                    Console.WriteLine("");
                    Console.Write("Ingrese el código del nuevo libro: ");
                    int codigo = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Ingrese el título del nuevo libro: ");
                    string titulo = Console.ReadLine();

                    Console.Write("Ingrese el autor del nuevo libro: ");
                    string autor = Console.ReadLine();

                    Console.Write("Ingrese la fecha de publicacion del libro (YYYY-MM-DD): ");
                    DateTime fechaPublicacion = Convert.ToDateTime(Console.ReadLine());

                    Console.Write("Ingrese el precio: ");
                    decimal precio = Convert.ToDecimal(Console.ReadLine());

                    Console.WriteLine("Este libro esta disponible? (true/false): ");
                    Console.WriteLine("'true' para confirmar que SI esta disponible,");
                    Console.Write("'false' para registrar que este libro NO esta disponible: ");
                    bool disponible = Convert.ToBoolean(Console.ReadLine());

                    nuevoLibro = new ClsLibro
                    {
                        Codigo = codigo,
                        Titulo = titulo,
                        Autor = autor,
                        FechaPublicacion = fechaPublicacion,
                        Precio = precio,
                        Disponible = disponible
                    };

                    datosIncorrectos = false;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Error: El formato de los datos ingresados no es correcto. Inténtelo de nuevo.");
                    datosIncorrectos = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    datosIncorrectos = true;
                }
            } while (datosIncorrectos);

            return nuevoLibro;
        }


        static void LibrosEnEstante(ClsBiblioteca biblioteca)
        {
            biblioteca.AgregarLibro(new ClsLibro
            {
                Codigo = 1,
                Titulo = "Cien años de soledad",
                Autor = "Gabriel García Márquez",
                FechaPublicacion = new DateTime(1967, 5, 30),
                Precio = 10000,
                Disponible = true
            });

            biblioteca.AgregarLibro(new ClsLibro
            {
                Codigo = 2,
                Titulo = "El principito",
                Autor = "Antoine de Saint-Exupéry",
                FechaPublicacion = new DateTime(1943, 4, 6),
                Precio = 10000,
                Disponible = false
            });

            biblioteca.AgregarLibro(new ClsLibro
            {
                Codigo = 3,
                Titulo = "Harry Potter",
                Autor = "J.K. Rowling",
                FechaPublicacion = new DateTime(1997, 6, 26),
                Precio = 10000,
                Disponible = true
            });
        }
    }
}
