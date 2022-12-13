using MySql.Data.MySqlClient;
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

        #endregion QUERYS


        public static List<HorarioDiaEE> RecuperarHorariosAlumnoPorDia(int idperiodo, int diaSemana, int idAlumno)
        {
            List<HorarioDiaEE> listaHorariosEEDia = null;

            MySqlConnection connection = ConexionBD.ObtenerConexion();
            if(connection != null)
            {
                try
                {
                    MySqlCommand command = new MySqlCommand(QUERY_RECUPERAR_HORARIO_ALUMNO_DIASEMANA, connection);
                    command.Parameters.AddWithValue("@idPeriodo",idperiodo);
                    command.Parameters.AddWithValue("@diaSemana", diaSemana);
                    command.Parameters.AddWithValue("@idAlumno", idAlumno);
                    MySqlDataReader respuesta = command.ExecuteReader();

                    listaHorariosEEDia = new List<HorarioDiaEE>();
                    while (respuesta.Read())
                    {
                        HorarioDiaEE horarioDiaEE = new HorarioDiaEE();
                        horarioDiaEE.IdEE = respuesta.GetInt32(0);
                        horarioDiaEE.NRC = respuesta.GetString(1);
                        horarioDiaEE.NombreEE = respuesta.GetString(2);
                        horarioDiaEE.Creditos = respuesta.GetInt32(3);
                        horarioDiaEE.Modalidad = respuesta.GetString(4);
                        horarioDiaEE.NombreCompletoDocente = respuesta.GetString(5) + " " + respuesta.GetString(6) + " " + respuesta.GetString(7);
                        horarioDiaEE.HoraInicio = respuesta.GetTimeSpan(8).ToString();
                        horarioDiaEE.HoraFin = respuesta.GetTimeSpan(9).ToString();
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
    }
}
