using System;
using System.Collections.Generic;
using System.Text;

namespace SGHE.LogicaNegocio.DAO
{
    public class Persona
    {
        public int idUsuario;
        public int idTipoUsuario;
        public string tipoUsuario;
        public int idPersona;
        public string nombre;

        

        public Persona(int idUsuario, int idTipoUsuario, string tipoUsuario, int idPersona, string nombre)
        {
            this.idUsuario = idUsuario;
            this.idTipoUsuario = idTipoUsuario;
            this.tipoUsuario = tipoUsuario;
            this.idPersona = idPersona;
            this.nombre = nombre;
        }
        public Persona()
        {

        }



    }

   

}
