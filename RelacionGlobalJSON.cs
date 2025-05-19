using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagramaER
{
    public class RelacionGlobalJSON
    {
        public string entidad1 { get; set; }
        public string entidad2 { get; set; }
        public string tipo { get; set; }
        public string cardinalidad { get; set; }
        public string clave_foranea { get; set; }
    }
}
