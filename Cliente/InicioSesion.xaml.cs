using SGHE.Cliente;
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
            UsuarioDao usuariodao = new UsuarioDao();
            Persona personaAuthh = new Persona();
            personaAuthh = usuariodao.Autenticacion(txtPass.Password.ToString(), txtEmail.Text);

            //MessageBox.Show(personaAuthh.idUsuario + "y el otro es: "+personaAuthh.idTipoUsuario);
            if (personaAuthh.idTipoUsuario == 1)//ADMINISTRADOR
            {
                usuariodao.ObtenerUsuario(personaAuthh);
                InicioAdministrativo inicioAdministrativo = new InicioAdministrativo();
                this.Close();
                inicioAdministrativo.Show();
            }
            if (personaAuthh.idTipoUsuario == 2)
            {

            }
            if (personaAuthh.idTipoUsuario == 3)
            {

            }
            if (personaAuthh.idTipoUsuario == 4)
            {
                InicioAlumno inicioAlumno = new InicioAlumno();
                this.Close();
                inicioAlumno.Show();
            }
            if (personaAuthh.idTipoUsuario == 5)
            {

                InicioAlumno inicioAlumno = new InicioAlumno();
                this.Close();
                System.Threading.Thread.Sleep(1000);
                inicioAlumno.Show();
            }
            if (personaAuthh.idTipoUsuario == 0)
            {
                MessageBox.Show("Credenciales Incorrectas");
            }

        }

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

