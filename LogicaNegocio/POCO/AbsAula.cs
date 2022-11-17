using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGHE.LogicaNegocio.POCO
{
    public abstract class AbsAula
    {
        private int idAula;
        private string codigoAula;
        private string estado;
        private int idEdificio;
        private string tipoAula;

        public AbsAula(int idAula, string codigoAula, string estado, int idEdificio, string tipoAula)
        {
            this.idAula = idAula;
            this.codigoAula = codigoAula;
            this.estado = estado;
            this.idEdificio = idEdificio;
            this.tipoAula = tipoAula;
        }
        public AbsAula( string codigoAula, string estado, int idEdificio, string tipoAula)
        {
            this.codigoAula = codigoAula;
            this.estado = estado;
            this.idEdificio = idEdificio;
            this.tipoAula = tipoAula;
        }

        public AbsAula()
        {

        }

        public AbsAula(string codigoAula, int idEdificio, string tipoAula)
        {
            this.codigoAula = codigoAula;
            this.idEdificio = idEdificio;
            this.tipoAula = tipoAula;
        }

        public int IdAula { get => idAula; set => idAula = value; }
        public string CodigoAula { get => codigoAula; set => codigoAula = value; }
        public string Estado { get => estado; set => estado = value; }
        public int IdEdificio { get => idEdificio; set => idEdificio = value; }
        public string TipoAula { get => tipoAula; set => tipoAula = value; }
        
    }
}
