using SGHE.LogicaNegocio.DAO;
using SGHE.LogicaNegocio.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Lógica de interacción para ExperienciasEducativas.xaml
    /// </summary>
    public partial class ExperienciasEducativas : Window
    {
        public ExperienciasEducativas()
        {
            InitializeComponent();
            MostrarExperienciasEducativas();
        }

        public void MostrarExperienciasEducativas()
        {

            List<ExperienciaEducativa> experienciaEducativas = new List<ExperienciaEducativa>();
            experienciaEducativas = RecuperarExperienciasEducativas();
            if (experienciaEducativas != null)
            {
                for(int i = 0; i < experienciaEducativas.Count(); i++)
                {
                    lbExperiecnias.Items.Add(experienciaEducativas[i].Nombre);
                }        
            }
        }

        public List<ExperienciaEducativa> RecuperarExperienciasEducativas()
        {
            ActividadDao actividadDao = new ActividadDao();
            return actividadDao.RecuperarExperienciasEducativas();
        }
    }
}
