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
        public HorarioDelDiaViewModel()
        {

            RecuperarHorariosAlumno();
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


        // Delete the selected item
        public void Delete()
        {
            ExperienciasEducativasDAB.Remove(SelectedExperienciaEducativaDAB);
            SelectedExperienciaEducativaDAB = ExperienciasEducativasDAB[0];
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion INotifyPropertyChanged
    }
}
