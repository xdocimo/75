using Datos;
using Modelos;
using System;
using System.Collections.Generic;

namespace Negocio
{
    public class BDetalleOrdenTrabajo
    {

        public static List<DetalleOrdenTrabajo> Get()
        {
            try
            {
                return DDetalleOrdenTrabajo.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }


        public static DetalleOrdenTrabajo GetById(int id)
        {
            try
            {
                return DDetalleOrdenTrabajo.GetById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public static void Insert(int ordenDeTrabajo, int insumo, decimal cantidad)
        {
            try
            {
                DDetalleOrdenTrabajo.InsertDetalleOrdenTrabajo(ordenDeTrabajo, insumo, cantidad);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public static void Update(int id, int ordenDeTrabajo, int insumo, decimal cantidad)
        {
            try
            {
                DDetalleOrdenTrabajo.UpdateDetalleOrdenTrabajo(id, ordenDeTrabajo, insumo, cantidad);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public static void Delete(int id)
        {
            try
            {
                DDetalleOrdenTrabajo.DeleteDetalleOrdenTrabajo(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
