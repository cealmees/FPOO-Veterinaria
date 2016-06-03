using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Veterinaria_FPOO
{
    class LogIn
    {
        //Variables globales de encapsulamiento privado

        private string userName;
        private string userPassword;

        //Constructor de clase
        public LogIn(string usuario, string clave)
        {
            userName = usuario;
            userPassword = clave;
        }

        public bool autenticarUsuario()
        {
            //return autenticar();
            return autenticarMySql();
        }

        public bool autenticarMySql()
        {
            bool aunt = false;
            try
            {
                string Conn = "datasource=localhost;username=root;password=XxxCcc583fake22!;SslMode=None";
                MySqlConnection MyConn = new MySqlConnection(Conn);
                MySqlCommand MyCommand = new MySqlCommand("select * from login.usuarios where username='" + userName + "' and password='" + userPassword + "' ;", MyConn);
                MySqlDataReader MyReader;
                MyConn.Open();
                MyReader = MyCommand.ExecuteReader();
                int count = 0;
                while (MyReader.Read())
                {
                    count++;
                }
                if (count == 1)
                {
                    aunt = true;
                }
                else if (count > 1)
                {
                    aunt = false;
                }
                else
                {
                    aunt = false;
                }
                MyConn.Close();
            }
            catch (Exception) { }

            return aunt;
        }
    }
}
