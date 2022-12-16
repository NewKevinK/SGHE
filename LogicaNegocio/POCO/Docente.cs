using System;
using System.Collections.Generic;
using System.Text;

namespace SGHE.LogicaNegocio.POCO
{
    public class Docente : Usuario
    {
        private int idUsuario;
        private int idDocente;
        private String numDocente;

        public Docente()
        {
        }

        public Docente(int idUsuario, string nombre, string apellidoPaterno, string apellidoMaterno, DateTime fechaNacimiento, string telefono, string email, string domicilio, string password, int idTipoUusario) : base(idUsuario, nombre, apellidoPaterno, apellidoMaterno, fechaNacimiento, telefono, email, domicilio, password, idTipoUusario)
        {

        }

        public Docente(int idUsuario, string nombre, string apellidoPaterno, string apellidoMaterno, DateTime fechaNacimiento, string telefono, string email, string domicilio, string password, int idTipoUsuario, string numDocente) : base(idUsuario, nombre, apellidoPaterno, apellidoMaterno, fechaNacimiento, telefono, email, domicilio, password, idTipoUsuario)
        {
            this.numDocente = numDocente;
            this.idUsuario = idUsuario;
        }

        public string NumDocente { get; set; }
    }
}
