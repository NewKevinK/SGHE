using System;
using System.Collections.Generic;
using System.Text;

namespace SGHE.LogicaNegocio.POCO
{
    public class DetalleHorario
    {
        public int IdEE { get; set; }
        public string NRC { get; set; }
        public string NombreEE { get; set; }
        public int Creditos { get; set; }
        public string Modalidad { get; set; }
        public string NombreCompletoDocente { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFin { get; set; }
        public int DiaSemana { get; set; }
        public string CodigoAula { get; set; }
    }
}
