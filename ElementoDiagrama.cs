using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagramaER
{
    public class ElementoDiagrama
    {
        public string Tipo { get; set; }      // "Entidad", "Atributo", "Relacion", etc.
        public string Nombre { get; set; }
        public int X { get; set; }            // Coordenada X
        public int Y { get; set; }            // Coordenada Y
    }
}
