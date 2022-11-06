using System;
using System.Collections.Generic;
using System.Text;

namespace SGHE.LogicaNegocio.POCO
{
    public abstract class Alumno
    {
        private int idAlumno;
        private int idUsuario;
        private String matricula;
        private int idCarrera;

        public int IdAlumno { get => idAlumno; set => idAlumno = value; }
        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public string Matricula { get => matricula; set => matricula = value; }
        public int IdCarrera { get => idCarrera; set => idCarrera = value; }
    }
}
