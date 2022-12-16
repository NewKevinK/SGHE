using SGHE.LogicaNegocio.DAO;
using SGHE.LogicaNegocio.POCO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace SGHE.LogicaNegocio
{
    public class HorarioDelDiaViewModel : INotifyPropertyChanged
    {
        #region CONSTRUCTOR
        public HorarioDelDiaViewModel()
        {

            RecuperarHorariosAlumno();
        }

        public HorarioDelDiaViewModel(int idPeriodo, Alumno alumnoActual, int diaSemanaActual)
        {
            RecuperarHorariosAlumno();

            this.idPeriodoActual = idPeriodo;
            this.alumnoActual = alumnoActual;
            this.diaSemanaActual = diaSemanaActual;
        }

        private void RecuperarHorariosAlumno()
        {
            ExperienciasEducativasDAB = new ObservableCollection<HorarioDiaEE>();
            List<HorarioDiaEE> listaHorarios = new List<HorarioDiaEE>();
            listaHorarios = HorarioDao.RecuperarHorariosAlumnoPorDia(1, 1, 1);

            foreach (HorarioDiaEE horarioDia in listaHorarios)
            {
                ExperienciasEducativasDAB.Add(horarioDia);
            }


        }

        #endregion CONSTRUCTOR

        #region ATTRIBUTES

        #endregion ATTRIBUTES

        private Alumno alumnoActual;
        private int idPeriodoActual;
        private int diaSemanaActual;

        #region PROPERTIES


        //Colección de Experiencias Educativas

        private ObservableCollection<HorarioDiaEE> _experienciasEducativasDAB;
        public ObservableCollection<HorarioDiaEE> ExperienciasEducativasDAB
        {
            get
            {
                return _experienciasEducativasDAB;
            }
            set
            {
                _experienciasEducativasDAB = value;
                NotifyPropertyChanged("ExperienciasEducativasDAB");
            }
        }

        // Experiencia Educativa (Seleccionada)


        private HorarioDiaEE _selectedExperienciaEducativaDAB;
        public HorarioDiaEE SelectedExperienciaEducativaDAB
        {
            get
            {
                return _selectedExperienciaEducativaDAB;
            }
            set
            {
                _selectedExperienciaEducativaDAB = value;
                NotifyPropertyChanged("SelectedExperienciaEducativaDAB");
            }
        }

        #endregion PROPERTIES



        #region Otros Delete the selected item

        //Metodo Delete para eliminar items del carrucel
        public void Delete()
        {
            ExperienciasEducativasDAB.Remove(SelectedExperienciaEducativaDAB);
            SelectedExperienciaEducativaDAB = ExperienciasEducativasDAB[0];
        }

        //Manejador de eventos para los cambios en el carrucel - Sustituir por BaseViewModel
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion Otros
    }
}
