using Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Configuration;


namespace Datos
{
    public class DDetalleOrdenTrabajo
    {

        public static void DeleteDetalleOrdenTrabajo(int id)
        {
            try
            {
                string conexion = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

                using (SqlConnection connection = new SqlConnection(conexion))
                {
                    SqlCommand command = new SqlCommand("DeleteDetalleOrdenTrabajo", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", id);

                    connection.Open();
                    command.ExecuteNonQuery(); 
                } 
            }
            catch (SqlException sqlEx)
            {
                throw new Exception("Error al eliminar el detalle de la orden de trabajo: " + sqlEx.Message, sqlEx);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado: " + ex.Message, ex);
            }
        }

        public static List<DetalleOrdenTrabajo> GetAll()
        {
            var result = new List<DetalleOrdenTrabajo>();
            try
            {
                string conexion = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                SqlConnection connection = new SqlConnection(conexion);
                connection.Open();
                SqlCommand command = new SqlCommand("GetAllDetalleOrdenTrabajo", connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    DetalleOrdenTrabajo detalle = new DetalleOrdenTrabajo();
                    detalle.id = Convert.ToInt32(reader["id"]);
                    detalle.ordenDeTrabajo = Convert.ToInt32(reader["ordenDeTrabajo"]);
                    detalle.insumo = Convert.ToInt32(reader["insumo"]);
                    detalle.cantidad = Convert.ToDecimal(reader["cantidad"]);
                    result.Add(detalle);
                }
                connection.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public static void InsertDetalleOrdenTrabajo(int ordenDeTrabajo, int insumo, decimal cantidad)
        {
            try
            {
                string conexion = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                SqlConnection connection = new SqlConnection(conexion);
                SqlCommand command = new SqlCommand("InsertDetalleOrdenTrabajo", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ordenDeTrabajo", ordenDeTrabajo);
                command.Parameters.AddWithValue("@insumo", insumo);
                command.Parameters.AddWithValue("@cantidad", cantidad);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void UpdateDetalleOrdenTrabajo(int id, int ordenDeTrabajo, int insumo, decimal cantidad)
        {
            try
            {
                string conexion = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                SqlConnection connection = new SqlConnection(conexion);
                SqlCommand command = new SqlCommand("UpdateDetalleOrdenTrabajo", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@ordenDeTrabajo", ordenDeTrabajo);
                command.Parameters.AddWithValue("@insumo", insumo);
                command.Parameters.AddWithValue("@cantidad", cantidad);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DetalleOrdenTrabajo GetById(int id)
        {
            DetalleOrdenTrabajo result = new DetalleOrdenTrabajo();
            try
            {
                string conexion = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                SqlConnection connection = new SqlConnection(conexion);
                SqlCommand command = new SqlCommand("GetByIDDetalleOrdenTrabajo", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result = new DetalleOrdenTrabajo(
                        Convert.ToInt32(reader["id"]),
                        Convert.ToInt32(reader["ordenDeTrabajo"]),
                        Convert.ToInt32(reader["insumo"]),
                        Convert.ToDecimal(reader["cantidad"])
                    );
                }
                connection.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }


        public static List<int> GetAllInsumoIds()
        {
            var insumoIds = new List<int>();
            try
            {
                string conexion = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(conexion))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT idInsumo FROM insumo", connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        insumoIds.Add(reader.GetInt32(0));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("error al cargar los insumos");
            }
            return insumoIds;
        }

        public static List<int> GetAllOrdenTrabajoIds()
        {
            var ordenIds = new List<int>();
            try
            {
                string conexion = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(conexion))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT id FROM OrdenDeTrabajo", connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        ordenIds.Add(reader.GetInt32(0));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("error las ordentrabajo");
            }
            return ordenIds;
        }

    }
}
