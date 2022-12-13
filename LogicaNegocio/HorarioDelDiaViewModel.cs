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
            ExperienciasEducativasDAB = new ObservableCollection<HorarioDiaEE>();

            ExperienciasEducativasDAB.Add(new HorarioDiaEE() { NombreEE = "Desarrollo de Software", HoraInicio = "5:00 pm", HoraFin = "8:00 pm", NombreCompletoDocente = "Garcia Trujillo Carlos", CodigoAula = "112", NRC = "83501" });
            ExperienciasEducativasDAB.Add(new HorarioDiaEE() { NombreEE = "Desarrollo de Sistemas en Red", HoraInicio = "3:00 pm", HoraFin = "5:00 pm", NombreCompletoDocente = "Dominguez Isidro Saul", CodigoAula = "113", NRC = "87276" });
            ExperienciasEducativasDAB.Add(new HorarioDiaEE() { NombreEE = "Diseño de Interfaces de Usuario", HoraInicio = "1:00 pm", HoraFin = "3:00 pm", NombreCompletoDocente = "Reyes Flores Itzel Alessandra", CodigoAula = "113", NRC = "87275" });
            ExperienciasEducativasDAB.Add(new HorarioDiaEE() { NombreEE = "Paradigmas de la Programación", HoraInicio = "11:00 am", HoraFin = "1:00 pm", NombreCompletoDocente = "Oscar Alonso Ramirez", CodigoAula = "CC2", NRC = "85012" });

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
