using DiagramaER.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagramaER
{
   

    public class Nodo
    {
        public string NombreTabla { get; set; }
        public List<Campo> Campos { get; set; } = new List<Campo>();
        public int PosX { get; set; }
        public int PosY { get; set; }
    }
    public class Campo
    {
        public string NombreCampo { get; set; }
        public string TipoDato { get; set; }
        public bool EsClavePrimaria { get; set; }
        public bool EsClaveForanea { get; set; }
    }

    public class Relacion
    {
        public string TablaOrigen { get; set; }
        public string CampoOrigen { get; set; }
        public string TablaDestino { get; set; }
        public string CampoDestino { get; set; }
    }
}
