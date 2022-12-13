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
        public DatosUsuario()
        {
            InitializeComponent();
        }

        private void btGuardarUsuario_Click(object sender, RoutedEventArgs e)
        {
            RecuperarDatos();
        }

        private void RecuperarDatos()
        {
            DateTime dateTime = DateTime.Parse(tbFechaNacimiento.Text);
            Docente docente = new Docente(1,tbNombre.Text,tbApellidoPaterno.Text,tbApellidoMaterno.Text,dateTime,tbTelefono.Text,tbEmail.Text,tbDomicilio.Text,pbContrasena.Password.ToString(),2);
            UsuarioDao usuarioDao = new UsuarioDao();
            usuarioDao.RegistrarUsuario(docente);
            int idUsuario = usuarioDao.RecuperarIdUsuario(docente);
            string mensaje = usuarioDao.RegistrarDocente(idUsuario, tbNumeroDocente.Text);
            MostrarMensaje(mensaje);
        }

        private void MostrarMensaje(string mensaje)
        {
            MessageBox.Show(mensaje, "Salida");
        }
    }
}
