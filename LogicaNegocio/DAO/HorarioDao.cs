using SGHE.LogicaNegocio.POCO;
using System;
using System.Collections.Generic;
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
            "FROM experienciaeducativa" +
            " LEFT JOIN (SELECT idDocente, nombre, apellidoPaterno, apellidoMaterno" +
            "FROM docente JOIN usuario" +
            "ON docente.idUsuario = usuario.idUsuario)" +
            "AS docenteA" +
            "ON docenteA.idDocente = experienciaeducativa.idDocente" +
            "LEFT JOIN (SELECT idEE, horaInicio, horaFin, diaSemana, aula.codigoAula" +
            "FROM horario" +
            "JOIN aula" +
            "ON horario.idAula = aula.idAula" +
            ") AS horarioAula" +
            "ON horarioAula.idEE = experienciaeducativa.idEE" +
            "LEFT JOIN participantes" +
            "ON experienciaeducativa.idEE = participantes.idEE" +
            "LEFT JOIN periodo" +
            "ON experienciaeducativa.idPeriodo = periodo.idPeriodo" +
            "WHERE experienciaeducativa.idPeriodo = {idPeriodo} AND horarioAula.diaSemana = {diaSemana} AND participantes.idAlumno = {idAlumno}";
        #endregion QUERY_RECUPERAR_HORARIO_ALUMNO_DIASEMANA

        #endregion QUERYS


        public static HorarioDiaEE RecuperarHorarioAlumnoPorDia(int periodo, int diaSemana, int idAlumno)
        {
            HorarioDiaEE horarioDiaEE = null;



            return horarioDiaEE;
        }
    }
}
