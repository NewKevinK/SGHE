using System;
using System.Collections.Generic;
using System.Text;

namespace SGHE.LogicaNegocio.DAO
{
    public class Persona
    {
        public int idUsuario;
        public string nombre;
        public string apellidoPaterno;
        public string apellidoMaterno;
        public DateTime fechaNacimiento;
        public string domicilio;
        public string telefono;
        public int tipoUsuario;

        public Persona(int idUsuario, string nombre, string apellidoPaterno, string apellidoMaterno, DateTime fechaNacimiento, string domicilio, string telefono, int tipoUsuario)
        {
            this.idUsuario = idUsuario;
            this.nombre = nombre;
            this.apellidoPaterno = apellidoPaterno;
            this.fechaNacimiento = fechaNacimiento;
            this.domicilio = domicilio;
            this.telefono = telefono;
            this.tipoUsuario = tipoUsuario;
        }
        public Persona()
        {

        }



    }

   

}
