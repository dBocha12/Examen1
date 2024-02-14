using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen1
{
    internal class ClsLibro : ILibro
    {
        public int Codigo { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public decimal Precio { get; set; }
        public bool Disponible { get; set; }

        public void Prestar()
        {
            if (Disponible)
            {
                Disponible = false;
                Console.WriteLine("Actualizandop el libro como prestado.");
            }
            else
            {
                Console.WriteLine("El libro no esta disponible, no se puede prestar.");
            }
        }

        public void Devolver()
        {
            if (!Disponible)
            {
                Disponible = true;
                Console.WriteLine("El libro fue devuelto al sistema.");
            }
            else
            {
                Console.WriteLine("El libro ya estaba en el sistema.");
            }
        }

        public void Consultar()
        {
            string disponibleTexto;
            if (Disponible)
            {
                disponibleTexto = "Sí";
            }
            else
            {
                disponibleTexto = "No";
            }
            Console.WriteLine($"Título: {Titulo}, Autor: {Autor}, Disponible: {disponibleTexto}, Precio {Precio}");
        }
    }
}
