using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagramaER
{
    public class Diagrama
    {
        public int IdDiagrama { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public string ContenidoDiagrama { get; set; } // JSON como string
        public string TipoAlmacenamiento { get; set; } = "JSON";
    }

    public class DiagramaERs
    {
        public string Nombre { get; set; }
        public List<Entidad> Entidades { get; set; } = new List<Entidad>();
        public List<ConexionExportada> Relaciones { get; set; } = new List<ConexionExportada>();
    }

    public class Entidad
    {
        public string Nombre { get; set; }
        public List<Campoo> Campos { get; set; } = new List<Campoo>();
    }

    public class Campoo
    {
        public string Nombre { get; set; }
        public string TipoDato { get; set; }
        public bool EsClavePrimaria { get; set; }
        public bool EsClaveForanea { get; set; }
        public bool permiteNulo { get; set; } = true; // Por defecto permite nulo
    }

    /*public class Relacionn
    {
        public FiguraControl Origen { get; set; }
        public FiguraControl Destino { get; set; }
        public string TipoRelacion { get; set; } // "1:1", "1:N", "N:M"

        public Relacionn(FiguraControl origen, FiguraControl destino, string tipoRelacion)
        {
            Origen = origen;
            Destino = destino;
            TipoRelacion = tipoRelacion;
        }

        public Relacionn Clonar(Dictionary<FiguraControl, FiguraControl> mapaFiguras)
        {
            if (this.Origen == null || this.Destino == null)
                return null;

            if (!mapaFiguras.ContainsKey(this.OrigenCampo) || !mapaFiguras.ContainsKey(this.DestinoEntidad))
                return null;

            return new Relacionn(
                mapaFiguras[this.OrigenCampo],
                mapaFiguras[this.DestinoEntidad],
                this.TipoRelacion
            );
        }

    }*/
}
    
   
     
    
