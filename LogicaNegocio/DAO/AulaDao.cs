using MySql.Data.MySqlClient;
using SGHE.ConexionBaseDatos;
using SGHE.LogicaNegocio.POCO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SGHE.LogicaNegocio.DAO
{
    public class AulaDao
    {

        #region QUERYS

        private static readonly string QUERY_INSERTAR_AULA = "INSERT INTO aula(codigoAula,estado,idEdificio,tipoAula) VALUES (@codigoAula,@estado,@idEdificio,@tipoAula)";

        private static readonly string QUERY_ACTUALIZAR_ESTADO_AULA = "UPDATE aula set estado=@estado where idAula=@idAula";

        private static readonly string QUERY_ACTUALIZAR_AULA = "UPDATE aula set codigoAula=@codigoAula, estado=@estado, idEdificio=@idEdificio, tipoAula=@tipoAula where idAula=@idAula";

        private static readonly string QUERY_RECUPERAR_AULA_X_CODIGO = "SELECT * FROM aula WHERE codigoAula=@codigoAula";

        private static readonly string QUERY_AULAS_POR_INSTITUCION = "SELECT idAula, codigoAula, estado, edificio.idEdificio, tipoAula " +
            "FROM aula " +
            "INNER JOIN edificio " +
            "ON aula.idEdificio = edificio.idEdificio " +
            "INNER JOIN institucion " +
            "ON edificio.idInstitucion = institucion.idInstitucion " +
            "WHERE institucion.idInstitucion = @idInstitucion";

        #endregion QUERYS

        public List<Aula> RecuperarAulas()
        {

            List<Aula> listaAulas = new List<Aula>();
            MySqlConnection conexionBD = ConexionBD.ObtenerConexion();
            if (conexionBD != null)
            {
                try
                {
                    string sql = "SELECT * FROM aula";
                    MySqlCommand mySqlCommand = new MySqlCommand(sql, conexionBD);
                    MySqlDataReader respuestaBD = mySqlCommand.ExecuteReader();
                    while (respuestaBD.Read())
                    {
                        Aula recuperarAula = new Aula();
                        recuperarAula.IdAula = ((respuestaBD.IsDBNull(0)) ? 0 : respuestaBD.GetInt32(0));
                        recuperarAula.CodigoAula = ((respuestaBD.IsDBNull(1)) ? "" : respuestaBD.GetString(1));
                        recuperarAula.Estado = ((respuestaBD.IsDBNull(2)) ? "" : respuestaBD.GetString(2));
                        recuperarAula.IdEdificio = ((respuestaBD.IsDBNull(3)) ? 0 : respuestaBD.GetInt32(3));
                        recuperarAula.TipoAula = ((respuestaBD.IsDBNull(4)) ? "" : respuestaBD.GetString(4));
                        listaAulas.Add(recuperarAula);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
            return listaAulas;
        }

        public string AgregarAula(Aula aula)
        {
            MySqlConnection conexionBD = ConexionBD.ObtenerConexion();
            string mensaje = "";
            if (conexionBD != null)
            {
                try
                {
                    string sql = QUERY_INSERTAR_AULA;
                    MySqlCommand mySqlCommand = new MySqlCommand(sql, conexionBD);
                    mySqlCommand.Parameters.AddWithValue("@codigoAula", aula.CodigoAula);
                    mySqlCommand.Parameters.AddWithValue("@estado", "Disponible");
                    mySqlCommand.Parameters.AddWithValue("@idEdificio", aula.IdEdificio);
                    mySqlCommand.Parameters.AddWithValue("@tipoAula", aula.TipoAula);
                    mySqlCommand.Prepare();
                    if (mySqlCommand.ExecuteNonQuery() > 0)
                    {
                        mensaje = "La aula se ha registrado con éxito";
                    }
                    else
                    {
                        mensaje = "La aula no ha podido registrarse";
                    }

                }
                catch (Exception e)
                {
                    mensaje = "La aula no ha podido registrarse";
                }
            }

            return mensaje;

        }

        public int ActualizarEstadoAula(string idAula)
        {
            MySqlConnection conexionBD = ConexionBD.ObtenerConexion();
            int confirmacion = 0;
            if (conexionBD != null)
            {
                try
                {
                    string sql = QUERY_ACTUALIZAR_ESTADO_AULA;
                    MySqlCommand mySqlCommand = new MySqlCommand(sql, conexionBD);
                    mySqlCommand.Parameters.AddWithValue("@estado", idAula);
                    int filasAfectadas = mySqlCommand.ExecuteNonQuery();
                    if (filasAfectadas > 0)
                    {
                        confirmacion = 1;
                    }
                    else
                    {
                        confirmacion = 2;
                    }
                }
                catch (Exception ex)
                {
                    confirmacion = 3;
                }

            }
            return confirmacion;
        }

        public int ActualizarAula(int idAula, Aula aula)
        {
            MySqlConnection conexionBD = ConexionBD.ObtenerConexion();
            int confirmacion = 0;
            if (conexionBD != null)
            {
                try
                {
                    string sql = QUERY_ACTUALIZAR_AULA;
                    MySqlCommand mySqlCommand = new MySqlCommand(sql, conexionBD);
                    mySqlCommand.Parameters.AddWithValue("@codigoAula", aula.CodigoAula);
                    mySqlCommand.Parameters.AddWithValue("@estado", aula.Estado);
                    mySqlCommand.Parameters.AddWithValue("@idEdificio", aula.IdEdificio);
                    mySqlCommand.Parameters.AddWithValue("@tipoAula", aula.TipoAula);
                    mySqlCommand.Parameters.AddWithValue("@idAula", idAula);
                    int filasAfectadas = mySqlCommand.ExecuteNonQuery();
                    if (filasAfectadas > 0)
                    {
                        confirmacion = 1;
                    }
                    else
                    {
                        confirmacion = 2;
                    }
                }
                catch (Exception ex)
                {
                    confirmacion = 3;
                }

            }
            return confirmacion;
        }

        public Aula RecuperarAulaPorCodigo(String codigoAula)
        {
            Aula aula = new Aula();
            MySqlConnection conexionBD = ConexionBD.ObtenerConexion();
            if (conexionBD != null)
            {
                try
                {
                    string sql = QUERY_RECUPERAR_AULA_X_CODIGO;
                    MySqlCommand mySqlCommand = new MySqlCommand(sql, conexionBD);
                    mySqlCommand.Parameters.AddWithValue("@codigoAula", codigoAula);
                    MySqlDataReader respuestaBD = mySqlCommand.ExecuteReader();
                    while (respuestaBD.Read())
                    {
                        aula.IdAula = ((respuestaBD.IsDBNull(0)) ? 0 : respuestaBD.GetInt32(0));
                        aula.CodigoAula = ((respuestaBD.IsDBNull(1)) ? "" : respuestaBD.GetString(1));
                        aula.Estado = ((respuestaBD.IsDBNull(2)) ? "" : respuestaBD.GetString(2));
                        aula.IdEdificio = ((respuestaBD.IsDBNull(3)) ? 0 : respuestaBD.GetInt32(3));
                        aula.TipoAula = ((respuestaBD.IsDBNull(4)) ? "" : respuestaBD.GetString(4));
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return aula;
        }

        public List<Aula> RecuperarAulasPorInstitucion(int idInstitucion)
        {
            List<Aula> listaAulas = null;
            MySqlConnection conexionBD = ConexionBD.ObtenerConexion();
            if (conexionBD != null)
            {
                try
                {
                    string sql = QUERY_AULAS_POR_INSTITUCION;
                    MySqlCommand mySqlCommand = new MySqlCommand(sql, conexionBD);
                    mySqlCommand.Parameters.AddWithValue("@idInstitucion", idInstitucion);
                    MySqlDataReader respuestaBD = mySqlCommand.ExecuteReader();
                    listaAulas = new List<Aula>();
                    while (respuestaBD.Read())
                    {
                        Aula recuperarAula = new Aula();
                        recuperarAula.IdAula = ((respuestaBD.IsDBNull(0)) ? 0 : respuestaBD.GetInt32(0));
                        recuperarAula.CodigoAula = ((respuestaBD.IsDBNull(1)) ? "" : respuestaBD.GetString(1));
                        recuperarAula.Estado = ((respuestaBD.IsDBNull(2)) ? "" : respuestaBD.GetString(2));
                        recuperarAula.IdEdificio = ((respuestaBD.IsDBNull(3)) ? 0 : respuestaBD.GetInt32(3));
                        recuperarAula.TipoAula = ((respuestaBD.IsDBNull(4)) ? "" : respuestaBD.GetString(4));
                        listaAulas.Add(recuperarAula);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return listaAulas;
        }
    }
}

