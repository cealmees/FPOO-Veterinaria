using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Veterinaria_FPOO
{
    public class GenerarConexionMySQL
    {

        protected MySqlConnection Conexion { get; set; }
        public GenerarConexionMySQL()
        {
            Conexion = new MySqlConnection();
            try
            {
                string Datasource = "localhost";
                string UserName = "root";
                string Password = "XxxCcc583fake22!";
                string SslMode = "None";
                string DB = "citas";

                string Comando = ("datasource=" + Datasource + ";username=" + UserName + ";password=" + Password + ";database=" + DB + ";SslMode=" + SslMode + "");

                MySqlConnection ConexionIntento = new MySqlConnection(Comando);

                Conexion = ConexionIntento;
            }

            catch (Exception) { }
        }

    }

    public class GenerarCita : GenerarConexionMySQL
    {
        public void insertarDatos(string CNombre, string CApellido, string CFecha, string CHora)
        {

            try
            {
                Conexion.Open();
                string comando = "INSERT INTO tablaCitas (ClienteNombre, ClienteApellido, CitaFecha, CitaHora) VALUES ('" + CNombre + "','" + CApellido + "','" + CFecha + "','" + CHora + "')";
                MySqlCommand nuevoCommando = Conexion.CreateCommand();
                nuevoCommando.CommandText = comando;
                nuevoCommando.ExecuteNonQuery();
                Conexion.Close();
            }
            catch (Exception) { }

        }
    }

    public class GenerarProductos : GenerarConexionMySQL
    {
        public void insertarProductos(string CategoriaProducto, float PrecioProducto, float CantidadProduto)
        {
            try
            {
                Conexion.Open();
                DateTime.Now.ToString("yyyy-MM-dd");
                string comando = "INSERT INTO productosVeterinaria (CategoriaProducto, PrecioProducto, CantidadProducto, FechaIngreso, HoraIngreso) VALUES ('" + CategoriaProducto + "','" + PrecioProducto + "','" + CantidadProduto + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + DateTime.Now.ToString("HH:mm:ss") + "')";
                MySqlCommand nuevoCommando = Conexion.CreateCommand();
                nuevoCommando.CommandText = comando;
                nuevoCommando.ExecuteNonQuery();
                Conexion.Close();
            }
            catch (Exception) { }
        }
    }

    public class MostrarMySQL : GenerarConexionMySQL
    {
        public List<MostrarBase> mostrarLV()
        {
            List<MostrarBase> ListaMySQLProductos = new List<MostrarBase>();

            using (Conexion)
            {
                Conexion.Open();
                MySqlCommand leerComando = new MySqlCommand("SELECT *FROM productosVeterinaria", Conexion);
                using (MySqlDataReader lector = leerComando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        ListaMySQLProductos.Add(new MostrarBase
                        {
                            ProductID = lector.GetInt32(0),
                            CategoriaProducto = lector.GetString(1),
                            PrecioProducto = lector.GetFloat(2),
                            CantidadProducto = lector.GetFloat(3),
                            FechaIngreso = lector.GetString(4),
                            HoraIngreso = lector.GetString(5)

                        });
                    }
                }
            }
            return ListaMySQLProductos;
        }
    }


    public class MostrarCitas : GenerarConexionMySQL
    {
        public List<MostrarProximasCitas> mostrarLV()
        {
            List<MostrarProximasCitas> ListaCitas = new List<MostrarProximasCitas>();

            using (Conexion)
            {
                Conexion.Open();
                MySqlCommand leerComando = new MySqlCommand("SELECT *FROM tablacitas", Conexion);
                using (MySqlDataReader lector = leerComando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        ListaCitas.Add(new MostrarProximasCitas
                        {
                            CitaID = lector.GetInt32(0),
                            ClienteNombre = lector.GetString(1),
                            ClienteApellido = lector.GetString(2),
                            CitaFecha = lector.GetString(3),
                            CitaHora = lector.GetString(4)

                        });
                    }
                }
            }
            return ListaCitas;
        }
    }
}
