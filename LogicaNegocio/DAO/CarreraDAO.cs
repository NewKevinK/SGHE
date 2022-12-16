using MySql.Data.MySqlClient;
using SGHE.ConexionBaseDatos;
using SGHE.LogicaNegocio.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGHE.LogicaNegocio.DAO
{
    public class CarreraDAO
    {
        #region QUERYS

        private static readonly string QUERY_RECUPERAR_CARRERAS = "SELECT idCarrera, grado, nombre, codigoCarrera, area, idInstitucion FROM carrera";

        #endregion QUERYS

        public List<Carrera> RecuperarCarreras()
        {
            List<Carrera> listaCarreras = null;
            MySqlConnection conexionBD = ConexionBD.ObtenerConexion();
            if (conexionBD != null)
            {
                try
                {
                    MySqlCommand mySqlCommand = new MySqlCommand(QUERY_RECUPERAR_CARRERAS, conexionBD);
                    MySqlDataReader respuestaBD = mySqlCommand.ExecuteReader();
                    listaCarreras = new List<Carrera>();
                    while (respuestaBD.Read())
                    {
                        Carrera carrera = new Carrera();
                        carrera.IdCarrera = respuestaBD.GetInt32(0);
                        carrera.Grado = respuestaBD.GetString(1);
                        carrera.Nombre = respuestaBD.GetString(2);
                        carrera.CodigoCarrera = respuestaBD.GetString(3);
                        carrera.Area = respuestaBD.GetString(4);
                        carrera.IdInstitucion = respuestaBD.GetInt32(5);
                        listaCarreras.Add(carrera);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return listaCarreras;
        }
    }
}
