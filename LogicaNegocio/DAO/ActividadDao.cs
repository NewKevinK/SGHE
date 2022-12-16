using MySql.Data.MySqlClient;
using SGHE.ConexionBaseDatos;
using SGHE.LogicaNegocio.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGHE.LogicaNegocio.DAO
{
    public class ActividadDao
    {

        #region QUERYS

        private static readonly string QUERY_RECUPERAR_EXPERIENCIAS_EDUCATIVAS = "SELECT * FROM experienciaeducativa";

        private static readonly string QUERY_RECUPERAR_EE_PERIODO_CARRERA = 
            "SELECT idEE, NRC, nombre, creditos, modalidad, idPeriodo, idDocente, idCarrera " +
            "FROM experienciaeducativa WHERE idPeriodo = @idPeriodo AND idCarrera = @idCarrera";

        private static readonly string QUERY_REGISTRAR_EE = 
            "INSERT INTO experienciaeducativa(nRC, nombre, creditos, modalidad, idPeriodo, idDocente) " +
            "VALUES (@idEE, @nRC, @nombre, @creditos, @modalidad, @idPeriodo, @idDocente)";

        #endregion QUERYS

        public List<ExperienciaEducativa> RecuperarExperienciasEducativas()
        {
            List<ExperienciaEducativa> listaExperiencias = new List<ExperienciaEducativa>();
            MySqlConnection conexionBD = ConexionBD.ObtenerConexion();
            if (conexionBD != null)
            {
                try
                {
                    MySqlCommand mySqlCommand = new MySqlCommand(QUERY_RECUPERAR_EXPERIENCIAS_EDUCATIVAS, conexionBD);
                    MySqlDataReader respuestaBD = mySqlCommand.ExecuteReader();
                    while (respuestaBD.Read())
                    {
                        ExperienciaEducativa experiencia = new ExperienciaEducativa();
                        experiencia.IdEE = ((respuestaBD.IsDBNull(0)) ? 0 : respuestaBD.GetInt32(0));
                        experiencia.NRC = ((respuestaBD.IsDBNull(1)) ? "" : respuestaBD.GetString(1));
                        experiencia.Nombre = ((respuestaBD.IsDBNull(2)) ? "" : respuestaBD.GetString(2));
                        experiencia.Creditos = ((respuestaBD.IsDBNull(3)) ? 0 : respuestaBD.GetInt32(3));
                        experiencia.Modalidad = ((respuestaBD.IsDBNull(4)) ? "" : respuestaBD.GetString(4));
                        experiencia.IdPeriodo = ((respuestaBD.IsDBNull(5)) ? 0 : respuestaBD.GetInt32(5));
                        experiencia.IdPeriodo = ((respuestaBD.IsDBNull(6)) ? 0 : respuestaBD.GetInt32(6));
                        listaExperiencias.Add(experiencia);
                    }
                }
                catch (Exception e)
                {
                    listaExperiencias = null;
                    Console.WriteLine(e.Message);
                }

            }
            return listaExperiencias;
        }

        public string RegistrarExperienciaEducativa(Actividad actividad)
        {
            MySqlConnection conexionBD = ConexionBD.ObtenerConexion();
            string mensaje = "";
            if (conexionBD != null)
            {
                try
                {
                    MySqlCommand mySqlCommand = new MySqlCommand(QUERY_REGISTRAR_EE, conexionBD);
                    mySqlCommand.Parameters.AddWithValue("@nRC", actividad.NRC);
                    mySqlCommand.Parameters.AddWithValue("@nombre", actividad.Nombre);
                    mySqlCommand.Parameters.AddWithValue("@creditos", actividad.Creditos);
                    mySqlCommand.Parameters.AddWithValue("@modalidad", actividad.Modalidad);
                    mySqlCommand.Parameters.AddWithValue("@idPeriodo", actividad.IdPeriodo);
                    mySqlCommand.Parameters.AddWithValue("@idDocente", actividad.IdDocente);
                    mySqlCommand.Prepare();
                    if (mySqlCommand.ExecuteNonQuery() > 0)
                    {
                        mensaje = "Experiencia educativa registrada con éxito";
                    }
                    else
                    {
                        mensaje = "La experiencia educativa no ha podido registrarse";
                    }

                }
                catch (Exception e)
                {
                    mensaje = "ha ocurrido un error, por favor intentelo más tarde";
                }
            }

            return mensaje;
        }

        public List<ExperienciaEducativa> RecuperarExperienciasEducativasPorPeriodoCarrera(int idPeriodo, int idCarrera)
        {
            List<ExperienciaEducativa> listaEEs = new List<ExperienciaEducativa>();
            MySqlConnection conexionBD = ConexionBD.ObtenerConexion();
            if (conexionBD != null)
            {
                try
                {
                    MySqlCommand mySqlCommand = new MySqlCommand(QUERY_RECUPERAR_EE_PERIODO_CARRERA, conexionBD);
                    mySqlCommand.Parameters.AddWithValue("@idPeriodo", idPeriodo);
                    mySqlCommand.Parameters.AddWithValue("@idCarrera", idCarrera);
                    MySqlDataReader respuestaBD = mySqlCommand.ExecuteReader();
                    while (respuestaBD.Read())
                    {
                        ExperienciaEducativa ee = new();
                        ee.IdEE = respuestaBD.GetInt32(0);
                        ee.NRC = respuestaBD.GetString(1);
                        ee.Nombre = respuestaBD.GetString(2);
                        ee.Creditos = respuestaBD.GetInt32(3);
                        ee.Modalidad = respuestaBD.GetString(4);
                        ee.IdPeriodo = respuestaBD.GetInt32(5);
                        ee.IdDocente = respuestaBD.GetInt32(6);
                        ee.IdCarrera = respuestaBD.GetInt32(7);

                        listaEEs.Add(ee);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return listaEEs;
        }
    }
}
