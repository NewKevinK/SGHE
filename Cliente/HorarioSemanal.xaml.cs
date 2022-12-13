﻿using SGHE.Cliente.Recursos.ControlDeUsuario;
using System;
using System.Collections.Generic;
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
        List<HoraSemanalUs> listaArreglo = new List<HoraSemanalUs>();
        public HorarioSemanal()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();

            IniciarGridHorario();
            cargarElementosHorario();
        }

        private void cargarElementosHorario()
        {
            Hora7_9.HoraInicio.Text = "7:00";
            Hora7_9.HoraFin.Text = "9:00";

            Hora9_11.HoraInicio.Text = "9:00";
            Hora9_11.HoraFin.Text = "11:00";

            Hora11_13.HoraInicio.Text = "11:00";
            Hora11_13.HoraFin.Text = "13:00";

            Hora13_15.HoraInicio.Text = "13:00";
            Hora13_15.HoraFin.Text = "15:00";

            Hora15_17.HoraInicio.Text = "15:00";
            Hora15_17.HoraFin.Text = "17:00";

            Hora17_19.HoraInicio.Text = "17:00";
            Hora17_19.HoraFin.Text = "19:00";

            Hora19_21.HoraInicio.Text = "19:00";
            Hora19_21.HoraFin.Text = "21:00";

            listaArreglo.Add(Hora7_9);
            listaArreglo.Add(Hora9_11);
            listaArreglo.Add(Hora11_13);
            listaArreglo.Add(Hora13_15);
            listaArreglo.Add(Hora15_17);
            listaArreglo.Add(Hora17_19);
            listaArreglo.Add(Hora19_21);

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