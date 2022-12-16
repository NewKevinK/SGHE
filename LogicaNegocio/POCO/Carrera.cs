using System;
using System.Collections.Generic;
using System.Text;

namespace SGHE.LogicaNegocio.POCO
{
    public class Carrera
    {
        public int IdCarrera { get; set; }
        public string Grado { get; set; }
        public string Nombre { get; set; }
        public string CodigoCarrera { get; set; }
        public string Area { get; set; }
        public int IdInstitucion { get; set; }
    }
}
