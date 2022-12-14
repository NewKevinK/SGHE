using SGHE.LogicaNegocio;
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

namespace SGHE.Client
{
    /// <summary>
    /// Lógica de interacción para RegistroHorario.xaml
    /// </summary>
    public partial class RegistroHorario : Window
    {
        public RegistroHorario()
        {
            InitializeComponent();
            DataContext = new RegistroHorarioViewModel();
        }

        private void Cancelar(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
