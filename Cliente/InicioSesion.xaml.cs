using SGHE.Cliente;
using SGHE.LogicaNegocio.DAO;
using SGHE.LogicaNegocio.POCO;
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
                
                Persona personaAdministrativa = usuariodao.RecuperarAdministradorPorId(personaAuthh.idUsuario);
                InicioAdministrativo inicioAdministrativo = new InicioAdministrativo(personaAdministrativa);
                this.Close();
                inicioAdministrativo.Show();
            }
            if (personaAuthh.idTipoUsuario == 2)//DOCENTE
            {
                Docente docenteRecuperado = usuariodao.RecuperarDocentePorId(personaAuthh.idUsuario);
                InicioDocente inicioDocente = new InicioDocente(docenteRecuperado);
                this.Close();
                inicioDocente.Show();
            }
            if (personaAuthh.idTipoUsuario == 3)
            {
                Docente docenteRecuperado = usuariodao.RecuperarDocentePorId(personaAuthh.idUsuario);
                InicioDocente inicioDocente = new InicioDocente(docenteRecuperado);
                this.Close();
                inicioDocente.Show();
            }
            if (personaAuthh.idTipoUsuario == 4)//ALUMNO
            {
                Alumno alumnorecuperado =usuariodao.RecuperarAlumnoPorId(personaAuthh.idUsuario);
                InicioAlumno inicioAlumno = new InicioAlumno(alumnorecuperado);
                this.Close();
                inicioAlumno.Show();
            }
            if (personaAuthh.idTipoUsuario == 5)
            {
                Alumno alumnorecuperado = usuariodao.RecuperarAlumnoPorId(personaAuthh.idUsuario);
                InicioAlumno inicioAlumno = new InicioAlumno(alumnorecuperado);
                this.Close();
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

