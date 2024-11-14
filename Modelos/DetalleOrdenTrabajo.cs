namespace Modelos
{
    public class DetalleOrdenTrabajo
    {
        public int id { get; set; }
        public OrdenTrabajo ordenDeTrabajo { get; set; }  
        public Insumo insumo { get; set; }  
        public decimal cantidad { get; set; }

        public DetalleOrdenTrabajo(int id, OrdenTrabajo ordenDeTrabajo, Insumo insumo, decimal cantidad)
        {
            this.id = id;
            this.ordenDeTrabajo = ordenDeTrabajo;
            this.insumo = insumo;
            this.cantidad = cantidad;
        }

        public DetalleOrdenTrabajo() { }
    }


    public class OrdenTrabajo
    {
        public int id { get; set; }
        public DateTime fechaLote { get; set; }
        public CentroCosto centroDeCosto { get; set; }
    }
}
