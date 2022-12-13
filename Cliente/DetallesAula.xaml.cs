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
    /// Lógica de interacción para DetallesAula.xaml
    /// </summary>
    public partial class DetallesAula : Window
    {
        String codigoAula;
        public DetallesAula()
        {
            InitializeComponent();
        }

        public DetallesAula(String codigoAula)
        {
            InitializeComponent();
            this.codigoAula = codigoAula;
            MostrarDatos(RecuperarAula());
        }


        public void MostrarDatos(Aula aula)
        {
            lbCodigoAula.Content = aula.CodigoAula;
            lbEstadoAula.Content = aula.Estado;
            lbEdificio.Content = aula.IdEdificio;
            lbTipoAula.Content = aula.TipoAula;
        }

        public Aula RecuperarAula()
        {
            AulaDao aulaDao = new AulaDao();
            Aula aula = new Aula();
            aula = aulaDao.RecuperarAulaPorCodigo(codigoAula);
            return aula;
        }

        private void btRegresar_Click(object sender, RoutedEventArgs e)
        {
            Aulas aulas = new Aulas();
            aulas.Show();
            this.Close();
        }

        private void btEditar_Click(object sender, RoutedEventArgs e)
        {
            ActualizarAula actualizarAula = new ActualizarAula(codigoAula);
            actualizarAula.Show();
            this.Close();
        }

    }
}
