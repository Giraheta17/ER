using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DiagramaER
{
    public class DiagramaImportado
    {
        public List<FiguraExportada> Figuras { get; set; } = new List<FiguraExportada>();
        public List<ConexionExportada> Conexiones { get; set; } = new List<ConexionExportada>();
        public DiagramaERs DiagramaER { get; set; }
    }

    public class FiguraExportada
    {
        public string ID { get; set; } // ID único de la figura
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public string TipoLlave { get; set; } // Puede ser null
        public string DestinoLlave { get; set; } // Nombre del destino si es foránea
        public string TipoDato { get; set; } // Tipo de dato del atributo
    }

    public class ConexionExportada
    {
        public string Origen { get; set; } // Nombre de la figura origen
        public string Destino { get; set; } // Nombre de la figura destino
        public string TipoRelacion { get; set; } // Ej: "1:N", "N:N"
    }

    public class RelacionExportada
    {
        public string Origen { get; set; } // Nombre de la figura origen
        public string Destino { get; set; } // Nombre de la figura destino
        public string TipoRelacion { get; set; } // Ej: "1:N", "N:N"
    }
}
