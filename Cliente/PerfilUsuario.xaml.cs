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
    public partial class PerfilUsuario : Window
    {
        Alumno alumnoobtenidol;
        Docente Docenterecuperado ;
        Persona AdministrativoObtenidol;
        public PerfilUsuario()
        {
            InitializeComponent();
        }

        public PerfilUsuario(Alumno AlumnoRecuperado)
        {
            InitializeComponent();
            alumnoobtenidol = AlumnoRecuperado;
            RecuperarDatosAlumno(alumnoobtenidol);
            
        }
        public PerfilUsuario(Docente docenteRecuperado)
        {
            InitializeComponent();
            Docenterecuperado = docenteRecuperado;
            RecuperarDatosDocente(Docenterecuperado);

        }
        public PerfilUsuario(Persona administrativoRecuperado)
        {
            InitializeComponent();
            AdministrativoObtenidol = administrativoRecuperado;
            RecuperarDatosDocente(AdministrativoObtenidol);
        }
        private void RecuperarDatosAlumno(Alumno AlumnoRecuperado)
        {
            tbNombre.Text=AlumnoRecuperado.Nombre;
            tbApellidoPaterno.Text=AlumnoRecuperado.ApellidoPaterno;
            tbApellidoMaterno.Text=AlumnoRecuperado.ApellidoMaterno;
            tbFechaNacimiento.Text=AlumnoRecuperado.FechaNacimiento.ToString();
            tbTelefono.Text=AlumnoRecuperado.Telefono;
            tbEmail.Text=AlumnoRecuperado.Email;
            tbDomicilio.Text=AlumnoRecuperado.Domicilio;
        }

        private void RecuperarDatosDocente(Docente docenterecuperado)
        {
            tbNombre.Text = docenterecuperado.Nombre;
            tbApellidoPaterno.Text = docenterecuperado.ApellidoPaterno;
            tbApellidoMaterno.Text = docenterecuperado.ApellidoMaterno;
            tbFechaNacimiento.Text = docenterecuperado.FechaNacimiento.ToString();
            tbTelefono.Text = docenterecuperado.Telefono;
            tbEmail.Text = docenterecuperado.Email;
            tbDomicilio.Text = docenterecuperado.Domicilio;
        }
        private void RecuperarDatosDocente(Persona AdministrativoObtenidol)
        {
            tbNombre.Text = AdministrativoObtenidol.nombre;
            tbApellidoPaterno.Text = AdministrativoObtenidol.ApellidoPaterno;
            tbApellidoMaterno.Text = AdministrativoObtenidol.ApellidoMaterno;
            tbFechaNacimiento.Text = AdministrativoObtenidol.FechaNacimiento.ToString();
            tbTelefono.Text = AdministrativoObtenidol.Telefono;
            tbEmail.Text = AdministrativoObtenidol.Email;
            tbDomicilio.Text = AdministrativoObtenidol.Domicilio;
        }
        private void btRegresar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
