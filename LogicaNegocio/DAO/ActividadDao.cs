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
        public List<ExperienciaEducativa> RecuperarExperienciasEducativas()
        {
            List<ExperienciaEducativa> listaExperiencias = new List<ExperienciaEducativa>();
            MySqlConnection conexionBD = ConexionBD.ObtenerConexion();
            if (conexionBD != null)
            {
                try
                {
                    string sql = "SELECT * FROM experienciaeducativa";
                    MySqlCommand mySqlCommand = new MySqlCommand(sql, conexionBD);
                    MySqlDataReader respuestaBD = mySqlCommand.ExecuteReader();
                    while (respuestaBD.Read())
                    {
                        ExperienciaEducativa experiencia = new ExperienciaEducativa();
                        experiencia.IdEE = ((respuestaBD.IsDBNull(0)) ? 0 : respuestaBD.GetInt32(0));
                        experiencia.NRC1 = ((respuestaBD.IsDBNull(1)) ? "" : respuestaBD.GetString(1));
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
                    string sql = "INSERT INTO experienciaeducativa(nRC, nombre, creditos, modalidad, idPeriodo, idDocente) VALUES (@idEE, @nRC, @nombre, @creditos, @modalidad, @idPeriodo, @idDocente)";
                    MySqlCommand mySqlCommand = new MySqlCommand(sql, conexionBD);
                    mySqlCommand.Parameters.AddWithValue("@nRC", actividad.NRC1);
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
    }
}
