using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagramaER
{
    public class EntidadJSON
    {
        public string Nombre { get; set; } // Nombre de la entidad
        public int X { get; set; }  // Coordenada de dibujo
        public int Y { get; set; }

        public List<AtributoJSON> Atributos { get; set; } = new List<AtributoJSON>();
        public List<RelacionInternaJSON> Relaciones { get; set; } = new List<RelacionInternaJSON>();
    }

    public class AtributoJSON
    {
        public string Nombre { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public string TipoLlave { get; set; }
        public string TipoDato { get; set; }
    }


}

