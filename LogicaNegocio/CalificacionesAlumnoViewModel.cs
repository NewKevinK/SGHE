using SGHE.LogicaNegocio.POCO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace SGHE.LogicaNegocio
{
    public class CalificacionesAlumnoViewModel
    {

        public CalificacionesAlumnoViewModel()
        {
            ListaCalificaciones = new ObservableCollection<Calificacion>();

            ListaCalificaciones.Add(new Calificacion() { NombreEE = "Desarrollo de Software", NRC = "83501", Calificación = "--", Creditos = "8 creditos", Situación = "Primera Inscripción Ordinario" });
            ListaCalificaciones.Add(new Calificacion() { NombreEE = "Desarrollo de Sistemas en Red", NRC = "87276", Calificación = "9", Creditos = "10 creditos", Situación = "Primera Inscripción Ordinario" });
            ListaCalificaciones.Add(new Calificacion() { NombreEE = "Desarrollo de Aplicaciones", NRC = "83503", Calificación = "10", Creditos = "8 creditos", Situación = "Primera Inscripción Ordinario" });
            ListaCalificaciones.Add(new Calificacion() { NombreEE = "Diseño de Interfaces de Usuario", NRC = "87275", Calificación = "--", Creditos = "6 creditos", Situación = "Primera Inscripción Ordinario" });
            ListaCalificaciones.Add(new Calificacion() { NombreEE = "Ingles Intermedio I", NRC = "43842", Calificación = "--", Creditos = "6 creditos", Situación = "Primera Inscripción Ordinario" });
            ListaCalificaciones.Add(new Calificacion() { NombreEE = "Paradigmas de la Programación", NRC = "85012", Calificación = "8", Creditos = "8 creditos", Situación = "Segunda Inscripción Ordinario" });

            //SelectedExperienciaEducativaDAB = ExperienciasEducativasDAB[0];

            //DateTime FechaActualLabel = DateTime.Today;


        }

        //Colección de Calificaciones

        private ObservableCollection<Calificacion> _listaCalificaciones;
        public ObservableCollection<Calificacion> ListaCalificaciones
        {
            get
            {
                return _listaCalificaciones;
            }
            set
            {
                _listaCalificaciones = value;
                NotifyPropertyChanged("ListaCalificaciones");
            }
        }

        // Calificacion (Seleccionada)


        private Calificacion _selectedCalificacion;
        public Calificacion SelectedCalificacion
        {
            get
            {
                return _selectedCalificacion;
            }
            set
            {
                _selectedCalificacion = value;
                NotifyPropertyChanged("SelectedCalificacion");
            }
        }


        // Delete the selected item
        public void Delete()
        {
            ListaCalificaciones.Remove(SelectedCalificacion);
            SelectedCalificacion = ListaCalificaciones[0];
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
