using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace SGHE.Cliente
{
    /// <summary>
    /// Lógica de interacción para HorarioSemanal.xaml
    /// </summary>
    public partial class HorarioSemanal : Window
    {
        public HorarioSemanal()
        {
            InitializeComponent();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();

            IniciarGridHorario();
            
        }

        private void IniciarGridHorario()
        {
            RowDefinition sieteAM = new RowDefinition();
            GridLength length = new GridLength();
            sieteAM.Height = length;

            GridHorario.RowDefinitions.Add(sieteAM);
        }

        void timer_Tick(object sender, EventArgs e)
        {
            lblTime.Content = DateTime.Now.ToString("hh:mm tt");
            lblFechaActual.Content = DateTime.Now.ToString("dddd dd MMMM yyyy");
        }
    }
}
