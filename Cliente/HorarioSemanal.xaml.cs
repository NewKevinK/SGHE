using SGHE.Cliente.Recursos.ControlDeUsuario;
using SGHE.LogicaNegocio.DAO;
using SGHE.LogicaNegocio.POCO;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace SGHE.Cliente
{
    /// <summary>
    /// Lógica de interacción para HorarioSemanal.xaml
    /// </summary>
    public partial class HorarioSemanal : Window
    {
        List<HoraSemanalUs> listaArreglo = new List<HoraSemanalUs>();
        List<DetalleHorario> horarioSemanal;
        public HorarioSemanal(int alumnoRecuperadoo, int idPeriodo)
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();

            IniciarGridHorario();
            cargarElementosHorario();
            cargarClaseHorario(alumnoRecuperadoo, idPeriodo);
        }
        public HorarioSemanal()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();

            IniciarGridHorario();
            cargarElementosHorario();
            //cargarClaseHorario();
        }

        private void cargarClaseHorario(int alumnoRecuperado, int idperiodo)
        {
            HorarioDao horarioConsulta = new HorarioDao();
            
            horarioSemanal = HorarioDao.RecuperarHorarioSemanal(idperiodo, alumnoRecuperado);
            cargarLunes(horarioSemanal);
            cargarMartes(horarioSemanal);
            cargarMiercoles(horarioSemanal);
            cargarJueves(horarioSemanal);
            cargarViernes(horarioSemanal);

        }

        private void cargarViernes(List<DetalleHorario> horarioSemanal)
        {
            List<HorarioDatos> listtem = new List<HorarioDatos>();
            HorarioDatos horarioDatos;
            for (int i = 0; i < listaArreglo.Count; i++)
            {
                listtem.Add(horarioDatos = new HorarioDatos());
            }


            for (int i = 0; i < horarioSemanal.Count; i++)
            {
                if (horarioSemanal[i].DiaSemana == 5)
                {
                    for (int z = 0; z < listaArreglo.Count; z++)
                    {
                        if (horarioSemanal[i].HoraInicio == (listaArreglo[z].HoraInicio.Text + ":00"))
                        {
                            horarioDatos = new HorarioDatos();
                            horarioDatos.ExperienciaEducativa.Text = horarioSemanal[i].NombreEE.ToString();
                            horarioDatos.cajadeDetalles.Background = Brushes.Gray;
                            horarioDatos.salonClases.Text = "SALON: " + horarioSemanal[i].CodigoAula.ToString();
                            horarioDatos.Profesor.Text = horarioSemanal[i].NombreCompletoDocente.ToString();
                            listtem[z] = horarioDatos;
                        }
                        else
                        {
                            if (listtem[z].ExperienciaEducativa.Text == "")
                            {
                                horarioDatos = new HorarioDatos();
                                horarioDatos.cajadeDetalles.Background = Brushes.White;
                                listtem[z] = horarioDatos;
                            }

                        }

                    }

                }
            }
            for (int z = 0; z < listtem.Count; z++)
            {
                GridElementosViernes.Children.Add(listtem[z]);
            }
        }

        private void cargarJueves(List<DetalleHorario> horarioSemanal)
        {
            List<HorarioDatos> listtem = new List<HorarioDatos>();
            HorarioDatos horarioDatos;
            for (int i = 0; i < listaArreglo.Count; i++)
            {
                listtem.Add(horarioDatos = new HorarioDatos());
            }


            for (int i = 0; i < horarioSemanal.Count; i++)
            {
                if (horarioSemanal[i].DiaSemana == 4)
                {
                    for (int z = 0; z < listaArreglo.Count; z++)
                    {
                        if (horarioSemanal[i].HoraInicio == (listaArreglo[z].HoraInicio.Text + ":00"))
                        {
                            horarioDatos = new HorarioDatos();
                            horarioDatos.ExperienciaEducativa.Text = horarioSemanal[i].NombreEE.ToString();
                            horarioDatos.cajadeDetalles.Background = Brushes.Gray;
                            horarioDatos.salonClases.Text = "SALON: " + horarioSemanal[i].CodigoAula.ToString();
                            horarioDatos.Profesor.Text = horarioSemanal[i].NombreCompletoDocente.ToString();
                            listtem[z] = horarioDatos;
                        }
                        else
                        {
                            if (listtem[z].ExperienciaEducativa.Text == "")
                            {
                                horarioDatos = new HorarioDatos();
                                horarioDatos.cajadeDetalles.Background = Brushes.White;
                                listtem[z] = horarioDatos;
                            }

                        }

                    }

                }
            }
            for (int z = 0; z < listtem.Count; z++)
            {
                GridElementosJueves.Children.Add(listtem[z]);
            }
        }

        private void cargarMiercoles(List<DetalleHorario> horarioSemanal)
        {
            List<HorarioDatos> listtem = new List<HorarioDatos>();
            HorarioDatos horarioDatos;
            for (int i = 0; i < listaArreglo.Count; i++)
            {
                listtem.Add(horarioDatos = new HorarioDatos());
            }


            for (int i = 0; i < horarioSemanal.Count; i++)
            {
                if (horarioSemanal[i].DiaSemana == 3)
                {
                    for (int z = 0; z < listaArreglo.Count; z++)
                    {
                        if (horarioSemanal[i].HoraInicio == (listaArreglo[z].HoraInicio.Text + ":00"))
                        {
                            horarioDatos = new HorarioDatos();
                            horarioDatos.ExperienciaEducativa.Text = horarioSemanal[i].NombreEE.ToString();
                            horarioDatos.cajadeDetalles.Background = Brushes.Gray;
                            horarioDatos.salonClases.Text = "SALON: " + horarioSemanal[i].CodigoAula.ToString();
                            horarioDatos.Profesor.Text = horarioSemanal[i].NombreCompletoDocente.ToString();
                            listtem[z] = horarioDatos;
                        }
                        else
                        {
                            if (listtem[z].ExperienciaEducativa.Text == "")
                            {
                                horarioDatos = new HorarioDatos();
                                horarioDatos.cajadeDetalles.Background = Brushes.White;
                                listtem[z] = horarioDatos;
                            }

                        }

                    }

                }
            }
            for (int z = 0; z < listtem.Count; z++)
            {
                GridElementosMiercoles.Children.Add(listtem[z]);
            }
        }

        private void cargarMartes(List<DetalleHorario> horarioSemanal)
        {
            List<HorarioDatos> listtem = new List<HorarioDatos>();
            HorarioDatos horarioDatos;
            for (int i = 0; i < listaArreglo.Count; i++)
            {
                listtem.Add(horarioDatos = new HorarioDatos());
            }


            for (int i = 0; i < horarioSemanal.Count; i++)
            {
                if (horarioSemanal[i].DiaSemana == 2)
                {
                    for (int z = 0; z < listaArreglo.Count; z++)
                    {
                        if (horarioSemanal[i].HoraInicio == (listaArreglo[z].HoraInicio.Text + ":00"))
                        {
                            horarioDatos = new HorarioDatos();
                            horarioDatos.ExperienciaEducativa.Text = horarioSemanal[i].NombreEE.ToString();
                            horarioDatos.cajadeDetalles.Background = Brushes.Gray;
                            horarioDatos.salonClases.Text = "SALON: " + horarioSemanal[i].CodigoAula.ToString();
                            horarioDatos.Profesor.Text = horarioSemanal[i].NombreCompletoDocente.ToString();
                            listtem[z] = horarioDatos;
                        }
                        else
                        {
                            if (listtem[z].ExperienciaEducativa.Text == "")
                            {
                                horarioDatos = new HorarioDatos();
                                horarioDatos.cajadeDetalles.Background = Brushes.White;
                                listtem[z] = horarioDatos;
                            }

                        }

                    }

                }
            }
            for (int z = 0; z < listtem.Count; z++)
            {
                GridElementosMartes.Children.Add(listtem[z]);
            }
        }

        private void cargarLunes(List<DetalleHorario> horarioSemanal)
        {
            List<HorarioDatos> listtem= new List<HorarioDatos>();
            HorarioDatos horarioDatos;
            for (int i = 0; i < listaArreglo.Count; i++)
            {
                listtem.Add(horarioDatos=new HorarioDatos());
            }
            

            for (int i = 0; i < horarioSemanal.Count; i++)
            {
                if (horarioSemanal[i].DiaSemana == 1)
                {
                    for (int z = 0; z < listaArreglo.Count; z++)
                    {
                        if (horarioSemanal[i].HoraInicio == (listaArreglo[z].HoraInicio.Text + ":00"))
                        {
                            horarioDatos = new HorarioDatos();
                            horarioDatos.ExperienciaEducativa.Text = horarioSemanal[i].NombreEE.ToString();
                            horarioDatos.cajadeDetalles.Background = Brushes.Gray;
                            horarioDatos.salonClases.Text = "SALON: " + horarioSemanal[i].CodigoAula.ToString();
                            horarioDatos.Profesor.Text = horarioSemanal[i].NombreCompletoDocente.ToString();
                            listtem[z] = horarioDatos;
                        }
                        else
                        {
                            if (listtem[z].ExperienciaEducativa.Text == "")
                            {
                                horarioDatos = new HorarioDatos();
                                horarioDatos.cajadeDetalles.Background = Brushes.White;
                                listtem[z] = horarioDatos;
                            }

                        }
                       
                    }
                    
                }
            }
            for(int z = 0; z < listtem.Count; z++)
            {
                GridElementoslunes.Children.Add(listtem[z]);
            }
        }

        private void cargarElementosHorario()
        {
            Hora7_9.HoraInicio.Text = "7:00";
            Hora7_9.HoraFin.Text = "9:00";

            Hora9_11.HoraInicio.Text = "9:00";
            Hora9_11.HoraFin.Text = "11:00";

            Hora11_13.HoraInicio.Text = "11:00";
            Hora11_13.HoraFin.Text = "13:00";

            Hora13_15.HoraInicio.Text = "13:00";
            Hora13_15.HoraFin.Text = "15:00";

            Hora15_17.HoraInicio.Text = "15:00";
            Hora15_17.HoraFin.Text = "17:00";

            Hora17_19.HoraInicio.Text = "17:00";
            Hora17_19.HoraFin.Text = "19:00";

            Hora19_21.HoraInicio.Text = "19:00";
            Hora19_21.HoraFin.Text = "21:00";

            listaArreglo.Add(Hora7_9);
            listaArreglo.Add(Hora9_11);
            listaArreglo.Add(Hora11_13);
            listaArreglo.Add(Hora13_15);
            listaArreglo.Add(Hora15_17);
            listaArreglo.Add(Hora17_19);
            listaArreglo.Add(Hora19_21);

        }

        private void IniciarGridHorario()
        {
            RowDefinition sieteAM = new RowDefinition();
            GridLength length = new GridLength();
            sieteAM.Height = length;

            GridHorario.RowDefinitions.Add(sieteAM);
        }

        void timer_Tick(object sender, EventArgs e)
        {
            lblTime.Content = DateTime.Now.ToString("HH:mm") +" hrs."; 
            lblFechaActual.Content = DateTime.Now.ToString("dddd dd MMMM yyyy");
        }

        private void clic_volver(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
