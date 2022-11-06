using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGHE.LogicaNegocio.POCO
{
    public abstract class Horario
    {
        private int idHorario;
        private Time HoraInicio;
        private Time HoraFin;
        private int DiaSemana;
        private int idEE;
        private int idAula;

        public int IdHorario { get => idHorario; set => idHorario = value; }
        public Time HoraInicio1 { get => HoraInicio; set => HoraInicio = value; }
        public Time HoraFin1 { get => HoraFin; set => HoraFin = value; }
        public int DiaSemana1 { get => DiaSemana; set => DiaSemana = value; }
        public int IdEE { get => idEE; set => idEE = value; }
        public int IdAula { get => idAula; set => idAula = value; }
    }
}
