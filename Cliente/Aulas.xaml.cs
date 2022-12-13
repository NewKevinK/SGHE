using SGHE.Cliente;
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

namespace SGHE.Client
{
    /// <summary>
    /// Lógica de interacción para Aulas.xaml
    /// </summary>
    public partial class Aulas : Window
    {
        List<Aula> aulas = new List<Aula>();
        int contadorAula = 0;

        public Aulas()
        {
            InitializeComponent();
            RecuperarAulas();
            MostrarAulas();
            
        }

        public void RecuperarAulas()
        {
            AulaDao aulaDao = new AulaDao();
            aulas = aulaDao.RecuperarAulas();
        }

        public void MostrarAulas()
        {
            lbAula01.Content = VerificarAula();
            lbAula02.Content = VerificarAula();
            lbAula03.Content = VerificarAula();
            lbAula04.Content = VerificarAula();
            lbAula05.Content = VerificarAula();
            lbAula06.Content = VerificarAula();
            lbAula07.Content = VerificarAula();
            lbAula08.Content = VerificarAula();
            BotonesVisibles();

        }

        private void MostrarAulasSiguientes(object sender, RoutedEventArgs e)
        {
            MostrarAulas();
        }

        private void MostrarAulasAnteriores(object sender, RoutedEventArgs e)
        {
            contadorAula -= 16;
            if (contadorAula < 0)
            {
                contadorAula = 0;
            }
            MostrarAulas();
        }

        public string VerificarAula()
        {
            string codigoAula = "";
            if (aulas.Count==contadorAula)
            {
                codigoAula = "No hay más aulas";
            }
            else
            {
                codigoAula = aulas[contadorAula].CodigoAula;
                contadorAula++;
            }
            return codigoAula;
        }

        public void BotonesVisibles()
        {
            if (lbAula01.Content.Equals("No hay más aulas"))
            {
                btDetalles01.IsEnabled = false;
            }
            else
            {
                btDetalles01.IsEnabled = true;
            }
            if (lbAula02.Content.Equals("No hay más aulas"))
            {
                btDetalles02.IsEnabled = false;
            }
            else
            {
                btDetalles02.IsEnabled = true;
            }
            if (lbAula03.Content.Equals("No hay más aulas"))
            {
                    btDetalles03.IsEnabled = false;
            }
            if (lbAula04.Content.Equals("No hay más aulas"))
            {
                    btDetalles04.IsEnabled = false;
            }
            if (lbAula05.Content.Equals("No hay más aulas"))
            {
                    btDetalles05.IsEnabled = false;
            }
            if (lbAula06.Content.Equals("No hay más aulas"))
            {
                    btDetalles06.IsEnabled = false;
            }
            if (lbAula07.Content.Equals("No hay más aulas"))
            {
                    btDetalles07.IsEnabled = false;
            }
            if (lbAula08.Content.Equals("No hay más aulas"))
            {
                    btDetalles08.IsEnabled = false; ;
            }
        }

        public void btDetalles01_Click(object sender, RoutedEventArgs e)
        {
            String codigoAula = lbAula01.Content.ToString();
            DetallesAula detallesAula = new DetallesAula(codigoAula);
            detallesAula.Show();
            this.Close();
        }

        private void btDetalles02_Click(object sender, RoutedEventArgs e)
        {
            String codigoAula = lbAula02.Content.ToString();
            DetallesAula detallesAula = new DetallesAula(codigoAula);
            detallesAula.Show();
            this.Close();
        }

        private void btDetalles03_Click(object sender, RoutedEventArgs e)
        {
            String codigoAula = lbAula03.Content.ToString();
            DetallesAula detallesAula = new DetallesAula(codigoAula);
            detallesAula.Show();
            this.Close();
        }

        private void btDetalles04_Click(object sender, RoutedEventArgs e)
        {
            String codigoAula = lbAula04.Content.ToString();
            DetallesAula detallesAula = new DetallesAula(codigoAula);
            detallesAula.Show();
            this.Close();
        }

        private void btDetalles05_Click(object sender, RoutedEventArgs e)
        {
            String codigoAula = lbAula05.Content.ToString();
            DetallesAula detallesAula = new DetallesAula(codigoAula);
            detallesAula.Show();
            this.Close();
        }

        private void btDetalles06_Click(object sender, RoutedEventArgs e)
        {
            String codigoAula = lbAula06.Content.ToString();
            DetallesAula detallesAula = new DetallesAula(codigoAula);
            detallesAula.Show();
            this.Close();
        }

        private void btDetalles07_Click(object sender, RoutedEventArgs e)
        {
            String codigoAula = lbAula07.Content.ToString();
            DetallesAula detallesAula = new DetallesAula(codigoAula);
            detallesAula.Show();
            this.Close();
        }

        private void btDetalles08_Click(object sender, RoutedEventArgs e)
        {
            String codigoAula = lbAula08.Content.ToString();
            DetallesAula detallesAula = new DetallesAula(codigoAula);
            detallesAula.Show();
            this.Close();
        }
    }
}
