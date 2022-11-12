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
                codigoAula = "Esta Aula No existe";
            }
            else
            {
                codigoAula = string.Format("Aulas: {1}{0}Estado: {2}{0}", Environment.NewLine, aulas[contadorAula].CodigoAula, aulas[contadorAula].Estado);
                contadorAula++;
            }
            return codigoAula;
        }
    }
}
