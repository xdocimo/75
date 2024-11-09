using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class DetalleOrdenTrabajo
    {
        public int id { get; set; }
        public int ordenDeTrabajo { get; set; }
        public int insumo { get; set; }
        public decimal cantidad { get; set; }

        public DetalleOrdenTrabajo(int id, int ordenDeTrabajo, int insumo, decimal cantidad)
        {
            this.id = id;
            this.ordenDeTrabajo = ordenDeTrabajo;
            this.insumo = insumo;
            this.cantidad = cantidad;
        }

        public DetalleOrdenTrabajo() { }
    }
}