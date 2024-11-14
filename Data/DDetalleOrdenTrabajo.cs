using Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;

namespace Datos
{
    public class DDetalleOrdenTrabajo
    {
        // Método para eliminar un detalle de orden de trabajo
        public static void DeleteDetalleOrdenTrabajo(int id)
        {
            try
            {
                string conexion = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

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

        // Método para obtener todos los detalles de la orden de trabajo
        public static List<DetalleOrdenTrabajo> GetAll()
        {
            var result = new List<DetalleOrdenTrabajo>();
            try
            {
                string conexion = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(conexion))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("GetAllDetalleOrdenTrabajo", connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var detalle = new DetalleOrdenTrabajo(
                            Convert.ToInt32(reader["id"]),
                            GetOrdenTrabajoById(Convert.ToInt32(reader["ordenDeTrabajo"])),
                            GetInsumoById(Convert.ToInt32(reader["insumo"])),
                            Convert.ToDecimal(reader["cantidad"])
                        );
                        result.Add(detalle);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los detalles de la orden de trabajo: " + ex.Message, ex);
            }
            return result;
        }

        // Método para insertar un nuevo detalle de orden de trabajo
        public static void InsertDetalleOrdenTrabajo(OrdenTrabajo ordenDeTrabajo, Insumo insumo, decimal cantidad)
        {
            try
            {
                string conexion = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(conexion))
                {
                    SqlCommand command = new SqlCommand("InsertDetalleOrdenTrabajo", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ordenDeTrabajo", ordenDeTrabajo.id);
                    command.Parameters.AddWithValue("@insumo", insumo.idInsumo);
                    command.Parameters.AddWithValue("@cantidad", cantidad);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar el detalle de la orden de trabajo: " + ex.Message, ex);
            }
        }

        // Método para actualizar un detalle de orden de trabajo
        public static void UpdateDetalleOrdenTrabajo(int id, OrdenTrabajo ordenDeTrabajo, Insumo insumo, decimal cantidad)
        {
            try
            {
                string conexion = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(conexion))
                {
                    SqlCommand command = new SqlCommand("UpdateDetalleOrdenTrabajo", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@ordenDeTrabajo", ordenDeTrabajo.id);
                    command.Parameters.AddWithValue("@insumo", insumo.idInsumo);
                    command.Parameters.AddWithValue("@cantidad", cantidad);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el detalle de la orden de trabajo: " + ex.Message, ex);
            }
        }

        // Método para obtener un detalle de orden de trabajo por su id
        public static DetalleOrdenTrabajo GetById(int id)
        {
            DetalleOrdenTrabajo result = null;
            try
            {
                string conexion = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(conexion))
                {
                    SqlCommand command = new SqlCommand("GetByIDDetalleOrdenTrabajo", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", id);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        result = new DetalleOrdenTrabajo(
                            Convert.ToInt32(reader["id"]),
                            GetOrdenTrabajoById(Convert.ToInt32(reader["ordenDeTrabajo"])),
                            GetInsumoById(Convert.ToInt32(reader["insumo"])),
                            Convert.ToDecimal(reader["cantidad"])
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el detalle de la orden de trabajo: " + ex.Message, ex);
            }
            return result;
        }

        // Método auxiliar para obtener el objeto OrdenTrabajo por id
        public static OrdenTrabajo GetOrdenTrabajoById(int id)
        {
            OrdenTrabajo ordenTrabajo = null;
            try
            {
                string conexion = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(conexion))
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM OrdenDeTrabajo WHERE id = @id", connection);
                    command.Parameters.AddWithValue("@id", id);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        ordenTrabajo = new OrdenTrabajo
                        {
                            id = Convert.ToInt32(reader["id"]),
                            fechaLote = Convert.ToDateTime(reader["fechaLote"]),
                            centroDeCosto = new CentroCosto
                            {
                                // Suponiendo que CentroCosto tiene una propiedad id
                                idCentro = Convert.ToInt32(reader["centroDeCosto"])
                            }
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la orden de trabajo: " + ex.Message, ex);
            }
            return ordenTrabajo;
        }

        public static List<int> GetAllOrdenTrabajoIds()
        {
            var result = new List<int>();
            try
            {
                string conexion = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(conexion))
                {
                    SqlCommand command = new SqlCommand("SELECT id FROM OrdenDeTrabajo", connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        result.Add(Convert.ToInt32(reader["id"]));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los ids de órdenes de trabajo: " + ex.Message, ex);
            }
            return result;
        }

        public static List<int> GetAllInsumoIds()
        {
            var result = new List<int>();
            try
            {
                string conexion = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(conexion))
                {
                    SqlCommand command = new SqlCommand("SELECT idInsumo FROM insumo", connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        result.Add(Convert.ToInt32(reader["idInsumo"]));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los ids de insumos: " + ex.Message, ex);
            }
            return result;
        }



        // Método auxiliar para obtener el objeto Insumo por id
        public static Insumo GetInsumoById(int id)
        {
            Insumo insumo = null;
            try
            {
                string conexion = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(conexion))
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM insumo WHERE idInsumo = @id", connection);
                    command.Parameters.AddWithValue("@id", id);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        insumo = new Insumo
                        {
                            idInsumo = Convert.ToInt32(reader["idInsumo"]),
                            detalle = reader["detalle"].ToString(),
                            otros = reader["otros"] as string,
                            cuenta = reader["cuenta"] as string
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el insumo: " + ex.Message, ex);
            }
            return insumo;
        }
    }
}
