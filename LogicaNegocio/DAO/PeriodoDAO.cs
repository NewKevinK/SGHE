using MySql.Data.MySqlClient;
using SGHE.ConexionBaseDatos;
using SGHE.LogicaNegocio.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGHE.LogicaNegocio.DAO
{
    public class PeriodoDAO
    {
        #region QUERYS

        private static readonly string QUERY_RECUPERAR_PERIODOS = "SELECT idPeriodo, nombrePeriodo, fechaInicio, fechaFin, estado FROM periodo";
        private static readonly string QUERY_RECUPERAR_PERIODO_ACTUAL = "SELECT idPeriodo, nombrePeriodo, fechaInicio, fechaFin, estado FROM periodo WHERE estado = \"En Curso\"";

        #endregion QUERYS

        public List<Periodo> RecuperarPeriodos()
        {
            List<Periodo> listaPeriodos = null;
            MySqlConnection conexionBD = ConexionBD.ObtenerConexion();
            if (conexionBD != null)
            {
                try
                {
                    MySqlCommand mySqlCommand = new MySqlCommand(QUERY_RECUPERAR_PERIODOS, conexionBD);
                    MySqlDataReader respuestaBD = mySqlCommand.ExecuteReader();
                    listaPeriodos = new List<Periodo>();
                    while (respuestaBD.Read())
                    {
                        Periodo periodo = new Periodo();
                        periodo.IdPeriodo = respuestaBD.GetInt32(0);
                        periodo.NombrePeriodo = respuestaBD.GetString(1);
                        periodo.FechaInicio = respuestaBD.GetDateTime(2);
                        periodo.FechaFin = respuestaBD.GetDateTime(3);
                        periodo.Estado = respuestaBD.GetString(4);
                        listaPeriodos.Add(periodo);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return listaPeriodos;
        }

        public Periodo RecuperarPeriodoActual()
        {
            Periodo periodo = null;
            MySqlConnection conexionBD = ConexionBD.ObtenerConexion();
            if (conexionBD != null)
            {
                try
                {
                    MySqlCommand mySqlCommand = new MySqlCommand(QUERY_RECUPERAR_PERIODO_ACTUAL, conexionBD);
                    MySqlDataReader respuestaBD = mySqlCommand.ExecuteReader();
                    periodo = new Periodo();
                    while (respuestaBD.Read())
                    {
                        periodo.IdPeriodo = respuestaBD.GetInt32(0);
                        periodo.NombrePeriodo = respuestaBD.GetString(1);
                        periodo.FechaInicio = respuestaBD.GetDateTime(2);
                        periodo.FechaFin = respuestaBD.GetDateTime(3);
                        periodo.Estado = respuestaBD.GetString(4);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return periodo;
        }
    }
}
