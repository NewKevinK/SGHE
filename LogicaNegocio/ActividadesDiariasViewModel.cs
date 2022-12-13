using SGHE.LogicaNegocio.POCO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace SGHE.LogicaNegocio
{
    public class ActividadesDiariasViewModel : INotifyPropertyChanged
    {
        public ActividadesDiariasViewModel()
        {
            ExperienciasEducativasDAB = new ObservableCollection<ExperienciaEducativa1>();
            
            ExperienciasEducativasDAB.Add(new ExperienciaEducativa1() { nombre = "Desarrollo de Software", hora="5:00 pm - 8:00 pm", profesor = "Garcia Trujillo Carlos", aula = "112", nrc = "83501" });
            ExperienciasEducativasDAB.Add(new ExperienciaEducativa1() { nombre = "Desarrollo de Sistemas en Red", hora = "3:00 pm - 5:00 pm", profesor = "Dominguez Isidro Saul", aula = "113", nrc = "87276" });
            ExperienciasEducativasDAB.Add(new ExperienciaEducativa1() { nombre = "Diseño de Interfaces de Usuario", hora = "1:00 pm - 3:00 pm", profesor = "Reyes Flores Itzel Alessandra", aula = "113", nrc = "87275" });
            ExperienciasEducativasDAB.Add(new ExperienciaEducativa1() { nombre = "Paradigmas de la Programación", hora = "11:00 am - 1:00 pm", profesor = "Oscar Alonso Ramirez", aula = "CC2", nrc = "85012" });

        }

        //Colección de Experiencias Educativas

        private ObservableCollection<ExperienciaEducativa1> _experienciasEducativasDAB;
        public ObservableCollection<ExperienciaEducativa1> ExperienciasEducativasDAB
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


        private ExperienciaEducativa1 _selectedExperienciaEducativaDAB;
        public ExperienciaEducativa1 SelectedExperienciaEducativaDAB
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
