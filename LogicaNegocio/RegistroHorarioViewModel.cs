using System;
using System.Collections.Generic;
using System.Text;

namespace SGHE.LogicaNegocio
{
    public class RegistroHorarioViewModel : BaseViewModel
    {
        #region CONSTRUCTOR

        public RegistroHorarioViewModel()
        {

        }

        #endregion CONSTRUCTOR

        #region ATTRIBUTES

        #region General



        #endregion General

        #region Enabled

        private bool chkBox_PeriodoEnabled = true;
        private bool gridHorarioEnabled = false;
        private bool chkBox_CarreraEnabled = false;
        private bool chkBox_ExperienciaEducativaEnabled = false;

        private bool chkBox_Lunes = false;
        private bool chkBox_Martes = false;
        private bool chkBox_Miercoles = false;
        private bool chkBox_Jueves = false;
        private bool chkBox_Viernes = false;
        private bool chkBox_Sabado = false;

        private bool tPHoraInicio_Lunes_Enabled = false;
        private bool tPHoraInicio_Martes_Enabled = false;
        private bool tPHoraInicio_Miercoles_Enabled = false;
        private bool tPHoraInicio_Jueves_Enabled = false;
        private bool tPHoraInicio_Viernes_Enabled = false;
        private bool tPHoraInicio_Sabado_Enabled = false;

        private bool tPHoraFin_Lunes_Enabled = false;
        private bool tPHoraFin_Martes_Enabled = false;
        private bool tPHoraFin_Miercoles_Enabled = false;
        private bool tPHoraFin_Jueves_Enabled = false;
        private bool tPHoraFin_Viernes_Enabled = false;
        private bool tPHoraFin_Sabado_Enabled = false;

        private bool chkBox_Aula_Lunes_Enabled = false;
        private bool chkBox_Aula_Martes_Enabled = false;
        private bool chkBox_Aula_Miercoles_Enabled = false;
        private bool chkBox_Aula_Jueves_Enabled = false;
        private bool chkBox_Aula_Viernes_Enabled = false;
        private bool chkBox_Aula_Sabado_Enabled = false;

        #endregion Enabled

        #endregion ATRIBUTES

        #region PROPERTIES

        #region General


        #endregion General

        #region Enabled

        #region Elementos Principales Enabled

        private bool ChkBox_PeriodoEnabled
        {
            get { return this.chkBox_PeriodoEnabled; }
            set { SetValue(ref this.chkBox_PeriodoEnabled, value); }
        }

        private bool ChkBox_CarreraEnabled
        {
            get { return this.chkBox_CarreraEnabled; }
            set { SetValue(ref this.chkBox_CarreraEnabled, value); }
        }

        private bool ChkBox_ExperienciaEducativaEnabled
        {
            get { return this.chkBox_ExperienciaEducativaEnabled; }
            set { SetValue(ref this.chkBox_ExperienciaEducativaEnabled, value); }
        }

        private bool GridHorarioEnabled
        {
            get { return this.gridHorarioEnabled; }
            set { SetValue(ref this.gridHorarioEnabled, value); }
        }

        #endregion Elementos Principales Enabled

        #region GRID HORARIOS ENABLED

        #region CheckBox Dias Enabled

        public bool ChkBox_Lunes
        {
            get { return this.chkBox_Lunes; }
            set { SetValue(ref this.chkBox_Lunes, value); }
        }

        public bool ChkBox_Martes
        {
            get { return this.chkBox_Martes; }
            set { SetValue(ref this.chkBox_Martes, value); }
        }

        public bool ChkBox_Miercoles
        {
            get { return this.chkBox_Miercoles; }
            set { SetValue(ref this.chkBox_Miercoles, value); }
        }

        public bool ChkBox_Jueves
        {
            get { return this.chkBox_Jueves; }
            set { SetValue(ref this.chkBox_Jueves, value); }
        }

        public bool ChkBox_Viernes
        {
            get { return this.chkBox_Viernes; }
            set { SetValue(ref this.chkBox_Viernes, value); }
        }

        public bool ChkBox_Sabado
        {
            get { return this.chkBox_Sabado; }
            set { SetValue(ref this.chkBox_Sabado, value); }
        }

        #endregion CheckBox Dias Enabled

        #region TimePicker Hora Inicio Enabled
        public bool TPHoraInicio_Lunes_Enabled
        {
            get { return this.tPHoraInicio_Lunes_Enabled; }
            set { SetValue(ref this.tPHoraInicio_Lunes_Enabled, value); }
        }

        public bool TPHoraInicio_Martes_Enabled
        {
            get { return this.tPHoraInicio_Martes_Enabled; }
            set { SetValue(ref this.tPHoraInicio_Martes_Enabled, value); }
        }

        public bool TPHoraInicio_Miercoles_Enabled
        {
            get { return this.tPHoraInicio_Miercoles_Enabled; }
            set { SetValue(ref this.tPHoraInicio_Miercoles_Enabled, value); }
        }

        public bool TPHoraInicio_Jueves_Enabled
        {
            get { return this.tPHoraInicio_Jueves_Enabled; }
            set { SetValue(ref this.tPHoraInicio_Jueves_Enabled, value); }
        }

        public bool TPHoraInicio_Viernes_Enabled
        {
            get { return this.tPHoraInicio_Viernes_Enabled; }
            set { SetValue(ref this.tPHoraInicio_Viernes_Enabled, value);}
        }

        public bool TPHoraInicio_Sabado_Enabled
        {
            get { return this.tPHoraInicio_Sabado_Enabled; }
            set { SetValue(ref this.tPHoraInicio_Sabado_Enabled, value);}
        }

        #endregion TimePicker Hora Inicio Enabled

        #region TimePicker Hora Fin Enabled

        public bool TPHoraFin_Lunes_Enabled
        {
            get { return this.tPHoraFin_Lunes_Enabled; }
            set { SetValue(ref this.tPHoraFin_Lunes_Enabled, value); }
        }

        public bool TPHoraFin_Martes_Enabled
        {
            get { return this.tPHoraFin_Martes_Enabled; }
            set { SetValue(ref this.tPHoraFin_Martes_Enabled, value); }
        }

        public bool TPHoraFin_Miercoles_Enabled
        {
            get { return this.tPHoraFin_Miercoles_Enabled; }
            set { SetValue(ref this.tPHoraFin_Miercoles_Enabled, value); }
        }

        public bool TPHoraFin_Jueves_Enabled
        {
            get { return this.tPHoraFin_Jueves_Enabled; }
            set { SetValue(ref this.tPHoraFin_Jueves_Enabled, value); }
        }

        public bool TPHoraFin_Viernes_Enabled
        {
            get { return this.tPHoraFin_Viernes_Enabled; }
            set { SetValue(ref this.tPHoraFin_Viernes_Enabled, value); }
        }

        public bool TPHoraFin_Sabado_Enabled
        {
            get { return this.tPHoraFin_Sabado_Enabled; }
            set { SetValue(ref this.tPHoraFin_Sabado_Enabled, value); }
        }

        #endregion TimePicker Hora Fin Enabled

        #region Aulas Enabled

        public bool ChkBox_Aula_Lunes_Enabled
        {
            get { return this.chkBox_Aula_Lunes_Enabled; }
            set { SetValue(ref this.chkBox_Aula_Lunes_Enabled, value); }
        }

        public bool ChkBox_Aula_Martes_Enabled
        {
            get { return this.chkBox_Aula_Martes_Enabled; }
            set { SetValue(ref this.chkBox_Aula_Martes_Enabled, value); }
        }

        public bool ChkBox_Aula_Miercoles_Enabled
        {
            get { return this.chkBox_Aula_Miercoles_Enabled; }
            set { SetValue(ref this.chkBox_Aula_Miercoles_Enabled, value); }
        }

        public bool ChkBox_Aula_Jueves_Enabled
        {
            get { return this.chkBox_Aula_Jueves_Enabled; }
            set { SetValue(ref this.chkBox_Aula_Jueves_Enabled, value); }
        }

        public bool ChkBox_Aula_Viernes_Enabled
        {
            get { return this.chkBox_Aula_Viernes_Enabled; }
            set { SetValue(ref this.chkBox_Aula_Viernes_Enabled, value); }
        }

        public bool ChkBox_Aula_Sabado_Enabled
        {
            get { return this.chkBox_Aula_Sabado_Enabled; }
            set { SetValue(ref this.chkBox_Aula_Sabado_Enabled, value); }
        }

        #endregion Aulas Enabled

        #endregion GRID HORARIOS ENABLED

        #endregion Enabled

        #endregion PROPERTIES

        #region COMMANDS



        #endregion COMMANDS

        #region METHODS



        #endregion METHODS
    }
}
