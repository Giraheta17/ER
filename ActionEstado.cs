using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagramaER
{
    public class ActionEstado
    {
        public List<FiguraControl> Figuras { get; set; }
        public List<Conexion> Conexiones { get; set; }

        public ActionEstado(List<FiguraControl> figuras, List<Conexion> conexiones)
        {
            // Clonamos las listas
            Figuras = new List<FiguraControl>(figuras);
            Conexiones = new List<Conexion>(conexiones);
        }
    }
}
