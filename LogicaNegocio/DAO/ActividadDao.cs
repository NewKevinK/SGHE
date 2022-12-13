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
        public string RegistrarExperienciaEducativa(Actividad actividad)
        {
            MySqlConnection conexionBD = ConexionBD.ObtenerConexion();
            string mensaje = "";
            if (conexionBD != null)
            {
                try
                {
                    string sql = "INSERT INTO experienciaeducativa(idEE, nRC, nombre, creditos, modalidad, idPeriodo, idDocente) VALUES (@idEE, @nRC, @nombre, @creditos, @modalidad, @idPeriodo, @idDocente)";
                    MySqlCommand mySqlCommand = new MySqlCommand(sql, conexionBD);
                    mySqlCommand.Parameters.AddWithValue("@idEE", actividad.IdEE);
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
