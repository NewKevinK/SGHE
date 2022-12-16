using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X509;
using SGHE.Client;
using SGHE.ConexionBaseDatos;
using SGHE.LogicaNegocio.POCO;
using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;

namespace SGHE.LogicaNegocio.DAO
{
    public class HorarioDao
    {

        #region QUERYS 

        #region QUERY_RECUPERAR_HORARIO_ALUMNO_DIASEMANA
        public static readonly string QUERY_RECUPERAR_HORARIO_ALUMNO_DIASEMANA =
            "SELECT " +
            "experienciaeducativa.idEE," +
            " experienciaeducativa.NRC," +
            " experienciaeducativa.nombre AS EE," +
            " creditos," +
            " modalidad," +
            " docenteA.nombre AS docente," +
            " docenteA.apellidoPaterno AS apellidoPaterno," +
            " docenteA.apellidoMaterno AS apellidoMaterno," +
            " horaInicio, horaFin, diaSemana, codigoAula" +
            " FROM experienciaeducativa" +
            " LEFT JOIN (SELECT idDocente, nombre, apellidoPaterno, apellidoMaterno" +
            " FROM docente JOIN usuario" +
            " ON docente.idUsuario = usuario.idUsuario)" +
            " AS docenteA" +
            " ON docenteA.idDocente = experienciaeducativa.idDocente" +
            " LEFT JOIN (SELECT idEE, horaInicio, horaFin, diaSemana, aula.codigoAula" +
            " FROM horario" +
            " JOIN aula" +
            " ON horario.idAula = aula.idAula" +
            ") AS horarioAula" +
            " ON horarioAula.idEE = experienciaeducativa.idEE" +
            " LEFT JOIN participantes" +
            " ON experienciaeducativa.idEE = participantes.idEE" +
            " LEFT JOIN periodo" +
            " ON experienciaeducativa.idPeriodo = periodo.idPeriodo" +
            " WHERE experienciaeducativa.idPeriodo = @idPeriodo AND horarioAula.diaSemana = @diaSemana AND participantes.idAlumno = @idAlumno";
        #endregion QUERY_RECUPERAR_HORARIO_ALUMNO_DIASEMANA

        #region QUERY_RECUPERAR_HORARIO_ALUMNO_SEMANAL
        public static readonly string QUERY_RECUPERAR_HORARIO_ALUMNO_SEMANAL =
            "SELECT " +
            "experienciaeducativa.idEE," +
            " experienciaeducativa.NRC," +
            " experienciaeducativa.nombre AS EE," +
            " creditos," +
            " modalidad," +
            " docenteA.nombre AS docente," +
            " docenteA.apellidoPaterno AS apellidoPaterno," +
            " docenteA.apellidoMaterno AS apellidoMaterno," +
            " horaInicio, horaFin, diaSemana, codigoAula" +
            " FROM experienciaeducativa" +
            " LEFT JOIN (SELECT idDocente, nombre, apellidoPaterno, apellidoMaterno" +
            " FROM docente JOIN usuario" +
            " ON docente.idUsuario = usuario.idUsuario)" +
            " AS docenteA" +
            " ON docenteA.idDocente = experienciaeducativa.idDocente" +
            " LEFT JOIN (SELECT idEE, horaInicio, horaFin, diaSemana, aula.codigoAula" +
            " FROM horario" +
            " JOIN aula" +
            " ON horario.idAula = aula.idAula" +
            ") AS horarioAula" +
            " ON horarioAula.idEE = experienciaeducativa.idEE" +
            " LEFT JOIN participantes" +
            " ON experienciaeducativa.idEE = participantes.idEE" +
            " LEFT JOIN periodo" +
            " ON experienciaeducativa.idPeriodo = periodo.idPeriodo" +
            " WHERE experienciaeducativa.idPeriodo = @idPeriodo AND participantes.idAlumno = @idAlumno";
        #endregion QUERY_RECUPERAR_HORARIO_ALUMNO_DIASEMANA

        #region QUERY_RECUPERAR_HORARIO_EXACTO
        private static readonly string QUERY_RECUPERAR_HORARIO_EXACTO =
            "SELECT" +
            " idHorario," +
            " horaInicio," +
            " horaFin," +
            " diaSemana," +
            " horario.idEE," +
            " idAula," +
            " nombre " +
            "FROM horario " +
            "INNER JOIN experienciaeducativa " +
            "ON horario.idEE = experienciaeducativa.idEE " +
            "WHERE idPeriodo = @idPeriodo AND diaSemana = @diaSemana AND horario.idEE = @idEE";
        #endregion QUERY_RECUPERAR_HORARIO_EXACTO

        private static readonly string QUERY_REGISTRAR_HORARIO =
            "INSERT INTO" +
            " horario(horaInicio, horaFin, diaSemana, idEE, idAula)" +
            " VALUES(@horaInicio, @horaFin, @diaSemana, @idEE, @idAula)";

        private static readonly string QUERY_ACTUALIZAR_HORARIO =
            "UPDATE horario" +
            " SET horaInicio = @horaInicio," +
            " horaFin = @horaFin," +
            " diaSemana = @diaSemana," +
            " idEE = @idEE," +
            " idAula = @idAula" +
            " WHERE idHorario = @idHorario;";

        #endregion QUERYS

        public static List<DetalleHorario> RecuperarHorariosAlumnoPorDia(int idperiodo, int diaSemana, int idAlumno)
        {
            List<DetalleHorario> listaHorariosEEDia = null;

            MySqlConnection connection = ConexionBD.ObtenerConexion();
            if (connection != null)
            {
                try
                {
                    MySqlCommand command = new MySqlCommand(QUERY_RECUPERAR_HORARIO_ALUMNO_DIASEMANA, connection);
                    command.Parameters.AddWithValue("@idPeriodo", idperiodo);
                    command.Parameters.AddWithValue("@diaSemana", diaSemana);
                    command.Parameters.AddWithValue("@idAlumno", idAlumno);
                    MySqlDataReader respuesta = command.ExecuteReader();

                    listaHorariosEEDia = new List<DetalleHorario>();
                    while (respuesta.Read())
                    {
                        DetalleHorario horarioDiaEE = new DetalleHorario();
                        horarioDiaEE.IdEE = respuesta.GetInt32(0);
                        horarioDiaEE.NRC = respuesta.GetString(1);
                        horarioDiaEE.NombreEE = respuesta.GetString(2);
                        horarioDiaEE.Creditos = respuesta.GetInt32(3);
                        horarioDiaEE.Modalidad = respuesta.GetString(4);
                        horarioDiaEE.NombreCompletoDocente = respuesta.GetString(5) + " " + respuesta.GetString(6) + " " + respuesta.GetString(7);
                        horarioDiaEE.HoraInicio = respuesta.GetDateTime(8).ToString("hh:mm");
                        horarioDiaEE.HoraFin = respuesta.GetDateTime(9).ToString("hh:mm");
                        horarioDiaEE.DiaSemana = respuesta.GetInt32(10);
                        horarioDiaEE.CodigoAula = respuesta.GetString(11);

                        listaHorariosEEDia.Add(horarioDiaEE);
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.ToString());
                    return listaHorariosEEDia;
                }
            }

            return listaHorariosEEDia;
        }

        public static List<DetalleHorario> RecuperarHorarioSemanal(int idperiodo, int idAlumno)
        {
            List<DetalleHorario> listaHorariosEEDia = null;

            MySqlConnection connection = ConexionBD.ObtenerConexion();
            if (connection != null)
            {
                try
                {
                    MySqlCommand command = new MySqlCommand(QUERY_RECUPERAR_HORARIO_ALUMNO_SEMANAL, connection);
                    command.Parameters.AddWithValue("@idPeriodo", idperiodo);
                    command.Parameters.AddWithValue("@idAlumno", idAlumno);
                    MySqlDataReader respuesta = command.ExecuteReader();

                    listaHorariosEEDia = new List<DetalleHorario>();
                    while (respuesta.Read())
                    {
                        DetalleHorario horarioDiaEE = new DetalleHorario();
                        horarioDiaEE.IdEE = respuesta.GetInt32(0);
                        horarioDiaEE.NRC = respuesta.GetString(1);
                        horarioDiaEE.NombreEE = respuesta.GetString(2);
                        horarioDiaEE.Creditos = respuesta.GetInt32(3);
                        horarioDiaEE.Modalidad = respuesta.GetString(4);
                        horarioDiaEE.NombreCompletoDocente = respuesta.GetString(5) + " " + respuesta.GetString(6) + " " + respuesta.GetString(7);
                        horarioDiaEE.HoraInicio = respuesta.GetDateTime(8).ToString("HH:mm:ss");
                        horarioDiaEE.HoraFin = respuesta.GetDateTime(9).ToString("HH:mm:ss");
                        horarioDiaEE.DiaSemana = respuesta.GetInt32(10);
                        horarioDiaEE.CodigoAula = respuesta.GetString(11);

                        listaHorariosEEDia.Add(horarioDiaEE);
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.ToString());
                    return listaHorariosEEDia;
                }
            }

            return listaHorariosEEDia;
        }

        public static HorarioEE RecuperarHorarioEE(int idPeriodo, int diaSemana, int idEE)
        {
            HorarioEE horario = null;
            MySqlConnection conexionBD = ConexionBD.ObtenerConexion();
            if (conexionBD != null)
            {
                try
                {
                    MySqlCommand mySqlCommand = new MySqlCommand(QUERY_RECUPERAR_HORARIO_EXACTO, conexionBD);
                    mySqlCommand.Parameters.AddWithValue("@idPeriodo", idPeriodo);
                    mySqlCommand.Parameters.AddWithValue("@diaSemana", diaSemana);
                    mySqlCommand.Parameters.AddWithValue("@idEE", idEE);
                    MySqlDataReader respuestaBD = mySqlCommand.ExecuteReader();
                    horario = new HorarioEE();
                    while (respuestaBD.Read())
                    {
                        horario.IdHorario = respuestaBD.GetInt32(0);
                        horario.HoraInicio = (DateTime) respuestaBD.GetMySqlDateTime(1);
                        horario.HoraFin = (DateTime) respuestaBD.GetMySqlDateTime(2);
                        horario.DiaSemana = respuestaBD.GetInt32(3);
                        horario.IdEE = respuestaBD.GetInt32(4);
                        horario.IdAula = respuestaBD.GetInt32(5);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return horario;
        }

        public static bool ActualizarHorario(HorarioEE horario)
        {
            bool respuesta = false;

            MySqlConnection conexionBD = ConexionBD.ObtenerConexion();
            if (conexionBD != null)
            {
                try
                {
                    MySqlCommand mySqlCommand = new MySqlCommand(QUERY_ACTUALIZAR_HORARIO, conexionBD);
                    mySqlCommand.Parameters.AddWithValue("@horaInicio", horario.HoraInicio);
                    mySqlCommand.Parameters.AddWithValue("@horaFin", horario.HoraFin);
                    mySqlCommand.Parameters.AddWithValue("@diaSemana", horario.DiaSemana);
                    mySqlCommand.Parameters.AddWithValue("@idEE", horario.IdEE);
                    mySqlCommand.Parameters.AddWithValue("@idAula", horario.IdAula);
                    mySqlCommand.Parameters.AddWithValue("@idHorario", horario.IdHorario);
                    int response = mySqlCommand.ExecuteNonQuery();
                    respuesta = (response > 0);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return respuesta;
        }

        public static bool RegistrarHorario(HorarioEE horario)
        {
            bool respuesta = false;

            MySqlConnection conexionBD = ConexionBD.ObtenerConexion();
            if (conexionBD != null)
            {
                try
                {
                    MySqlCommand mySqlCommand = new MySqlCommand(QUERY_REGISTRAR_HORARIO, conexionBD);
                    mySqlCommand.Parameters.AddWithValue("@horaInicio", horario.HoraInicio);
                    mySqlCommand.Parameters.AddWithValue("@horaFin", horario.HoraFin);
                    mySqlCommand.Parameters.AddWithValue("@diaSemana", horario.DiaSemana);
                    mySqlCommand.Parameters.AddWithValue("@idEE", horario.IdEE);
                    mySqlCommand.Parameters.AddWithValue("@idAula", horario.IdAula);
                    int response = mySqlCommand.ExecuteNonQuery();
                    respuesta = (response > 0);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return respuesta;
        }
    }
}
