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
    /// Lógica de interacción para ActualizarAula.xaml
    /// </summary>
    public partial class ActualizarAula : Window
    {
        public ActualizarAula()
        {
            InitializeComponent();
        }


        private void Actualizar(object sender, RoutedEventArgs e)
        {
            if (RecuperarDatos() == 1)
            {
                MessageBox.Show("Aula Actualizada", "Aula Actualizada con exíto");
            }
            else
            {
                MessageBox.Show("Error", "La Aula no se ha podido actualizar");
            }
            RecuperarDatos();
        }

        public int RecuperarDatos()
        {
            string codigoAula = tbCodigoAula.Text;
            string estado = cbEstadoAula.Text;
            string tipoAula = cbTipoAula.Text;
            string edificio = cbEdificioAula.Text;
            Aula aula = new Aula(codigoAula,estado,int.Parse(edificio),tipoAula);
            return GuardarAula(aula);
            
        }

        public void DatosComboBoxTipoAula()
        {
            cbTipoAula.Items.Add("Presencial");
            cbTipoAula.Items.Add("Mixta");
            cbTipoAula.Items.Add("Virtual");

        }

        public void DatosComboBoxEstadoAula()
        {
            cbEstadoAula.Items.Add("Disponible");
            cbEstadoAula.Items.Add("Mantenimiento");
            cbEstadoAula.Items.Add("No Disponible");
        }

        public void DatosComboBoxEdificio()
        {
            cbEdificioAula.Items.Add("1");
            cbEdificioAula.Items.Add("2");
            cbEdificioAula.Items.Add("3");
        }

        public int GuardarAula(Aula aula)
        {
            
            AulaDao aulaDao = new AulaDao();
            int confirmacion = aulaDao.ActualizarAula("21", aula);

            return confirmacion;
        }
    }
}
