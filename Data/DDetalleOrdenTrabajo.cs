using Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Datos
{
    public class DDetalleOrdenTrabajo
    {
        public static void DeleteDetalleOrdenTrabajo(int id)
        {
            try
            {
                string conexion = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(conexion))
                {
                    SqlCommand command = new SqlCommand("DeleteDetalleOrdenTrabajo", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    command.Parameters.AddWithValue("@id", id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar: " + ex.Message, ex);
            }
        }

        public static Insumo GetInsumoByNombre(string nombre)
        {
            Insumo insumo = null;
            try
            {
                string conexion = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(conexion))
                {
                    SqlCommand command = new SqlCommand("spGetInsumoByNombre", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    command.Parameters.AddWithValue("@detalle", nombre);
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
                throw new Exception("Error al obtener insumo: " + ex.Message, ex);
            }
            return insumo;
        }

        public static List<Insumo> GetAllInsumos()
        {
            var result = new List<Insumo>();
            try
            {
                string conexion = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(conexion))
                {
                    SqlCommand command = new SqlCommand("spGetAllInsumos", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        result.Add(new Insumo
                        {
                            idInsumo = Convert.ToInt32(reader["idInsumo"]),
                            detalle = reader["detalle"].ToString(),
                            otros = reader["otros"] as string,
                            cuenta = reader["cuenta"] as string
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener insumos: " + ex.Message, ex);
            }
            return result;
        }

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
                        result.Add(new DetalleOrdenTrabajo(
                            Convert.ToInt32(reader["id"]),
                            GetOrdenTrabajoById(Convert.ToInt32(reader["ordenDeTrabajo"])),
                            GetInsumoById(Convert.ToInt32(reader["insumo"])),
                            Convert.ToDecimal(reader["cantidad"])
                        ));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener detalles: " + ex.Message, ex);
            }
            return result;
        }

        public static void InsertDetalleOrdenTrabajo(OrdenTrabajo ordenDeTrabajo, Insumo insumo, decimal cantidad)
        {
            try
            {
                string conexion = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(conexion))
                {
                    SqlCommand command = new SqlCommand("InsertDetalleOrdenTrabajo", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    command.Parameters.AddWithValue("@ordenDeTrabajo", ordenDeTrabajo.id);
                    command.Parameters.AddWithValue("@insumo", insumo.idInsumo);
                    command.Parameters.AddWithValue("@cantidad", cantidad);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar detalle: " + ex.Message, ex);
            }
        }

        public static void UpdateDetalleOrdenTrabajo(int id, OrdenTrabajo ordenDeTrabajo, Insumo insumo, decimal cantidad)
        {
            try
            {
                string conexion = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(conexion))
                {
                    SqlCommand command = new SqlCommand("UpdateDetalleOrdenTrabajo", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
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
                throw new Exception("Error al actualizar detalle: " + ex.Message, ex);
            }
        }

        public static DetalleOrdenTrabajo GetById(int id)
        {
            DetalleOrdenTrabajo result = null;
            try
            {
                string conexion = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(conexion))
                {
                    SqlCommand command = new SqlCommand("GetByIDDetalleOrdenTrabajo", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    command.Parameters.AddWithValue("@id", id);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
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
                throw new Exception("Error al obtener detalle por id: " + ex.Message, ex);
            }
            return result;
        }

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
                            centroDeCosto = new CentroCosto { idCentro = Convert.ToInt32(reader["centroDeCosto"]) }
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener orden de trabajo: " + ex.Message, ex);
            }
            return ordenTrabajo;
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
                throw new Exception("Error al obtener ids de insumos: " + ex.Message, ex);
            }
            return result;
        }

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
                throw new Exception("Error al obtener insumo: " + ex.Message, ex);
            }
            return insumo;
        }
    }
}
