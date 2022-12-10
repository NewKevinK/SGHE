using SGHE.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SGHE.Cliente
{
    /// <summary>
    /// Lógica de interacción para InicioAlumno.xaml
    /// </summary>
    public partial class InicioAlumno : Window
    {
        public InicioAlumno()
        {
            InitializeComponent();
        }

        private void Click_MiPerfil(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("En Desarrollo...", "Aviso");
        }

        private void Click_ActividadesDiarias(object sender, RoutedEventArgs e)
        {
            ActividadesDiarias actividadesDiarias = new ActividadesDiarias();
            actividadesDiarias.Show();

        }

        private void Click_HorarioCompleto(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("En Desarrollo...", "Aviso");
        }

        private void Click_Calificaciones(object sender, RoutedEventArgs e)
        {
            CalificacionesAlumno calificacionesAlumno = new CalificacionesAlumno();
            calificacionesAlumno.Show();
        }

        private void Click_InscripcionEnLinea(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Proximamente...","Aviso");
        }

        private void Click_Btn6(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Proximamente...", "Aviso");
        }

        private void Click_Btn7(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Proximamente...", "Aviso");
        }

        private void Click_Btn8(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Proximamente...", "Aviso");
        }

        private void Click_CerrarSesion(object sender, RoutedEventArgs e)
        {
            InicioSesion inicioSesion = new InicioSesion();
            this.Close();
            inicioSesion.Show();
        }
    }
}
