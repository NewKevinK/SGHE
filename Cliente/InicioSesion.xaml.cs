﻿using SGHE.Cliente;
using SGHE.LogicaNegocio.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    /// Lógica de interacción para InicioSesion.xaml
    /// </summary>
    public partial class InicioSesion : Window
    {
        //Alumno
        public String EmailUsuario1 = "S19001100";
        public String ContraseñaUsuario1 = "abc123";

        //Administrativo
        public String EmailUsuario2 = "PF1604";
        public String ContraseñaUsuario2 = "abc123";

        public InicioSesion()
        {
            InitializeComponent();

        }

        private async void btnIniciarSesion_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPass.Password.ToString();

            //Validación Usuario 1
            //email.Equals(EmailUsuario1) && password.Equals(ContraseñaUsuario1)
            /*if (validarCorreo().tipoUsuario)
            {

                InicioAlumno inicioAlumno = new InicioAlumno();
                this.Close();
                System.Threading.Thread.Sleep(1000);
                inicioAlumno.Show();
            }*/
            if (email.Equals(EmailUsuario2) && password.Equals(ContraseñaUsuario2))
            {

                InicioAlumno inicioAlumno = new InicioAlumno();
                this.Close();
                System.Threading.Thread.Sleep(1000);
                inicioAlumno.Show();
            }
            else
            {
                MessageBox.Show("Credenciales Incorrectas");
            }
            //Validación Usuario 2
            if (email.Equals(EmailUsuario2) && password.Equals(ContraseñaUsuario2))
            {
                InicioAdministrativo inicioAdministrativo = new InicioAdministrativo();
                this.Close();
                inicioAdministrativo.Show();
            }
            else
            {
                MessageBox.Show("Credenciales Incorrectas");
            }
            /*if (email.Equals(EmailUsuario2) && password.Equals(ContraseñaUsuario2))
            {
                InicioDocente inicioDocente= new InicioDocente();
                this.Close();
                inicioDocente.Show();
            }
            else
            {
                MessageBox.Show("Credenciales Incorrectas");
            }*/
        }





        /*private Persona validarCorreo()
        {
            Persona respuest;
             UsuarioDao usuarioValidacion=new UsuarioDao();

            int idUsuarui=usuarioValidacion.Autenticacion(txtEmail.Text,txtPass.Password.ToString());
            Persona UsuarioAutenticado = new Persona();
            UsuarioAutenticado=usuarioValidacion.ObtenerUsuario(idUsuarui);
            respuesta = UsuarioAutenticado.tipoUsuario;
            return respuesta;
        }*/
        private void btnCrearCuenta_Click
(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Aún en desarrollo...");
        }

        private void btnRecuperarPass_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Aún en desarrollo...");
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}

