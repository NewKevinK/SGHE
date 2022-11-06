using System;
using System.Collections.Generic;
using System.Text;

namespace SGHE.LogicaNegocio.POCO
{
    public abstract class Participantes
    {
        private int idExperienciaEducativa;
        private int idAlumno;

        public int IdExperienciaEducativa { get => idExperienciaEducativa; set => idExperienciaEducativa = value; }
        public int IdAlumno { get => idAlumno; set => idAlumno = value; }
    }
}
