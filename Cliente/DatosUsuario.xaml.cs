using SGHE.Client;
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
    /// Lógica de interacción para DatosUsuario.xaml
    /// </summary>
    public partial class DatosUsuario : Window
    {
        string tipoUsuario;
        public DatosUsuario()
        {
            InitializeComponent();
        }

        public DatosUsuario(string tipoUsuario)
        {
            InitializeComponent();
            this.tipoUsuario = tipoUsuario;
            LlenarDatosComboBoxAlumno();
            OcutarDatos();
        }

        private void OcutarDatos()
        {
            if (tipoUsuario == "Docente")
            {
                OcultarDatosAlumno();
            }
            if (tipoUsuario == "Estudiante")
            {
                OcultarDatosDocente();
            }
        }

        private void OcultarDatosDocente()
        {
            tbNumeroDocente.Visibility = Visibility.Hidden;
            lbNumeroDocente.Visibility = Visibility.Hidden;
        }

        private void OcultarDatosAlumno()
        {
            tbMatriculaAlumno.Visibility = Visibility.Hidden;
            lbMatricula.Visibility = Visibility.Hidden;
            cbCarreraAlumno.Visibility = Visibility.Hidden;
            lbCarrera.Visibility = Visibility.Hidden;
        }

        private void btGuardarUsuario_Click(object sender, RoutedEventArgs e)
        {
            if (tipoUsuario == "Docente")
            {
                RecuperarDatosDocente();
            }
            if(tipoUsuario == "Estudiante")
            {
                RecuperarDatosAlumno();
            }
        }

        private void RecuperarDatosAlumno()
        {
            DateTime dateTime = DateTime.Parse(tbFechaNacimiento.Text);
            Alumno alumno = new Alumno(1, tbNombre.Text, tbApellidoPaterno.Text, tbApellidoMaterno.Text, dateTime, tbTelefono.Text, tbEmail.Text, tbDomicilio.Text, pbContrasena.Password.ToString(), 4,tbMatriculaAlumno.Text,cbCarreraAlumno.SelectedIndex+1);
            RegistrarAlumno(alumno);
        }

        private void RegistrarAlumno(Alumno alumno)
        {
            UsuarioDao usuarioDao = new UsuarioDao();
            usuarioDao.RegistrarUsuario(alumno);
            alumno.IdUsuario = usuarioDao.RecuperarIdUsuario(alumno);
            string mensaje = usuarioDao.RegistrarAlumno(alumno);
            MostrarMensaje(mensaje);
            this.Close();
        }

        private void RecuperarDatosDocente()
        {
            DateTime dateTime = DateTime.Parse(tbFechaNacimiento.Text);
            Docente docente = new Docente(1,tbNombre.Text,tbApellidoPaterno.Text,tbApellidoMaterno.Text,dateTime,tbTelefono.Text,tbEmail.Text,tbDomicilio.Text,pbContrasena.Password.ToString(),2,tbNumeroDocente.Text);
            RegistrarDocente(docente);
            
        }

        private void RegistrarDocente(Docente docente)
        {
            UsuarioDao usuarioDao = new UsuarioDao();
            usuarioDao.RegistrarUsuario(docente);
            docente.IdUsuario = usuarioDao.RecuperarIdUsuario(docente);
            string mensaje = usuarioDao.RegistrarDocente(docente);
            MostrarMensaje(mensaje);
            this.Close();
        }

        private void MostrarMensaje(string mensaje)
        {
            MessageBox.Show(mensaje, "Salida");
        }

        private void LlenarDatosComboBoxAlumno()
        {
            cbCarreraAlumno.Items.Add("Ingenieria de Software");
            cbCarreraAlumno.Items.Add("Redes de servicio de computo");
        }

        private void btRegresar_Click(object sender, RoutedEventArgs e)
        {
            RegistrarUsuario registrarUsuario = new RegistrarUsuario();
            registrarUsuario.Show();
            this.Close();
        }
    }
}
