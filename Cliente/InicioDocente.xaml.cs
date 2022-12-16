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
    /// Lógica de interacción para InicioDocente.xaml
    /// </summary>
    public partial class InicioDocente : Window
    {
        public InicioDocente()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Experiencias(object sender, RoutedEventArgs e)
        {
            ExperienciasEducativasDocente experienciasEducativasDocente = new ExperienciasEducativasDocente();
            experienciasEducativasDocente.Show();
            this.Close();
        }

        private void Click_CerrarSesion(object sender, RoutedEventArgs e)
        {
            InicioSesion inicioSesion = new InicioSesion();
            inicioSesion.Show();
            this.Close();
        }
    }
}
