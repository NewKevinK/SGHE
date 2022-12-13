using SGHE.LogicaNegocio;
using SGHE.LogicaNegocio.POCO;
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
using System.Windows.Threading;

namespace SGHE.Cliente
{
    /// <summary>
    /// Lógica de interacción para CalificacionesAlumno.xaml
    /// </summary>
    public partial class CalificacionesAlumno : Window
    {
        public CalificacionesAlumno()
        {
            InitializeComponent();
            DataContext = new CalificacionesAlumnoViewModel();

            _carouselCalificaciones.SelectionChanged += _carouselCalificaciones_SelectionChanged;

        }

        private void Click_Volver(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Click_Imprimir(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Proximamente", "Aviso");
        }


        private void _carouselCalificaciones_SelectionChanged(FrameworkElement selectedElement)
        {
            var viewModel = DataContext as ActividadesDiariasViewModel;
            if (viewModel == null)
            {
                return;
            }

            viewModel.SelectedExperienciaEducativaDAB = selectedElement.DataContext as ExperienciaEducativa1;
        }

        private void _buttonLeftArrow_Click(object sender, RoutedEventArgs e)
        {
            _carouselCalificaciones.RotateRight();
        }

        private void _buttonRightArrow_Click(object sender, RoutedEventArgs e)
        {
            _carouselCalificaciones.RotateLeft();
        }
    }
}
