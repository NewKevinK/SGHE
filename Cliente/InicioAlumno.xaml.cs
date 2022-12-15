﻿using SGHE.Client;
using SGHE.LogicaNegocio.DAO;
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
    /// Lógica de interacción para InicioAlumno.xaml
    /// </summary>
    public partial class InicioAlumno : Window
    {

        #region CONSTRUCTOR

        public InicioAlumno()
        {
            InitializeComponent();
        }

        public InicioAlumno(Persona alumno)
        {
            InitializeComponent();
            this.alumnoActual = alumno;
            this.diaSemanaActual = (int)DateTime.Now.DayOfWeek;
        }

        #endregion CONSTRUCTOR

        #region ATTRIBUTES

        private Persona alumnoActual;
        private int diaSemanaActual;

        #endregion ATTRIBUTES

        #region BOTONES

        private void Click_MiPerfil(object sender, RoutedEventArgs e)
        {
            //string identificador=Persona.tipoUsuario;
            /*if (identificador = "ADMINISTRADOR")
            {
                DatosUsuario datosAdministrativo= new DatosUsuario(datospersona);
                this.Close();
                System.Threading.Thread.Sleep(1000);
                datosAdministrativo.Show();
            }
            if(identificador = "DOCENTE"){
                InicioDocente datosDocente= new DatosUsuario(datospersona);
                this.Close();
                System.Threading.Thread.Sleep(1000);
                datosDocente.Show();
            }
            if (identificador = "ALUMNO")
            {
                DatosUsuario datosAlumno= new DatosUsuario(datospersona);
                this.Close();
                System.Threading.Thread.Sleep(1000);
                datosAlumno.Show();
            }*/
        }

        private void Click_HorarioDelDia(object sender, RoutedEventArgs e)
        {
            HorarioDelDia actividadesDiarias = new HorarioDelDia(1, alumnoActual, diaSemanaActual);
            actividadesDiarias.Show();
            /*if (identificador = "ADMINISTRADOR")
            {
                HorarioDelDia horarioAdministrativo= new HorarioDelDia(datospersona);
                this.Close();
                System.Threading.Thread.Sleep(1000);
                horarioAdministrativo.Show();
            }
            if(identificador = "DOCENTE"){
                HorarioDelDia horarioDocente= new HorarioDelDia(datospersona);
                this.Close();
                System.Threading.Thread.Sleep(1000);
                horarioDocente.Show();
            }
            if (identificador = "ALUMNO")
            {
                HorarioDelDia horarioAlumno= new HorarioDelDia(datospersona);
                this.Close();
                System.Threading.Thread.Sleep(1000);
                horarioAlumno.Show();
            }*/

        }

        private void Click_HorarioCompleto(object sender, RoutedEventArgs e)
        {
            /*if (identificador = "ADMINISTRADOR")
            {
                HorarioDelDia horarioAdministrativo= new HorarioDelDia(datospersona);
                this.Close();
                System.Threading.Thread.Sleep(1000);
                horarioAdministrativo.Show();
            }
            if(identificador = "DOCENTE"){
                HorarioDelDia horarioDocente= new HorarioDelDia(datospersona);
                this.Close();
                System.Threading.Thread.Sleep(1000);
                horarioDocente.Show();
            }
            if (identificador = "ALUMNO")
            {
                HorarioDelDia horarioAlumno= new HorarioDelDia(datospersona);
                this.Close();
                System.Threading.Thread.Sleep(1000);
                horarioAlumno.Show();
            }*/
            //MessageBox.Show("En Desarrollo...", "Aviso");

            HorarioSemanal horarioSemanal = new HorarioSemanal();
            this.Close();
            System.Threading.Thread.Sleep(1000);
            horarioSemanal.Show();
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

        #endregion BOTONES
    }
}
