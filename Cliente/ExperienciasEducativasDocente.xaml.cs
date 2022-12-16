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
    /// Lógica de interacción para ExperienciasEducativasDocente.xaml
    /// </summary>
    public partial class ExperienciasEducativasDocente : Window
    {
        Docente docenteRecuperado;
        public ExperienciasEducativasDocente( Docente docenteConseguidol)
        {
            docenteRecuperado = docenteConseguidol;
            InitializeComponent();
            RecuperarExperienciasDocente();
        }

        
        public void RecuperarExperienciasDocente()
        {
            List<ExperienciaEducativa> experienciasEducativas = new List<ExperienciaEducativa>();
            ActividadDao actividadDao = new ActividadDao();
            experienciasEducativas = actividadDao.RecuperarExperienciasPorIdDocente(idPeriodo,docenteRecuperado.IdUsuario);
            MostrarExperienciasEducativas(experienciasEducativas);
        }

        private void MostrarExperienciasEducativas(List<ExperienciaEducativa> experienciasEducativas)
        {
            if (experienciasEducativas != null)
            {
                for (int i = 0; i < experienciasEducativas.Count(); i++)
                {
                    lbExperiencias.Items.Add(experienciasEducativas[i].Nombre);
                }
            }
        }
    }
}
