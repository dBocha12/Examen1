using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen1
{
    internal interface ILibro
    {
        void Prestar();
        void Devolver();
        void Consultar();
    }
}