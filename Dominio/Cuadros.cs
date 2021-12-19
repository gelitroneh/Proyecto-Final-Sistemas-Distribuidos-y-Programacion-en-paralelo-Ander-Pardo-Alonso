using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Cuadros
    {
        //Propiedades de la tabla cuadros
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string TamañoAlto { get; set; }
        public string TamañoAncho { get; set; }
        public string Fecha_Creacion { get; set; }
        public string Estilo { get; set; }
        public int IdCuadro { get; set; }
        public string ImagenCuadro { get; set; }
    }
}
