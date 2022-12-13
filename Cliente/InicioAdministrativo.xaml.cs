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
    /// Lógica de interacción para InicioAdministrativo.xaml
    /// </summary>
    public partial class InicioAdministrativo : Window
    {
        public InicioAdministrativo()
        {
            InitializeComponent();
        }

        private void Click_Aulas(object sender, RoutedEventArgs e)
        {
            Aulas aulas = new Aulas();
            aulas.Show();
        }

        private void Click_CerrarSesion(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Click_RegistrarNuevaAula(object sender, RoutedEventArgs e)
        {
            RegistrarAula registrarAula = new RegistrarAula();
            registrarAula.Show();
        }
    }
}
