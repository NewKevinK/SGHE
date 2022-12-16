using SGHE.Client;
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
    /// Lógica de interacción para InicioDocente.xaml
    /// </summary>
    public partial class InicioDocente : Window
    {
        Docente docenteConseguidol;
        public InicioDocente()
        {
            InitializeComponent();
        }
        public InicioDocente(Docente docenteRecuperado)
        {
            docenteConseguidol=docenteRecuperado;
            InitializeComponent();
        }

        private void Button_Experiencias(object sender, RoutedEventArgs e)
        {
            ExperienciasEducativasDocente experienciasEducativasDocente = new ExperienciasEducativasDocente(docenteConseguidol);
            experienciasEducativasDocente.Show();
        }

        private void Click_CerrarSesion(object sender, RoutedEventArgs e)
        {
            InicioSesion inicioSesion = new InicioSesion();
            inicioSesion.Show();
            this.Close();
        }

        private void Button_Perfil(object sender, RoutedEventArgs e)
        {
            PerfilUsuario abrirPerfil = new PerfilUsuario(docenteConseguidol);
            abrirPerfil.Show();
        }
    }
}
