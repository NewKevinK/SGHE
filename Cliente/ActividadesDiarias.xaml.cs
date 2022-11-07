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

namespace SGHE.Cliente
{
    /// <summary>
    /// Lógica de interacción para ActividadesDiarias.xaml
    /// </summary>
    public partial class ActividadesDiarias : Window
    {
        public ActividadesDiarias()
        {
            InitializeComponent();

            DataContext = new ActividadesDiariasViewModel();

            _carouselDABExperienciasEducativas.SelectionChanged += _carouselDABEE_SelectionChanged;
        }

        private void _carouselDABEE_SelectionChanged(FrameworkElement selectedElement)
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
            _carouselDABExperienciasEducativas.RotateRight();
        }

        private void _buttonRightArrow_Click(object sender, RoutedEventArgs e)
        {
            _carouselDABExperienciasEducativas.RotateLeft();
        }

    }
}
