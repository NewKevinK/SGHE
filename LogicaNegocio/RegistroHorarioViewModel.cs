using CommunityToolkit.Mvvm.Input;
using Org.BouncyCastle.Asn1.X509;
using SGHE.LogicaNegocio.DAO;
using SGHE.LogicaNegocio.POCO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

        #region Constantes

        private static readonly int LUNES = 1;
        private static readonly int MARTES = 2;
        private static readonly int MIERCOLES = 3;
        private static readonly int JUEVES = 4;
        private static readonly int VIERNES = 5;
        private static readonly int SABADO = 6;

        #endregion Constantes

        #region General

        private ObservableCollection<Periodo> periodos = new ObservableCollection<Periodo>();
        private ObservableCollection<Carrera> carreras = new ObservableCollection<Carrera>();
        private ObservableCollection<ExperienciaEducativa> experienciasEducativas = new ObservableCollection<ExperienciaEducativa>();
        private ObservableCollection<Aula> aulasInstitucion = new ObservableCollection<Aula>();

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

        //Aula index
        private int cBox_Aula_Lunes_Index = -1;
        private int cBox_Aula_Martes_Index = -1;
        private int cBox_Aula_Miercoles_Index = -1;
        private int cBox_Aula_Jueves_Index = -1;
        private int cBox_Aula_Viernes_Index = -1;
        private int cBox_Aula_Sabado_Index = -1;

        #endregion Datos Ingresados y Seleccionados

        #region Datos Recuperados

        private bool ExisteHorario_Lunes = false;
        private bool ExisteHorario_Martes = false;
        private bool ExisteHorario_Miercoles = false;
        private bool ExisteHorario_Jueves = false;
        private bool ExisteHorario_Viernes = false;
        private bool ExisteHorario_Sabado = false;

        private HorarioEE HorarioEELunes = null;
        private HorarioEE HorarioEEMartes = null;
        private HorarioEE HorarioEEMiercoles = null;
        private HorarioEE HorarioEEJueves = null;
        private HorarioEE HorarioEEViernes = null;
        private HorarioEE HorarioEESabado = null;

        #endregion Datos Recuperados

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

        #region ComboBox Aulas Selected

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

        #endregion ComboBox Aulas Selected

        #region ComboBox Aulas Index

        public int CBox_Aula_Lunes_Index
        {
            get { return this.cBox_Aula_Lunes_Index; }
            set { SetValue(ref this.cBox_Aula_Lunes_Index, value); }
        }

        public int CBox_Aula_Martes_Index
        {
            get { return this.cBox_Aula_Martes_Index; }
            set { SetValue(ref this.cBox_Aula_Martes_Index, value); }
        }

        public int CBox_Aula_Miercoles_Index
        {
            get { return this.cBox_Aula_Miercoles_Index; }
            set { SetValue(ref this.cBox_Aula_Miercoles_Index, value); }
        }

        public int CBox_Aula_Jueves_Index
        {
            get { return this.cBox_Aula_Jueves_Index; }
            set { SetValue(ref this.cBox_Aula_Jueves_Index, value); }
        }

        public int CBox_Aula_Viernes_Index
        {
            get { return this.cBox_Aula_Viernes_Index; }
            set { SetValue(ref this.cBox_Aula_Viernes_Index, value); }
        }

        public int CBox_Aula_Sabado_Index
        {
            get { return this.cBox_Aula_Sabado_Index; }
            set { SetValue(ref this.cBox_Aula_Sabado_Index, value); }
        }

        #endregion ComboBox Aulas Index

        #endregion Datos Ingresados y Seleccionados

        #region Datos Iniciales

        //ITEMS
        public ObservableCollection<Periodo> CBox_Periodo_Items
        {
            get { return this.periodos; }
            set { SetValue(ref this.periodos, value); }
        }

        public ObservableCollection<Carrera> CBox_Carrera_Items
        {
            get { return this.carreras; }
            set { SetValue(ref this.carreras, value); }
        }

        public ObservableCollection<ExperienciaEducativa> CBox_EE_Items
        {
            get { return this.experienciasEducativas; }
            set { SetValue(ref this.experienciasEducativas, value); }
        }

        //SELECTED ITEMS
        public Periodo CBox_Periodo_Selected
        {
            get { return this.periodoSeleccionado; }
            set { SetValue(ref this.periodoSeleccionado, value);
                this.CBox_Carrera_Items.Clear(); //Al cambiar de valor se activa el Set y por lo tanto el metodo Recuperar Experiencias Educativas (Ocurre una excepción)
                RecuperarCarreras();           
            }
        }

        public Carrera CBox_Carrera_Selected
        {
            get { return this.carreraSeleccionada; }
            set { SetValue(ref this.carreraSeleccionada, value);
                this.CBox_EE_Items.Clear(); //Limpiando la lista de Experiencias Educativas
                this.CBox_Aula_Lunes_Selected = null; //Limpiando horas y aulas
                RecuperarExperienciasEducativas();               
            }
        }

        public ExperienciaEducativa CBox_EE_Selected
        {
            get { return this.eeSeleccionada; }
            set { SetValue(ref this.eeSeleccionada, value);
                ResetearHorasYAulas();
                RecuperarAulas();
                RecuperarHorarios();
            }
        }

        public ObservableCollection<Aula> CBox_Aula_Items
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
            this.GridHorarioEnabled = false;
            CarreraDAO carreraDAO = new CarreraDAO();
            List<Carrera> carreras = carreraDAO.RecuperarCarreras();
            if(carreras != null)
            {
                foreach (Carrera carrera in carreras)
                {
                    this.CBox_Carrera_Items.Add(carrera);
                }

                if (this.CBox_ExperienciaEducativaEnabled == false)
                {
                    this.CBox_CarreraEnabled = true; //Activando Combo Box de Carreras
                } //Activando Combo Box de Experiencias Educativas
                
            }
            else { MessageBox.Show("No se recuperarón las carreras", "Error de conexión"); }
        }

        private void RecuperarExperienciasEducativas()
        {
            this.GridHorarioEnabled = false;
            if (this.CBox_Periodo_Selected != null && this.CBox_Carrera_Selected != null)
            {
                //this.GridHorarioEnabled = false; //Desactivando Grid al cambiar de carrera
                ActividadDao experienciaEducativaDAO = new ActividadDao();
                List<ExperienciaEducativa> experienciasEducativas =
                    experienciaEducativaDAO.RecuperarExperienciasEducativasPorPeriodoCarrera(this.CBox_Periodo_Selected.IdPeriodo, this.CBox_Carrera_Selected.IdCarrera);

                if (experienciasEducativas != null)
                {
                    this.CBox_EE_Items.Clear();
                    foreach (ExperienciaEducativa ee in experienciasEducativas)
                    {
                        this.CBox_EE_Items.Add(ee);
                    }

                    if (this.CBox_ExperienciaEducativaEnabled == false)
                    {
                        this.CBox_ExperienciaEducativaEnabled = true;
                    } //Activando Combo Box de Experiencias Educativas
                }
                else { MessageBox.Show("No se recuperarón las Experiencias Educativas", "Error de conexión"); }
            }
            
        }

        private void RecuperarAulas()
        {
            if(this.carreraSeleccionada != null)
            {
                AulaDao aulaDao = new();
                List<Aula> aulas = new List<Aula>();
                aulas = aulaDao.RecuperarAulasPorInstitucion(this.carreraSeleccionada.IdInstitucion);
                foreach (Aula aula in aulas)
                {
                    this.CBox_Aula_Items.Add(aula);
                }
                this.GridHorarioEnabled = true; //Activando Grid para configurar los horarios
            }   
        }

        #endregion Datos Iniciales

        #region Datos Obtenidos

        private void RecuperarHorarios()
        {
            MessageBox.Show("Recuperando Horarios\nPor favor de clic en Aceptar para continuar", "Aviso");
            RecuperarHorarioLunes();
            RecuperarHorarioMartes();
            RecuperarHorarioMiercoles();
            RecuperarHorarioJueves();
            RecuperarHorarioViernes();
            //RecuperarHorarioSabado();
        }

        #region Recuperar Horarios Existentes

        private void RecuperarHorarioLunes()
        {
            if (this.periodoSeleccionado != null && this.eeSeleccionada != null)
            {
                HorarioEELunes = HorarioDao.RecuperarHorarioEE(periodoSeleccionado.IdPeriodo, LUNES, eeSeleccionada.IdEE);
                if(HorarioEELunes.IdEE != 0)
                {
                    this.ExisteHorario_Lunes = true;
                    this.ChkBox_Lunes = true;
                    this.Value_HoraInicio_Lunes = HorarioEELunes.HoraInicio;
                    this.Value_HoraFin_Lunes = HorarioEELunes.HoraFin;
                    this.CBox_Aula_Lunes_Index = ObtenerIndexCBoxAulas(HorarioEELunes.IdAula);
                }
                else { this.ExisteHorario_Lunes = false; }
            }
        }

        private void RecuperarHorarioMartes()
        {
            if (this.periodoSeleccionado != null && this.eeSeleccionada != null)
            {
                HorarioEEMartes = HorarioDao.RecuperarHorarioEE(periodoSeleccionado.IdPeriodo, MARTES, eeSeleccionada.IdEE);
                if (HorarioEEMartes.IdEE != 0)
                {
                    this.ExisteHorario_Martes = true;
                    this.ChkBox_Martes = true;
                    this.Value_HoraInicio_Martes = HorarioEEMartes.HoraInicio;
                    this.Value_HoraFin_Martes = HorarioEEMartes.HoraFin;
                    this.CBox_Aula_Martes_Index = ObtenerIndexCBoxAulas(HorarioEEMartes.IdAula);
                }
                else { this.ExisteHorario_Martes = false; }

            }
        }

        private void RecuperarHorarioMiercoles()
        {
            if (this.periodoSeleccionado != null && this.eeSeleccionada != null)
            {
                HorarioEEMiercoles = HorarioDao.RecuperarHorarioEE(periodoSeleccionado.IdPeriodo, MIERCOLES, eeSeleccionada.IdEE);
                if (HorarioEEMiercoles.IdEE != 0)
                {
                    this.ExisteHorario_Miercoles = true;
                    this.ChkBox_Miercoles = true;
                    this.Value_HoraInicio_Miercoles = HorarioEEMiercoles.HoraInicio;
                    this.Value_HoraFin_Miercoles = HorarioEEMiercoles.HoraFin;
                    this.CBox_Aula_Miercoles_Index = ObtenerIndexCBoxAulas(HorarioEEMiercoles.IdAula);
                }
                else { this.ExisteHorario_Miercoles = false; }
            }
        }

        private void RecuperarHorarioJueves()
        {
            if (this.periodoSeleccionado != null && this.eeSeleccionada != null)
            {
                HorarioEEJueves = HorarioDao.RecuperarHorarioEE(periodoSeleccionado.IdPeriodo, JUEVES, eeSeleccionada.IdEE);
                if (HorarioEEJueves.IdEE != 0)
                {
                    this.ExisteHorario_Jueves = true;
                    this.ChkBox_Jueves = true;
                    this.Value_HoraInicio_Jueves = HorarioEEJueves.HoraInicio;
                    this.Value_HoraFin_Jueves = HorarioEEJueves.HoraFin;
                    this.CBox_Aula_Jueves_Index = ObtenerIndexCBoxAulas(HorarioEEJueves.IdAula);
                }
                else { this.ExisteHorario_Jueves = false; }
            }
        }

        private void RecuperarHorarioViernes()
        {
            if (this.periodoSeleccionado != null && this.eeSeleccionada != null)
            {
                HorarioEEViernes = HorarioDao.RecuperarHorarioEE(periodoSeleccionado.IdPeriodo, VIERNES, eeSeleccionada.IdEE);
                if (HorarioEEViernes.IdEE != 0)
                {
                    this.ExisteHorario_Viernes = true;
                    this.ChkBox_Viernes = true;
                    this.Value_HoraInicio_Viernes = HorarioEEViernes.HoraInicio;
                    this.Value_HoraFin_Viernes = HorarioEEViernes.HoraFin;
                    this.CBox_Aula_Viernes_Index = ObtenerIndexCBoxAulas(HorarioEEViernes.IdAula);
                }
                else { this.ExisteHorario_Viernes = false; }
            }
        }

        private void RecuperarHorarioSabado()
        {
            if (this.periodoSeleccionado != null && this.eeSeleccionada != null)
            {
                HorarioEESabado = HorarioDao.RecuperarHorarioEE(periodoSeleccionado.IdPeriodo, SABADO, eeSeleccionada.IdEE);
                if (HorarioEESabado.IdEE != 0)
                {
                    this.ExisteHorario_Sabado = true;
                    this.ChkBox_Sabado = true;
                    this.Value_HoraInicio_Sabado = HorarioEESabado.HoraInicio;
                    this.Value_HoraFin_Sabado = HorarioEESabado.HoraFin;
                    this.CBox_Aula_Sabado_Index = ObtenerIndexCBoxAulas(HorarioEESabado.IdAula);
                }
                else { this.ExisteHorario_Sabado = false; }
            }
        }

        #endregion Recuperar Horarios Existentes

        #endregion Datos Obtenidos

        #region Registrar Datos

        public void Registrar()
        {
            if (ChkBox_Lunes == true) { CrearHorarioLunes(); }
            if (ChkBox_Martes == true) { CrearHorarioMartes(); }
            if (ChkBox_Miercoles == true) { CrearHorarioMiercoles(); }
            if (ChkBox_Jueves == true) { CrearHorarioJueves(); }
            if (ChkBox_Viernes == true) { CrearHorarioViernes(); }
            if (ChkBox_Sabado == true) { CrearHorarioViernes(); }

            MessageBox.Show("Todos los horarios registrados. Cerrando Ventana...","Aviso");
            Application.Current.MainWindow.Close();
        }

        private void CrearHorarioLunes()
        {
            HorarioEE horario = new HorarioEE();
            horario.HoraInicio = Value_HoraInicio_Lunes;
            horario.HoraFin = Value_HoraFin_Lunes;
            horario.DiaSemana = LUNES;
            horario.IdEE = CBox_EE_Selected.IdEE;
            horario.IdAula = CBox_Aula_Lunes_Selected.IdAula;

            bool respuestaBD;
            if (ExisteHorario_Lunes == true) //Actualizar Horario Existente
            {
                horario.IdHorario = HorarioEELunes.IdHorario;
                respuestaBD = HorarioDao.ActualizarHorario(horario);
                if (respuestaBD != false) { MessageBox.Show("Horario del Lunes Actualizado con exito"); }
                else { MessageBox.Show("No se actualizó el horario del lunes", "Error"); }
            }
            else //Crear Nuevo
            {
                respuestaBD = HorarioDao.RegistrarHorario(horario);
                if (respuestaBD != false) { MessageBox.Show("Horario del Lunes Registrado con exito"); }
                else { MessageBox.Show("No se registró el horario del Lunes", "Error"); }
            }
        }

        private void CrearHorarioMartes() 
        {
            HorarioEE horario = new HorarioEE();
            horario.HoraInicio = Value_HoraInicio_Martes;
            horario.HoraFin = Value_HoraFin_Martes;
            horario.DiaSemana = MARTES;
            horario.IdEE = CBox_EE_Selected.IdEE;
            horario.IdAula = CBox_Aula_Martes_Selected.IdAula;

            bool respuestaBD;
            if (ExisteHorario_Martes == true) //Actualizar Horario Existente
            {
                horario.IdHorario = HorarioEEMartes.IdHorario;
                respuestaBD = HorarioDao.ActualizarHorario(horario);
                if (respuestaBD != false) { MessageBox.Show("Horario del martes Actualizado con exito"); }
                else { MessageBox.Show("No se actualizó el horario del martes", "Error"); }
            }
            else //Crear Nuevo
            {
                respuestaBD = HorarioDao.RegistrarHorario(horario);
                if (respuestaBD != false) { MessageBox.Show("Horario del martes Registrado con exito"); }
                else { MessageBox.Show("No se registró el horario del martes", "Error"); }
            }
        }

        private void CrearHorarioMiercoles() 
        {
            HorarioEE horario = new HorarioEE();
            horario.HoraInicio = Value_HoraInicio_Miercoles;
            horario.HoraFin = Value_HoraFin_Miercoles;
            horario.DiaSemana = MIERCOLES;
            horario.IdEE = CBox_EE_Selected.IdEE;
            horario.IdAula = CBox_Aula_Miercoles_Selected.IdAula;

            bool respuestaBD;
            if (ExisteHorario_Miercoles == true) //Actualizar Horario Existente
            {
                horario.IdHorario = HorarioEEMiercoles.IdHorario;
                respuestaBD = HorarioDao.ActualizarHorario(horario);
                if (respuestaBD != false) { MessageBox.Show("Horario del miercoles Actualizado con exito"); }
                else { MessageBox.Show("No se actualizó el horario del miercoles", "Error"); }
            }
            else //Crear Nuevo
            {
                respuestaBD = HorarioDao.RegistrarHorario(horario);
                if (respuestaBD != false) { MessageBox.Show("Horario del miercoles Registrado con exito"); }
                else { MessageBox.Show("No se registró el horario del miercoles", "Error"); }
            }
        }

        private void CrearHorarioJueves() 
        {
            HorarioEE horario = new HorarioEE();
            horario.HoraInicio = Value_HoraInicio_Jueves;
            horario.HoraFin = Value_HoraFin_Jueves;
            horario.DiaSemana = JUEVES;
            horario.IdEE = CBox_EE_Selected.IdEE;
            horario.IdAula = CBox_Aula_Jueves_Selected.IdAula;

            bool respuestaBD;
            if (ExisteHorario_Jueves == true) //Actualizar Horario Existente
            {
                horario.IdHorario = HorarioEEJueves.IdHorario;
                respuestaBD = HorarioDao.ActualizarHorario(horario);
                if (respuestaBD != false) { MessageBox.Show("Horario del jueves Actualizado con exito"); }
                else { MessageBox.Show("No se actualizó el horario del jueves", "Error"); }
            }
            else //Crear Nuevo
            {
                respuestaBD = HorarioDao.RegistrarHorario(horario);
                if (respuestaBD != false) { MessageBox.Show("Horario del miercoles Registrado con exito"); }
                else { MessageBox.Show("No se registró el horario del miercoles", "Error"); }
            }
        }

        private void CrearHorarioViernes() 
        {
            HorarioEE horario = new HorarioEE();
            horario.HoraInicio = Value_HoraInicio_Viernes;
            horario.HoraFin = Value_HoraFin_Viernes;
            horario.DiaSemana = VIERNES;
            horario.IdEE = CBox_EE_Selected.IdEE;
            horario.IdAula = CBox_Aula_Viernes_Selected.IdAula;

            bool respuestaBD;
            if (ExisteHorario_Viernes == true) //Actualizar Horario Existente
            {
                horario.IdHorario = HorarioEEViernes.IdHorario;
                respuestaBD = HorarioDao.ActualizarHorario(horario);
                if (respuestaBD != false) { MessageBox.Show("Horario del viernes Actualizado con exito"); }
                else { MessageBox.Show("No se actualizó el horario del viernes", "Error"); }
            }
            else //Crear Nuevo
            {
                respuestaBD = HorarioDao.RegistrarHorario(horario);
                if (respuestaBD != false) { MessageBox.Show("Horario del viernes Registrado con exito"); }
                else { MessageBox.Show("No se registró el horario del viernes", "Error"); }
            }
        }

        private void CrearHorarioSabado()
        {
            HorarioEE horario = new HorarioEE();
            horario.HoraInicio = Value_HoraInicio_Sabado;
            horario.HoraFin = Value_HoraFin_Sabado;
            horario.DiaSemana = SABADO;
            horario.IdEE = CBox_EE_Selected.IdEE;
            horario.IdAula = CBox_Aula_Sabado_Selected.IdAula;

            bool respuestaBD;
            if (ExisteHorario_Sabado == true) //Actualizar Horario Existente
            {
                horario.IdHorario = HorarioEESabado.IdHorario;
                respuestaBD = HorarioDao.ActualizarHorario(horario);
                if (respuestaBD != false) { MessageBox.Show("Horario del sabado Actualizado con exito"); }
                else { MessageBox.Show("No se actualizó el horario del sabado", "Error"); }
            }
            else //Crear Nuevo
            {
                respuestaBD = HorarioDao.RegistrarHorario(horario);
                if (respuestaBD != false) { MessageBox.Show("Horario del sabado Registrado con exito"); }
                else { MessageBox.Show("No se registró el horario del sabado", "Error"); }
            }
        }

        #endregion Registrar Datos

        #region Activar y Desactivar Dias
        public void ActivarDesactivarElementosLunes()
        {
            if (this.ChkBox_Lunes == true)
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

        #region Utilidades

        private void ResetearHorasYAulas()
        {
            this.ChkBox_Lunes = false;
            this.ChkBox_Martes = false;
            this.ChkBox_Miercoles = false;
            this.ChkBox_Jueves = false;
            this.ChkBox_Viernes = false;
            this.ChkBox_Sabado = false;

            this.Value_HoraInicio_Lunes = DateTime.Parse("12:00:00");
            this.Value_HoraInicio_Martes = DateTime.Parse("12:00:00");
            this.Value_HoraInicio_Miercoles = DateTime.Parse("12:00:00");
            this.Value_HoraInicio_Jueves = DateTime.Parse("12:00:00");
            this.Value_HoraInicio_Viernes = DateTime.Parse("12:00:00");
            this.Value_HoraInicio_Sabado = DateTime.Parse("12:00:00");

            this.Value_HoraFin_Lunes = DateTime.Parse("12:00:00");
            this.Value_HoraFin_Martes = DateTime.Parse("12:00:00");
            this.Value_HoraFin_Miercoles = DateTime.Parse("12:00:00");
            this.Value_HoraFin_Jueves = DateTime.Parse("12:00:00");
            this.Value_HoraFin_Viernes = DateTime.Parse("12:00:00");
            this.Value_HoraFin_Sabado = DateTime.Parse("12:00:00");

            this.CBox_Aula_Lunes_Selected = null;
            this.CBox_Aula_Martes_Selected = null;
            this.CBox_Aula_Miercoles_Selected = null;
            this.CBox_Aula_Jueves_Selected = null;
            this.CBox_Aula_Viernes_Selected = null;
            this.CBox_Aula_Sabado_Selected = null;
        }

        private int ObtenerIndexCBoxAulas(int idAula)
        {
            return this.CBox_Aula_Items.IndexOf(
                            this.CBox_Aula_Items.Where<Aula>(x => x.IdAula == idAula).FirstOrDefault());
        }

        #endregion Utilidades

        #endregion METHODS
    }
}
