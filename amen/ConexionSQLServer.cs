using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace amen
{
    internal class ConexionMySQL
    {
        private string connectionString = "server=localhost;database=integracion;uid=root;pwd=TuPassword;";

        public void Conectar()
        {
            using (MySqlConnection conexion = new MySqlConnection(connectionString))
            {
                try
                {
                    conexion.Open();
                    MessageBox.Show("Conexión abierta con MySQL");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        public MySqlConnection ObtenerConexion()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
