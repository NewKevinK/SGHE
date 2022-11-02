using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SGHE.ConexionBD
{
    public interface IConexionBD
    {
        private static string SERVIDOR;
        private static string PUERTO;
        private static string BASE_DATOS;
        private static string USUARIO_BD;
        private static string PASSWORD;

        public MySqlConnection ObtenerConexion()
        {
            throw new NotImplementedException();
        }
    }
}
