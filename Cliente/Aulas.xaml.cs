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
            lbAula01.Content = aulas[0].CodigoAula;
            lbAula02.Content = aulas[1].CodigoAula;
            lbAula03.Content = aulas[2].CodigoAula;
            lbAula04.Content = aulas[3].CodigoAula;
            lbAula05.Content = aulas[4].CodigoAula;
            lbAula06.Content = aulas[5].CodigoAula;
            lbAula07.Content = aulas[6].CodigoAula;
            lbAula08.Content = aulas[7].CodigoAula;
            
        }
    }
}
