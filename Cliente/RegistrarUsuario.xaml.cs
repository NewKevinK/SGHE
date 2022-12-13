using SGHE.Cliente;
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

namespace SGHE.Client
{
    /// <summary>
    /// Lógica de interacción para RegistrarUsuario.xaml
    /// </summary>
    public partial class RegistrarUsuario : Window
    {
        string seleccion;
        public RegistrarUsuario()
        {
            InitializeComponent();
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cbTipoUsuario_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                seleccion = cbTipoUsuario.Text;
                if (seleccion.Equals("Docente"))
                {
                    FormularioDocente.Visibility = Visibility.Visible;
                    inicio.Visibility = Visibility.Hidden;   


                }  
                
               // cbTipoUsuario_Selected();
                
            }
            catch (SystemException)
            {

            }
            

        }

        private void btnCancelarDocente_Click(object sender, RoutedEventArgs e)
        {
            inicio.Visibility = Visibility.Visible;
            FormularioDocente.Visibility = Visibility.Hidden;
        }

        private void btnRegistrarDocente_Click(object sender, RoutedEventArgs e)
        {
            Inicio inicio = new Inicio();
            inicio.Show();
            this.Hide();
        }

        private void btnSiguiente_Click(object sender, RoutedEventArgs e)
        {
            DatosUsuario datosUsuario = new DatosUsuario();
            datosUsuario.Show();
            this.Close();
        }
    }
}
