using System;
using System.Collections.Generic;
using System.Text;

namespace SGHE.LogicaNegocio.POCO
{
    public class Aula : AbsAula
    {
        public Aula(int idAula, string codigoAula, string estado, int idEdificio, string tipoAula) : base(idAula, codigoAula, estado, idEdificio, tipoAula)
        {

        }

        public Aula()
        {

        }
    }
}
