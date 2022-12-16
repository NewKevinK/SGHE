using System;
using System.Collections.Generic;
using System.Text;

namespace SGHE.LogicaNegocio.POCO
{
    public abstract class Actividad
    {
        private int idEE;
        private String nrc;
        private String nombre;
        private int creditos;
        private String modalidad;
        private int idPeriodo;
        private int idDocente;
        private int idCarrera;

        protected Actividad(int idEE, string nRC, string nombre, int creditos, string modalidad, int idPeriodo, int idDocente, int idCarrera)
        {
            this.idEE = idEE;
            NRC = nRC;
            this.nombre = nombre;
            this.creditos = creditos;
            this.modalidad = modalidad;
            this.idPeriodo = idPeriodo;
            this.idDocente = idDocente;
            this.idCarrera = idCarrera;
        }

        protected Actividad()
        {
            
        }


        public int IdEE { get => idEE; set => idEE = value; }
        public string NRC { get => nrc; set => nrc = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int Creditos { get => creditos; set => creditos = value; }
        public string Modalidad { get => modalidad; set => modalidad = value; }
        public int IdPeriodo { get => idPeriodo; set => idPeriodo = value; }
        public int IdDocente { get => idDocente; set => idDocente = value; }
        public int IdCarrera { get => idCarrera; set => idCarrera = value; }
    }
}
