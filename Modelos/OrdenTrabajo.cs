using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class OrdenDeTrabajo
    {
        public int id { get; set; }
        public DateTime fechalote { get; set; }
        public int centroCosto { get; set; }

        public OrdenDeTrabajo(int id, DateTime fechalote, int centroCosto)
        {
            this.id = id;
            this.fechalote = fechalote;
            this.centroCosto = centroCosto;
        }

        public OrdenDeTrabajo() { }
    }
}