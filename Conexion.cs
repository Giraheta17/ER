using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DiagramaER
{
    public class Conexion
    {
        public FiguraControl Origen { get; set; }
        public FiguraControl Destino { get; set; }
        public string TipoRelacion { get; set; }

        public Conexion(FiguraControl origen, FiguraControl destino, string tipoRelacion)
        {
            Origen = origen;
            Destino = destino;
            TipoRelacion = tipoRelacion;
        }

        public Conexion Clonar(Dictionary<FiguraControl, FiguraControl> mapaFiguras)
        {
            if (this.Origen == null || this.Destino == null)
                return null;

            if (!mapaFiguras.ContainsKey(this.Origen) || !mapaFiguras.ContainsKey(this.Destino))
                return null;

            return new Conexion(
                mapaFiguras[this.Origen],
                mapaFiguras[this.Destino],
                this.TipoRelacion
            );
        }
    }
}
