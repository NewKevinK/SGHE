using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGHE.LogicaNegocio.POCO
{
    public abstract class Horario
    {
        private int idHorario;
        private DateTime horaInicio;
        private DateTime horaFin;
        private int diaSemana;
        private int idEE;
        private int idAula;

        protected Horario(int idHorario, DateTime horaInicio, DateTime horaFin, int diaSemana, int idEE, int idAula)
        {
            this.idHorario = idHorario;
            this.horaInicio = horaInicio;
            this.horaFin = horaFin;
            this.diaSemana = diaSemana;
            this.idEE = idEE;
            this.idAula = idAula;
        }

        protected Horario()
        {

        }

        public int IdHorario { get => idHorario; set => idHorario = value; }
        public DateTime HoraInicio { get => horaInicio; set => horaInicio = value; }
        public DateTime HoraFin { get => horaFin; set => horaFin = value; }
        public int DiaSemana { get => diaSemana; set => diaSemana = value; }
        public int IdEE { get => idEE; set => idEE = value; }
        public int IdAula { get => idAula; set => idAula = value; }
    }
}
