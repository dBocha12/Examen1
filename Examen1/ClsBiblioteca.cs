using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen1
{
    internal class ClsBiblioteca : ClsLibro
    {
        private List<ClsLibro> libros;

        public ClsBiblioteca()
        {
            libros = new List<ClsLibro>();
        }

        public void AgregarLibro(ClsLibro libro)
        {
            libros.Add(libro);
        }

        public bool EliminarLibro(string titulo)
        {
            ClsLibro libroAEliminar = libros.FirstOrDefault(libro => libro.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));
            if (libroAEliminar != null)
            {
                libros.Remove(libroAEliminar);
                return true;
            }
            return false;
        }


        public void MostrarLibros()
        {
            foreach (var libro in libros)
            {
                libro.Consultar();
            }
        }


        public void BuscarLibros(string nombreLibro)
        {
            foreach (var libro in libros)
            {
                if (libro.Titulo.StartsWith(nombreLibro, StringComparison.OrdinalIgnoreCase))
                {
                    libro.Consultar();
                }
            }
        }


        public void LibroMasCaro()
        {
            decimal mayorPrecio = decimal.MinValue;
            ClsLibro libroMayorPrecio = null;

            foreach (var libro in libros)
            {
                if (libro.Precio > mayorPrecio)
                {
                    mayorPrecio = libro.Precio;
                    libroMayorPrecio = libro;
                }
            }

            if (libroMayorPrecio != null)
            {
                Console.WriteLine("El libro de mayor precio es:");
                libroMayorPrecio.Consultar();
            }
            else
            {
                Console.WriteLine("No hay libros en la biblioteca.");
            }
        }

        public void LibrosMasBaratos()
        {
            if (libros.Count < 3)
            {
                Console.WriteLine("No hay suficientes libros en la biblioteca para mostrar los tres más baratos.");
                return;
            }

            var librosOrdenadosPorPrecio = libros.OrderBy(libro => libro.Precio).ToList();

            Console.WriteLine("Los tres libros más baratos son:");
            for (int i = 0; i < 3; i++)
            {
                librosOrdenadosPorPrecio[i].Consultar();
            }
        }
    }
}
