using MySql.Data.MySqlClient;
using SGHE.ConexionBaseDatos;
using SGHE.LogicaNegocio.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGHE.LogicaNegocio.DAO
{
    class UsuarioDao

    {
        public Boolean inicioSesion()
        {
            MySqlConnection conexionBD = ConexionBD.ObtenerConexion();
            if (conexionBD != null)
            {
                try
                {
                    string sql = "SELECT idUsuario FROM usuario WHERE email = ? ";
                    MySqlCommand mySqlCommand = new MySqlCommand(sql, conexionBD);
                    MySqlDataReader respuestaBD = mySqlCommand.ExecuteReader();
                    while (respuestaBD.Read())
                    {
                        /*recuperarAula.IdAula = ((respuestaBD.IsDBNull(0)) ? 0 : respuestaBD.GetInt32(0));
                        recuperarAula.CodigoAula = ((respuestaBD.IsDBNull(1)) ? "" : respuestaBD.GetString(1));
                        recuperarAula.Estado = ((respuestaBD.IsDBNull(2)) ? "" : respuestaBD.GetString(2));
                        recuperarAula.IdEdificio = ((respuestaBD.IsDBNull(3)) ? 0 : respuestaBD.GetInt32(3));
                        recuperarAula.TipoAula = ((respuestaBD.IsDBNull(4)) ? "" : respuestaBD.GetString(4));
                        listaAulas.Add(recuperarAula); */
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
            return true;
        }
    }
}
