using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Insumo
    {
        public int idInsumo { get; set; }
        public string detalle { get; set; }
        public string? otros { get; set; }
        public string? cuenta { get; set; }

        public Insumo(int idInsumo, string detalle, string? otros, string? cuenta)
        {
            this.idInsumo = idInsumo;
            this.detalle = detalle;
            this.otros = otros;
            this.cuenta = cuenta;
        }

        public Insumo() { }
    }
}