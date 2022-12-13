using System;
using System.Collections.Generic;
using System.Text;

namespace SGHE.LogicaNegocio.POCO
{
    public abstract class Usuario
    {
        private int idUsuario;
        private string nombre;
        private string apellidoPaterno;
        private string apellidoMaterno;
        private DateTime fechaNacimiento;
        private string telefono;
        private string email;
        private string domicilio;
        private string password;
        private int idTipoUsuario;

        public Usuario(int idUsuario, string nombre, string apellidoPaterno, string apellidoMaterno, DateTime fechaNacimiento, string telefono, string email, string domicilio, string password, int idTipoUsuario)
        {
            this.idUsuario = idUsuario;
            this.nombre = nombre;
            this.apellidoPaterno = apellidoPaterno;
            this.apellidoMaterno = apellidoMaterno;
            this.fechaNacimiento = fechaNacimiento;
            this.telefono = telefono;
            this.email = email;
            this.domicilio = domicilio;
            this.password = password;
            this.idTipoUsuario = idTipoUsuario;
        }

        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string ApellidoPaterno { get => apellidoPaterno; set => apellidoPaterno = value; }
        public string ApellidoMaterno { get => apellidoMaterno; set => apellidoMaterno = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Email { get => email; set => email = value; }
        public string Domicilio { get => domicilio; set => domicilio = value; }
        public string Password { get => password; set => password = value; }
        public int IdTipoUusario { get => idTipoUusario; set => idTipoUusario = value; }
    }
}
