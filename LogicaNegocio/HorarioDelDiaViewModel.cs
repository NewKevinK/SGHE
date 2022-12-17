using SGHE.LogicaNegocio.DAO;
using SGHE.LogicaNegocio.POCO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows;

namespace SGHE.LogicaNegocio
{
    public class HorarioDelDiaViewModel : BaseViewModel
    {

        #region CONSTRUCTOR
        public HorarioDelDiaViewModel()
        {
            RecuperarHorariosAlumno();
        }

        public HorarioDelDiaViewModel(int idPeriodo, Alumno alumnoActual, int diaSemanaActual)
        {
            this.idPeriodoActual = idPeriodo;
            this.alumnoActual = alumnoActual;
            this.diaSemanaActual = diaSemanaActual;
            RecuperarHorariosAlumno();
        }

        #endregion CONSTRUCTOR

        #region ATTRIBUTES

        private Alumno alumnoActual;
        private int idPeriodoActual;
        private int diaSemanaActual;
        private ObservableCollection<DetalleHorario> _experienciasEducativasDAB;
        private DetalleHorario _selectedExperienciaEducativaDAB;

        #endregion ATTRIBUTES

        #region PROPERTIES

        //Colección de Experiencias Educativas
        public ObservableCollection<DetalleHorario> ExperienciasEducativasDAB
        {
            get { return this._experienciasEducativasDAB; }
            set { SetValue(ref this._experienciasEducativasDAB, value); }
        }

        // Experiencia Educativa (Seleccionada)
        public DetalleHorario SelectedExperienciaEducativaDAB
        {
            get { return this._selectedExperienciaEducativaDAB; }
            set { SetValue(ref this._selectedExperienciaEducativaDAB, value); }
        }

        #endregion PROPERTIES

        #region METHODS

        private void RecuperarHorariosAlumno()
        {
            ExperienciasEducativasDAB = new ObservableCollection<DetalleHorario>();
            List<DetalleHorario> listaHorarios = new List<DetalleHorario>();
            UsuarioDao horarioID = new UsuarioDao();
            int idAlumno = horarioID.RecuperarIdAlumnoDeUsuario(alumnoActual.IdUsuario);

            listaHorarios = HorarioDao.RecuperarHorariosAlumnoPorDia(idPeriodoActual, diaSemanaActual, idAlumno);
            if(listaHorarios.Count > 0)
            {
                foreach (DetalleHorario horarioDia in listaHorarios)
                {
                    ExperienciasEducativasDAB.Add(horarioDia);
                }
            }
            else
            {
                MessageBox.Show("No hay actividades para hoy", "Aviso");
                Application.Current.MainWindow.Close();
            }            
        }

        #endregion
    }
}
