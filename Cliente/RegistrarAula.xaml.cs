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
using System.Drawing;
using SGHE.LogicaNegocio.POCO;
using Org.BouncyCastle.Utilities;
using SGHE.LogicaNegocio.DAO;

namespace SGHE.Cliente
{
    /// <summary>
    /// Lógica de interacción para RegistrarAula.xaml
    /// </summary>
    public partial class RegistrarAula : Window
    {
        public RegistrarAula()
        {
            InitializeComponent();
            DatosComboBoxEdificio();
            DatosComboBoxTipoAula();
        }

        private void CancelarRegistroAula(object sender, RoutedEventArgs e)
        {

        }

        private void RegistroAula(object sender, RoutedEventArgs e)
        {
            if (RecuperarDatos())
            {
                this.Close();
            }
            
        }

        public bool RecuperarDatos()
        {
            bool registro = false;

            if (ValidarDatos())
            {
                Aula aula = new Aula(tbCodigoAula.Text, int.Parse(cbEdificioAula.Text),cbTipoAula.Text);
                GuardarAula(aula);
                registro = true;
            }
            else
            {
                MessageBox.Show("Dato Faltante", "Llena todos los campos", MessageBoxButton.OK);
            }

            return registro;
        }

        public bool ValidarDatos()
        {
            bool valido = false;

            if (tbCodigoAula.Text.Equals(""))
            {
                valido = false;
            }
            else
            {
                valido = true;
            }

            return valido;
        }

        public void GuardarAula(Aula aula)
        {
            AulaDao aulaDao = new AulaDao();
            string mensaje = aulaDao.AgregarAula(aula);
            MessageBox.Show(mensaje, "Salida", MessageBoxButton.OK);
        }

        public void DatosComboBoxEdificio()
        {
            cbEdificioAula.Items.Add("1");
            cbEdificioAula.Items.Add("2");
            cbEdificioAula.Items.Add("3");
            cbEdificioAula.Items.Add("4");
        }

        public void DatosComboBoxTipoAula()
        {
            cbTipoAula.Items.Add("Presencial");
            cbTipoAula.Items.Add("Mixta");
            cbTipoAula.Items.Add("Virtual");
        }
    }
}
