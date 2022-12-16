using CommunityToolkit.Mvvm.Input;
using SGHE.LogicaNegocio.DAO;
using SGHE.LogicaNegocio.POCO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace SGHE.LogicaNegocio
{
    public class RegistroHorarioViewModel : BaseViewModel
    {
        #region CONSTRUCTOR

        public RegistroHorarioViewModel()
        {
            RecuperarPeriodos();
        }

        #endregion CONSTRUCTOR

        #region ATTRIBUTES

        #region General

        private List<Periodo> periodos = new List<Periodo>();
        private List<Carrera> carreras = new List<Carrera>();
        private List<ExperienciaEducativa> experienciasEducativas = new List<ExperienciaEducativa>();
        private List<Aula> aulasInstitucion = new List<Aula>();

        private Periodo periodoSeleccionado = null;
        private Carrera carreraSeleccionada = null;
        private ExperienciaEducativa eeSeleccionada = null;

        #endregion General

        #region Datos Ingresados y Seleccionados

        //Valores de Hora Inicio
        private DateTime value_HoraInicio_Lunes;
        private DateTime value_HoraInicio_Martes;
        private DateTime value_HoraInicio_Miercoles;
        private DateTime value_HoraInicio_Jueves;
        private DateTime value_HoraInicio_Viernes;
        private DateTime value_HoraInicio_Sabado;

        //Valores de Hora Fin
        private DateTime value_HoraFin_Lunes;
        private DateTime value_HoraFin_Martes;
        private DateTime value_HoraFin_Miercoles;
        private DateTime value_HoraFin_Jueves;
        private DateTime value_HoraFin_Viernes;
        private DateTime value_HoraFin_Sabado;

        //Aulas seleccionadas por dia
        private Aula aulaLunes = null;
        private Aula aulaMartes = null;
        private Aula aulaMiercoles = null;
        private Aula aulaJueves = null;
        private Aula aulaViernes = null;
        private Aula aulaSabado = null;

        #endregion Datos Ingresados y Seleccionados

        #region Enabled

        //ComboBox y Grid
        private bool cBox_PeriodoEnabled = false;
        private bool cBox_CarreraEnabled = false;
        private bool cBox_ExperienciaEducativaEnabled = false;
        private bool gridHorarioEnabled = false;

        //CheckBox Dias Semana
        private bool chkBox_Lunes = false;
        private bool chkBox_Martes = false;
        private bool chkBox_Miercoles = false;
        private bool chkBox_Jueves = false;
        private bool chkBox_Viernes = false;
        private bool chkBox_Sabado = false;

        //Time Picker Hora Inicio
        private bool tPHoraInicio_Lunes_Enabled = false;
        private bool tPHoraInicio_Martes_Enabled = false;
        private bool tPHoraInicio_Miercoles_Enabled = false;
        private bool tPHoraInicio_Jueves_Enabled = false;
        private bool tPHoraInicio_Viernes_Enabled = false;
        private bool tPHoraInicio_Sabado_Enabled = false;

        //Time Picker Hora Fin
        private bool tPHoraFin_Lunes_Enabled = false;
        private bool tPHoraFin_Martes_Enabled = false;
        private bool tPHoraFin_Miercoles_Enabled = false;
        private bool tPHoraFin_Jueves_Enabled = false;
        private bool tPHoraFin_Viernes_Enabled = false;
        private bool tPHoraFin_Sabado_Enabled = false;

        //ComboBox Aulas
        private bool cBox_Aula_Lunes_Enabled = false;
        private bool cBox_Aula_Martes_Enabled = false;
        private bool cBox_Aula_Miercoles_Enabled = false;
        private bool cBox_Aula_Jueves_Enabled = false;
        private bool cBox_Aula_Viernes_Enabled = false;
        private bool cBox_Aula_Sabado_Enabled = false;

        #endregion Enabled

        #endregion ATRIBUTES

        #region PROPERTIES

        #region Datos Ingresados y Seleccionados

        #region Valores en TimePicker Hora Inicio

        public DateTime Value_HoraInicio_Lunes
        {
            get { return this.value_HoraInicio_Lunes; }
            set { SetValue(ref this.value_HoraInicio_Lunes, value); }
        }

        public DateTime Value_HoraInicio_Martes
        {
            get { return this.value_HoraInicio_Martes; }
            set { SetValue(ref this.value_HoraInicio_Martes, value); }
        }

        public DateTime Value_HoraInicio_Miercoles
        {
            get { return this.value_HoraInicio_Miercoles; }
            set { SetValue(ref this.value_HoraInicio_Miercoles, value); }
        }

        public DateTime Value_HoraInicio_Jueves
        {
            get { return this.value_HoraInicio_Jueves; }
            set { SetValue(ref this.value_HoraInicio_Jueves, value); }
        }

        public DateTime Value_HoraInicio_Viernes
        {
            get { return this.value_HoraInicio_Viernes; }
            set { SetValue(ref this.value_HoraInicio_Viernes, value); }
        }

        public DateTime Value_HoraInicio_Sabado
        {
            get { return this.value_HoraInicio_Sabado; }
            set { SetValue(ref this.value_HoraInicio_Sabado, value); }
        }

        #endregion Valores en TimePicker Hora Inicio

        #region Valores en TimePicker Hora Fin

        public DateTime Value_HoraFin_Lunes
        {
            get { return this.value_HoraFin_Lunes; }
            set { SetValue(ref this.value_HoraFin_Lunes, value); }
        }

        public DateTime Value_HoraFin_Martes
        {
            get { return this.value_HoraFin_Martes; }
            set { SetValue(ref this.value_HoraFin_Martes, value); }
        }

        public DateTime Value_HoraFin_Miercoles
        {
            get { return this.value_HoraFin_Miercoles; }
            set { SetValue(ref this.value_HoraFin_Miercoles, value); }
        }

        public DateTime Value_HoraFin_Jueves
        {
            get { return this.value_HoraFin_Jueves; }
            set { SetValue(ref this.value_HoraFin_Jueves, value); }
        }

        public DateTime Value_HoraFin_Viernes
        {
            get { return this.value_HoraFin_Viernes; }
            set { SetValue(ref this.value_HoraFin_Viernes, value); }
        }

        public DateTime Value_HoraFin_Sabado
        {
            get { return this.value_HoraFin_Sabado; }
            set { SetValue(ref this.value_HoraFin_Sabado, value); }
        }


        #endregion Valores en TimePicker Hora Fin

        #region ComboBox Aulas

        public Aula CBox_Aula_Lunes_Selected
        {
            get { return this.aulaLunes; }
            set { SetValue(ref this.aulaLunes, value); }
        }

        public Aula CBox_Aula_Martes_Selected
        {
            get { return this.aulaMartes; }
            set { SetValue(ref this.aulaMartes, value); }
        }

        public Aula CBox_Aula_Miercoles_Selected
        {
            get { return this.aulaMiercoles; }
            set { SetValue(ref this.aulaMiercoles, value); }
        }

        public Aula CBox_Aula_Jueves_Selected
        {
            get { return this.aulaJueves; }
            set { SetValue(ref this.aulaJueves, value); }
        }

        public Aula CBox_Aula_Viernes_Selected
        {
            get { return this.aulaViernes; }
            set { SetValue(ref this.aulaViernes, value); }
        }

        public Aula CBox_Aula_Sabado_Selected
        {
            get { return this.aulaSabado; }
            set { SetValue(ref this.aulaSabado, value); }
        }

        #endregion ComboBox Aulas

        #endregion Datos Ingresados y Seleccionados

        #region Datos Iniciales

        //ITEMS
        public List<Periodo> CBox_Periodo_Items
        {
            get { return this.periodos; }
            set { SetValue(ref this.periodos, value); }
        }

        public List<Carrera> CBox_Carrera_Items
        {
            get { return this.carreras; }
            set { SetValue(ref this.carreras, value); }
        }

        public List<ExperienciaEducativa> CBox_EE_Items
        {
            get { return this.experienciasEducativas; }
            set { SetValue(ref this.experienciasEducativas, value); }
        }

        //SELECTED ITEMS
        public Periodo CBox_Periodo_Selected
        {
            get { return this.periodoSeleccionado; }
            set { SetValue(ref this.periodoSeleccionado, value);
                RecuperarCarreras();           
            }
        }

        public Carrera CBox_Carrera_Selected
        {
            get { return this.carreraSeleccionada; }
            set { SetValue(ref this.carreraSeleccionada, value);
                RecuperarExperienciasEducativas();               
            }
        }

        public ExperienciaEducativa CBox_EE_Selected
        {
            get { return this.eeSeleccionada; }
            set { SetValue(ref this.eeSeleccionada, value);
                RecuperarAulas();
            }
        }

        public List<Aula> CBox_Aula_Items
        {
            get { return this.aulasInstitucion; }
            set { SetValue(ref this.aulasInstitucion, value); }
        }

        #endregion Datos

        #region Enabled

        #region Elementos Principales Enabled

        public bool CBox_PeriodoEnabled
        {
            get { return this.cBox_PeriodoEnabled; }
            set { SetValue(ref this.cBox_PeriodoEnabled, value); }
        }

        public bool CBox_CarreraEnabled
        {
            get { return this.cBox_CarreraEnabled; }
            set { SetValue(ref this.cBox_CarreraEnabled, value); }
        }

        public bool CBox_ExperienciaEducativaEnabled
        {
            get { return this.cBox_ExperienciaEducativaEnabled; }
            set { SetValue(ref this.cBox_ExperienciaEducativaEnabled, value); }
        }

        public bool GridHorarioEnabled
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
            set { SetValue(ref this.chkBox_Lunes, value);
                ActivarDesactivarElementosLunes();
            }
        }

        public bool ChkBox_Martes
        {
            get { return this.chkBox_Martes; }
            set { SetValue(ref this.chkBox_Martes, value);
                ActivarDesactivarElementosMartes();
            }
        }

        public bool ChkBox_Miercoles
        {
            get { return this.chkBox_Miercoles; }
            set { SetValue(ref this.chkBox_Miercoles, value);
                ActivarDesactivarElementosMiercoles();
            }
        }

        public bool ChkBox_Jueves
        {
            get { return this.chkBox_Jueves; }
            set { SetValue(ref this.chkBox_Jueves, value);
                ActivarDesactivarElementosJueves();
            }
        }

        public bool ChkBox_Viernes
        {
            get { return this.chkBox_Viernes; }
            set { SetValue(ref this.chkBox_Viernes, value);
                ActivarDesactivarElementosViernes();
            }
        }

        public bool ChkBox_Sabado
        {
            get { return this.chkBox_Sabado; }
            set { SetValue(ref this.chkBox_Sabado, value);
                ActivarDesactivarElementosSabado();
            }
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

        #region ComboBox Aulas Enabled

        public bool CBox_Aula_Lunes_Enabled
        {
            get { return this.cBox_Aula_Lunes_Enabled; }
            set { SetValue(ref this.cBox_Aula_Lunes_Enabled, value); }
        }

        public bool CBox_Aula_Martes_Enabled
        {
            get { return this.cBox_Aula_Martes_Enabled; }
            set { SetValue(ref this.cBox_Aula_Martes_Enabled, value); }
        }

        public bool CBox_Aula_Miercoles_Enabled
        {
            get { return this.cBox_Aula_Miercoles_Enabled; }
            set { SetValue(ref this.cBox_Aula_Miercoles_Enabled, value); }
        }

        public bool CBox_Aula_Jueves_Enabled
        {
            get { return this.cBox_Aula_Jueves_Enabled; }
            set { SetValue(ref this.cBox_Aula_Jueves_Enabled, value); }
        }

        public bool CBox_Aula_Viernes_Enabled
        {
            get { return this.cBox_Aula_Viernes_Enabled; }
            set { SetValue(ref this.cBox_Aula_Viernes_Enabled, value); }
        }

        public bool CBox_Aula_Sabado_Enabled
        {
            get { return this.cBox_Aula_Sabado_Enabled; }
            set { SetValue(ref this.cBox_Aula_Sabado_Enabled, value); }
        }

        #endregion Combo Box Aulas Enabled

        #endregion GRID HORARIOS ENABLED

        #endregion Enabled

        #endregion PROPERTIES

        #region COMMANDS

        public ICommand ClickRegistrar
        {
            get { return new RelayCommand(Registrar); }
            set { }
        }
        

        #endregion COMMANDS

        #region METHODS

        #region Datos Iniciales

        private void RecuperarPeriodos()
        {
            PeriodoDAO periodoDAO = new PeriodoDAO();
            List<Periodo> periodos = periodoDAO.RecuperarPeriodos();
            if(periodos != null)
            {              
                foreach (Periodo periodo in periodos)
                {
                    this.CBox_Periodo_Items.Add(periodo);
                }               
                this.CBox_PeriodoEnabled = true; //Activando Combo Box de Periodos
            }
            else { MessageBox.Show("No se recuperarón los periodos", "Error de Conexión"); }
        }

        private void RecuperarCarreras()
        {
            CarreraDAO carreraDAO = new CarreraDAO();
            List<Carrera> carreras = carreraDAO.RecuperarCarreras();
            if(carreras != null)
            {
                foreach (Carrera carrera in carreras)
                {
                    this.CBox_Carrera_Items.Add(carrera);
                }               
                this.CBox_CarreraEnabled = true; //Activando Combo Box de Carreras
            }
            else { MessageBox.Show("No se recuperarón las carreras", "Error de conexión"); }
        }

        private void RecuperarExperienciasEducativas()
        {
            ActividadDao experienciaEducativaDAO = new ActividadDao();
            List<ExperienciaEducativa> experienciasEducativas = 
                experienciaEducativaDAO.RecuperarExperienciasEducativasPorPeriodoCarrera(this.CBox_Periodo_Selected.IdPeriodo, this.CBox_Carrera_Selected.IdCarrera);

            if(experienciasEducativas != null)
            {
                foreach (ExperienciaEducativa ee in experienciasEducativas)
                 {
                     this.CBox_EE_Items.Add(ee);
                 }                 
                 this.CBox_ExperienciaEducativaEnabled = true; //Activando Combo Box de Experiencias Educativas
            }
            else { MessageBox.Show("No se recuperarón las Experiencias Educativas", "Error de conexión"); }
        }

        private void RecuperarAulas()
        {
            AulaDao aulaDao = new();
            List<Aula> aulas = new List<Aula>();
            aulas = aulaDao.RecuperarAulasPorInstitucion(this.carreraSeleccionada.IdInstitucion);
            foreach(Aula aula in aulas)
            {
                this.CBox_Aula_Items.Add(aula);
            }
            this.GridHorarioEnabled = true; //Activando Grid para configurar los horarios
        }

        #endregion Datos Iniciales

        #region Activar y Desactivar Dias
        public void ActivarDesactivarElementosLunes()
        {
            if(this.ChkBox_Lunes == true)
            {
                this.TPHoraInicio_Lunes_Enabled = true;
                this.TPHoraFin_Lunes_Enabled = true;
                this.CBox_Aula_Lunes_Enabled = true;
            }

            if (this.ChkBox_Lunes == false)
            {
                this.TPHoraInicio_Lunes_Enabled = false;
                this.TPHoraFin_Lunes_Enabled = false;
                this.CBox_Aula_Lunes_Enabled = false;
            }
        }

        public void ActivarDesactivarElementosMartes()
        {
            if (this.ChkBox_Martes == true)
            {
                this.TPHoraInicio_Martes_Enabled = true;
                this.TPHoraFin_Martes_Enabled = true;
                this.CBox_Aula_Martes_Enabled = true;
            }

            if (this.ChkBox_Martes == false)
            {
                this.TPHoraInicio_Martes_Enabled = false;
                this.TPHoraFin_Martes_Enabled = false;
                this.CBox_Aula_Martes_Enabled = false;
            }
        }

        public void ActivarDesactivarElementosMiercoles()
        {
            if (this.ChkBox_Miercoles == true)
            {
                this.TPHoraInicio_Miercoles_Enabled = true;
                this.TPHoraFin_Miercoles_Enabled = true;
                this.CBox_Aula_Miercoles_Enabled = true;
            }

            if (this.ChkBox_Miercoles == false)
            {
                this.TPHoraInicio_Miercoles_Enabled = false;
                this.TPHoraFin_Miercoles_Enabled = false;
                this.CBox_Aula_Miercoles_Enabled = false;
            }
        }

        public void ActivarDesactivarElementosJueves()
        {
            if (this.ChkBox_Jueves == true)
            {
                this.TPHoraInicio_Jueves_Enabled = true;
                this.TPHoraFin_Jueves_Enabled = true;
                this.CBox_Aula_Jueves_Enabled = true;
            }

            if (this.ChkBox_Jueves == false)
            {
                this.TPHoraInicio_Jueves_Enabled = false;
                this.TPHoraFin_Jueves_Enabled = false;
                this.CBox_Aula_Jueves_Enabled = false;
            }
        }

        public void ActivarDesactivarElementosViernes()
        {
            if (this.ChkBox_Viernes == true)
            {
                this.TPHoraInicio_Viernes_Enabled = true;
                this.TPHoraFin_Viernes_Enabled = true;
                this.CBox_Aula_Viernes_Enabled = true;
            }

            if (this.ChkBox_Viernes == false)
            {
                this.TPHoraInicio_Viernes_Enabled = false;
                this.TPHoraFin_Viernes_Enabled = false;
                this.CBox_Aula_Viernes_Enabled = false;
            }
        }

        public void ActivarDesactivarElementosSabado()
        {
            if (this.ChkBox_Sabado == true)
            {
                this.TPHoraInicio_Sabado_Enabled = true;
                this.TPHoraFin_Sabado_Enabled = true;
                this.CBox_Aula_Sabado_Enabled = true;
            }

            if (this.ChkBox_Sabado == false)
            {
                this.TPHoraInicio_Sabado_Enabled = false;
                this.TPHoraFin_Sabado_Enabled = false;
                this.CBox_Aula_Sabado_Enabled = false;
            }
        }

        #endregion Activar y Desactivar Dias

        #region Registrar Datos

        public void Registrar()
        {
            if (this.ChkBox_Lunes == true) { RegistrarHorarioLunes(); }
            if (this.ChkBox_Martes == true) { RegistrarHorarioMartes(); }
            if (this.ChkBox_Miercoles == true) { RegistrarHorarioMiercoles(); }
            if (this.ChkBox_Jueves == true) { RegistrarHorarioJueves(); }
            if (this.ChkBox_Viernes == true) { RegistrarHorarioViernes(); }
            if (this.ChkBox_Sabado == true) { RegistrarHorarioViernes(); }
        }

        private void RegistrarHorarioLunes()
        {
            //Horario horarioLunes = new();
        }

        private void RegistrarHorarioMartes() 
        { 

        }

        private void RegistrarHorarioMiercoles() 
        { 

        }

        private void RegistrarHorarioJueves() 
        { 

        }

        private void RegistrarHorarioViernes() 
        { 

        }

        private void RegistrarHorarioSabado()
        { 

        }

        #endregion Registrar Datos

        #endregion METHODS
    }
}
