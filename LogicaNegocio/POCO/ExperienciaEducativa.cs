using System;
using System.Collections.Generic;
using System.Text;

namespace SGHE.LogicaNegocio.POCO
{
    public class ExperienciaEducativa : Actividad
    {
        public ExperienciaEducativa(
            int idEE,
            string nRC,
            string nombre,
            int creditos,
            string modalidad,
            int idPeriodo, 
            int idDocente,
            int idCarrera) : base(idEE, nRC, nombre, creditos, modalidad, idPeriodo, idDocente, idCarrera)
        {

        }
        public ExperienciaEducativa()
        {

        }
    }
}
