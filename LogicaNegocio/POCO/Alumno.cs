using System;
using System.Collections.Generic;
using System.Text;

namespace SGHE.LogicaNegocio.POCO
{
    public class Alumno : Usuario
    {
        private int idAlumno;
        private int idUsuario;
        private String matricula;
        private int idCarrera;

        public Alumno(int idUsuario, string nombre, string apellidoPaterno, string apellidoMaterno, DateTime fechaNacimiento, string telefono, string email, string domicilio, string password, int idTipoUsuario) : base(idUsuario, nombre, apellidoPaterno, apellidoMaterno, fechaNacimiento, telefono, email, domicilio, password, idTipoUsuario)
        {

        }

        public Alumno(int idUsuario, string nombre, string apellidoPaterno, string apellidoMaterno, DateTime fechaNacimiento, string telefono, string email, string domicilio, string password, int idTipoUsuario, int idAlumno, string matricula, int idCarrera) : base(idUsuario, nombre, apellidoPaterno, apellidoMaterno, fechaNacimiento, telefono, email, domicilio, password, idTipoUsuario)
        {
            this.idUsuario = idUsuario;
            this.idAlumno = idAlumno;
            this.matricula = matricula;
            this.idCarrera = idCarrera;
        }

        public Alumno(int idUsuario, string nombre, string apellidoPaterno, string apellidoMaterno, DateTime fechaNacimiento, string telefono, string email, string domicilio, string password, int idTipoUsuario, string matricula, int idCarrera) : base(idUsuario, nombre, apellidoPaterno, apellidoMaterno, fechaNacimiento, telefono, email, domicilio, password, idTipoUsuario)
        {
            this.idUsuario = idUsuario;
            this.matricula = matricula;
            this.idCarrera = idCarrera;
        }

        public int IdAlumno { get => idAlumno; set => idAlumno = value; }
        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public string Matricula { get => matricula; set => matricula = value; }
        public int IdCarrera { get => idCarrera; set => idCarrera = value; }
    }
}
