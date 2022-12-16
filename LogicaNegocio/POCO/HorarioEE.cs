using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGHE.LogicaNegocio.POCO
{
    public class HorarioEE : Horario
    {
        public HorarioEE()
        {
        }

        public HorarioEE(int idHorario, DateTime horaInicio, DateTime horaFin, int diaSemana, int idEE, int idAula)
            : base (idHorario, horaInicio, horaFin, diaSemana, idEE, idAula) { }

    }
}
