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
    /// Lógica de interacción para ActualizarAula.xaml
    /// </summary>
    public partial class ActualizarAula : Window
    {
        String codigoAula;
        int idAula;
        public ActualizarAula()
        {
            InitializeComponent();
            DatosComboBoxEdificio();
            DatosComboBoxEstadoAula();
            DatosComboBoxTipoAula();
        }
        public ActualizarAula(String codigoAula)
        {
            InitializeComponent();
            DatosComboBoxEdificio();
            DatosComboBoxEstadoAula();
            DatosComboBoxTipoAula();
            this.codigoAula = codigoAula;
            MostrarDatos();
        }


        private void Actualizar(object sender, RoutedEventArgs e)
        {
            if (RecuperarDatos() == 1)
            {
                MessageBox.Show("Aula Actualizada con exíto", "Aula Actualizada");
                Aulas aulas = new Aulas();
                aulas.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("La Aula no se ha podido actualizar", "Error");
            }
        }

        public int RecuperarDatos()
        {
            string codigoAula = tbCodigoAula.Text;
            string estado = cbEstadoAula.Text;
            string tipoAula = cbTipoAula.Text;
            string edificio = cbEdificioAula.Text;
            Aula aula = new Aula(codigoAula, estado, int.Parse(edificio), tipoAula);
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
            int confirmacion = aulaDao.ActualizarAula(idAula, aula);

            return confirmacion;
        }

        public void MostrarDatos()
        {
            Aula aula = new Aula();
            AulaDao aulaDao = new AulaDao();
            aula = aulaDao.RecuperarAulaPorCodigo(codigoAula);
            tbCodigoAula.Text = aula.CodigoAula;
            cbEstadoAula.Text = aula.Estado;
            cbEdificioAula.Text = aula.IdEdificio.ToString();
            cbTipoAula.Text = aula.TipoAula;
            idAula = aula.IdAula;
        }
    }
}
