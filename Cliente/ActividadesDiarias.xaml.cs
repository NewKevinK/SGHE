﻿using SGHE.LogicaNegocio;
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
    /// Lógica de interacción para ActividadesDiarias.xaml
    /// </summary>
    public partial class ActividadesDiarias : Window
    {
        public ActividadesDiarias()
        {
            InitializeComponent();

            DataContext = new ActividadesDiariasViewModel();

            _carouselDABExperienciasEducativas.SelectionChanged += _carouselDABEE_SelectionChanged;

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            lblTime.Content = DateTime.Now.ToString("hh:mm tt");
            lblFechaActual.Content = DateTime.Now.ToString("dddd dd MMMM yyyy");
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

        private void Click_Volver(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Click_HorarioCompleto(object sender, RoutedEventArgs e)
        {

        }
    }
}
