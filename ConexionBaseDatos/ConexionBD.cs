using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGHE.ConexionBaseDatos
{
    public class ConexionBD
    {
        private static string SERVIDOR = "mysql-flexible-service.mysql.database.azure.com";
        private static string PUERTO = "3306";
        private static string BASE_DATOS = "sghe";
        private static string USUARIO_BD = "s19isof";
        private static string PASSWORD = "mysql-isof2022";
        

        public static MySqlConnection ObtenerConexion()
        {
            MySqlConnection conexion;
            try
            {
                string urlConexion = string.Format("server={0};" +
                                                   "database={1};" +
                                                   "username={2};" +
                                                   "password={3};" +
                                                   "port={4};", SERVIDOR, BASE_DATOS,
                                                   USUARIO_BD, PASSWORD, PUERTO);
                conexion = new MySqlConnection(urlConexion);
                conexion.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                conexion = null;
            }
            return conexion;
        }
    }
}
