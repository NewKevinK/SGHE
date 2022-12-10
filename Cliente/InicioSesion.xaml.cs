using SGHE.Cliente;
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
            if (email.Equals(EmailUsuario1) && password.Equals(ContraseñaUsuario1))
            {
                InicioAlumno inicioAlumno = new InicioAlumno();
                this.Close();
                System.Threading.Thread.Sleep(1000);
                inicioAlumno.Show();
            }
            else
            {
                //Validación Usuario 2
                if(email.Equals(EmailUsuario2) && password.Equals(ContraseñaUsuario2))
                {
                    InicioAdministrativo inicioAdministrativo = new InicioAdministrativo();
                    this.Close();
                    inicioAdministrativo.Show();
                }
                else
                {
                    MessageBox.Show("Credenciales Incorrectas");
                }
            }

            

        }

        private void btnCrearCuenta_Click(object sender, RoutedEventArgs e)
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
