using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelExpress
{/// <summary>
/// Sebastian Velasquez
/// Samuel Galvis
/// Mateo Becerra
/// Alejandro Ramirez 
/// 22/05/2023
/// Alquiler y Reserva de un Hotel
/// </summary>
    internal class clsRegistro
    {
        SqlConnection coneccion = new SqlConnection("server=SEBASZZ ; database = dboHotelExpress; INTEGRATED SECURITY = true");

        public int intDocumento { get; set; }
        public string strNombre { get; set; }
        public string strApellido { get; set; }
        public string strTipoDocumento { get; set; }
        public double precioHabitacion { get; set; }
        public double precioCamas { get; set; }
        public double precioComidas { get; set; }
        public double precioTotal { get; set; }
        public double precioPersonas { get; set; }
        public double precioDias { get; set; }

        public clsRegistro() { }

        // Constructor que inicializa las propiedades intDocumento, strNombre, strApellido y strTipoDocumento.
        public clsRegistro(int intDocumento, string strNombre, string strApellido, string strTipoDocumento)
        {
            this.intDocumento = intDocumento;
            this.strNombre = strNombre;
            this.strApellido = strApellido;
            this.strTipoDocumento = strTipoDocumento;
        }

        // Constructor que inicializa las propiedades relacionadas con los precios.
        public clsRegistro(double precioHabitacion, double precioCamas, double precioComidas, double precioTotal, double precioPersonas, double precioDias)
        {
            this.precioHabitacion = precioHabitacion;
            this.precioCamas = precioCamas;
            this.precioComidas = precioComidas;
            this.precioTotal = precioTotal;
            this.precioPersonas = precioPersonas;
            this.precioDias = precioDias;
        }

        // Método para insertar un nuevo registro en la base de datos.
        public bool insertarDato()
        {
            try
            {
                // Establecer la conexión con la base de datos
                SqlConnection coneccion = new SqlConnection("server=SEBASZZ;database=dboHotelExpress;INTEGRATED SECURITY = true");
                coneccion.Open();
                // Definir la consulta de inserción
                string insertar = "INSERT INTO tblRegistroFinal VALUES(@intDocumento, @strNombre, @strApellido, @strTipoDocumento)";

                // Crear el comando SQL y asignar los parámetros
                SqlCommand sql = new SqlCommand(insertar, coneccion);
                sql.Parameters.AddWithValue("@intDocumento", this.intDocumento);
                sql.Parameters.AddWithValue("@strNombre", this.strNombre);
                sql.Parameters.AddWithValue("@strApellido", this.strApellido);
                sql.Parameters.AddWithValue("@strTipoDocumento", this.strTipoDocumento);

                // Ejecutar la consulta de inserción
                sql.ExecuteNonQuery();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                coneccion.Close();
            }
        }

        // Método para consultar todos los datos de la tabla tblRegistroFinal.
        public DataTable consultarDatos()
        {
            try
            {
                // Establecer la conexión con la base de datos
                coneccion.Open();

                // Crear un objeto DataTable para almacenar los resultados de la consulta
                DataTable dt = new DataTable();

                // Definir la consulta SQL para seleccionar todos los datos de la tabla tblRegistroFinal
                string consulta = "SELECT * FROM tblRegistroFinal";

                // Crear el comando SQL y asignar la consulta y la conexión
                SqlCommand cmd = new SqlCommand(consulta, coneccion);

                // Crear un SqlDataAdapter para ejecutar el comando y llenar el DataTable con los resultados
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                coneccion.Close();
            }
        }

        // Método para eliminar un registro de la tabla tblRegistroFinal.
        public bool eliminarDatos()
        {
            try
            {
                // Establecer la conexión con la base de datos
                coneccion.Open();

                // Definir la consulta SQL para eliminar el registro con el número de documento especificado
                string eliminar = "DELETE FROM tblRegistroFinal WHERE intDocumento = @intDocumento";

                // Crear el comando SQL y asignar la consulta y la conexión
                SqlCommand sql = new SqlCommand(eliminar, coneccion);

                // Asignar el parámetro para el número de documento desde el campo de la instancia
                sql.Parameters.AddWithValue("@intDocumento", this.intDocumento);

                // Ejecutar la consulta de eliminación
                sql.ExecuteNonQuery();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                coneccion.Close();
            }
        }

        // Método para modificar un registro en la tabla tblRegistroFinal.
        public bool modificarDato()
        {
            try
            {
                coneccion.Open();

                // Definir la consulta SQL para actualizar los datos del registro con el número de documento especificado
                string insertar = "UPDATE tblRegistroFinal SET strNombre = @strNombre, strApellido = @strApellido, strTipoDocumento = @strTipoDocumento WHERE intDocumento = @intDocumento";

                // Crear el comando SQL y asignar la consulta y la conexión
                SqlCommand sql = new SqlCommand(insertar, coneccion);

                sql.Parameters.AddWithValue("@intDocumento", this.intDocumento);
                sql.Parameters.AddWithValue("@strNombre", this.strNombre);
                sql.Parameters.AddWithValue("@strApellido", this.strApellido);
                sql.Parameters.AddWithValue("@strTipoDocumento", this.strTipoDocumento);

                // Ejecutar la consulta de actualización
                sql.ExecuteNonQuery();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                coneccion.Close();
            }
        }

        // Método para seleccionar un registro de la tabla tblRegistroFinal.
        public DataTable seleccionarDato()
        {
            try
            {
                coneccion.Open();

                // Crear un objeto DataTable para almacenar los resultados de la consulta
                DataTable dt = new DataTable();

                // Definir la consulta SQL para seleccionar el registro con el número de documento especificado
                string seleccionar = "SELECT * FROM tblRegistroFinal WHERE intDocumento = @intDocumento";

                // Crear el comando SQL y asignar la consulta y la conexión
                SqlCommand cmd = new SqlCommand(seleccionar, coneccion);

                // Asignar el parámetro para el número de documento
                cmd.Parameters.AddWithValue("@intDocumento", this.intDocumento);

                // Crear un SqlDataAdapter para ejecutar el comando y llenar el DataTable con los resultados
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                coneccion.Close();
            }
        }

        // Método estático para calcular el precio total de una estadía en el hotel.
        public static double CalcularPago(double cantidadComidas, double cantidadCamas, double cantidadDias, double cantidadPersonas)
        {
            double precioHabitacion;
            double precioCamas;
            double precioComidas;
            double precioTotal;
            double precioPersonas;
            double precioDias;

            precioHabitacion = 500000;
            precioCamas = 200 * Convert.ToInt32(cantidadCamas);
            precioComidas = 20 * Convert.ToInt32(cantidadComidas);
            precioPersonas = 200 * Convert.ToInt32(cantidadPersonas);
            precioDias = 200000 * Convert.ToInt32(cantidadDias);

            precioTotal = precioHabitacion + precioCamas + precioComidas + precioPersonas + precioDias;

            return precioTotal;
        }
    }
}
