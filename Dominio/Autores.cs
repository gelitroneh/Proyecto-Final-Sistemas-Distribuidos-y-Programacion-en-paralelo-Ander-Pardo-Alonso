using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Autores
    {
        //Propiedades de la tabla autores
        public string Nombre { get; set; }
        public string Nacimiento { get; set; }
        public string Fallecimiento { get; set; }
        public string Origen { get; set; }
        public string Periodo { get; set; }
        public int IdAutor { get; set; }
        public string ImagenAutor { get; set; }

    }
}
