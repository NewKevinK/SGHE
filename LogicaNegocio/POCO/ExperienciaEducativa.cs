using System;
using System.Collections.Generic;
using System.Text;

namespace SGHE.LogicaNegocio.POCO
{
    public abstract class ExperienciaEducativa
    {
        private int idEE;
        private String NRC;
        private String nombre;
        private int creditos;
        private String modalidad;
        private int idPediodo;
        private int idDocente;

        public int IdEE { get => idEE; set => idEE = value; }
        public string NRC1 { get => NRC; set => NRC = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int Creditos { get => creditos; set => creditos = value; }
        public string Modalidad { get => modalidad; set => modalidad = value; }
        public int IdPediodo { get => idPediodo; set => idPediodo = value; }
        public int IdDocente { get => idDocente; set => idDocente = value; }
    }
}
