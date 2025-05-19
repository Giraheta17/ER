using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagramaER
{
    public class DiagramaJSON
    {
        public string NombreDiagrama { get; set; }
        public List<EntidadJSON> Entidades { get; set; } = new List<EntidadJSON>();
        public List<RelacionGlobalJSON> Relaciones { get; set; } = new List<RelacionGlobalJSON>();
    }
}
