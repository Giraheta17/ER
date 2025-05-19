using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagramaER
{
    public class RelacionInternaJSON
    {
        public string Nombre { get; set; }
        public string TipoRelacion { get; set; }
        public string Cardinalidad { get; set; }
        public string LlaveForanea { get; set; }
    }
}
