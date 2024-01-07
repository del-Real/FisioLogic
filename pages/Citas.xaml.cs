using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using FisioLogicV2.Classes;
using FisioLogicV2.Pages;

namespace FisioLogic.pages
{
    /// <summary>
    /// Interaction logic for Citas.xaml
    /// </summary>
    public partial class Citas : Page
    {
        public ObservableCollection<Cita> CitasCollection { get; set; }

        public Citas()
        {
            InitializeComponent();
      

            CitasCollection = new ObservableCollection<Cita>();
            CargarContenido();
            dgCitas.ItemsSource = CitasCollection;
 
        }

        private void CargarContenido()
        {
            CitasCollection.Add(new Cita(1, DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year, "9.00", "Pedro García López", "Lucía Ramirez", 30, "Presenta molestias en hombros y bajoespalda"));
            CitasCollection.Add(new Cita(2, DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year, "9.30", "María Martínez Gómez", "Pedro Anasagasti", 30, "Dolores punzantes"));
            CitasCollection.Add(new Cita(3, DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year, "10.00", "Lucía García Martínez", "Yolanda Ruán", 30, "Incapacidad de incorporarse totalmente"));
            CitasCollection.Add(new Cita(4, DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year, "11.00", "Ana González García", "Jaime Velasco", 60, "Ligera lesión cervical"));
            CitasCollection.Add(new Cita(5, DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year, "12.00", "Laura Rodríguez Fernández", "Yolanda Ruán", 30, "Hombros caídos"));
            CitasCollection.Add(new Cita(6, DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year, "12.30", "Javier Martínez López", "Jaime Velasco", 60, "Lumbago"));
            CitasCollection.Add(new Cita(7, DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year, "13.30", "Sofía Sánchez Romero", "Pedro Anasagasti", 30, "Revisión anual"));
        }

        private void addCita(object sender, RoutedEventArgs e)
        {
            string paciente = tbPaciente.Text;
            string profesional = tbProfesional.Text;
            string informacion = tbInformacion.Text;
            int duracion = 0;

            if (dpFecha.SelectedDate.HasValue)
            {
                DateTime selectedDate = dpFecha.SelectedDate.Value;

                // Extract day, month, and year
                int selectedDay = selectedDate.Day;
                int selectedMonth = selectedDate.Month;
                int selectedYear = selectedDate.Year;

                // Get the selected hora from the ComboBox
                var item = (ComboBoxItem)cbHora.SelectedValue;
                var hora = (string)item.Content;

                if (int.TryParse(tbDuracion.Text, out duracion) && hora != null)
                {
                    // Constructor cita
                    Cita nuevaCita = new Cita(
                        id: CitasCollection.Count + 1,
                        dia: selectedDay,
                        hora: hora,
                        mes: selectedMonth,
                        year: selectedYear,
                        paciente: paciente,
                        profesional: profesional,
                        duracion: duracion,
                        informacion: informacion
                    );

                    CitasCollection.Add(nuevaCita);

                    // Limpiar campos después de añadir cita
                    tbPaciente.Clear();
                    tbProfesional.Clear();
                    tbInformacion.Clear();
                    tbDuracion.Clear();
                    cbHora.SelectedIndex = -1;
                    dpFecha.SelectedDate = null; // Clear the selected date in the DatePicker
                }
                else
                {
                    MessageBox.Show("La duración y la hora deben ser un valor numérico válido");
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una fecha");
            }
        }
        private void modifyCita(object sender, RoutedEventArgs e)
        {
            if (dgCitas.SelectedItem is Cita selectedCita)
            {
                // Modificar los datos de la cita seleccionada con los valores de los TextBox y otros controles
                selectedCita.Paciente = tbPaciente.Text;
                selectedCita.Profesional = tbProfesional.Text;
                selectedCita.Informacion = tbInformacion.Text;

                if (int.TryParse(tbDuracion.Text, out int duracion))
                {
                    selectedCita.Duracion = duracion;
                }
                else
                {
                    MessageBox.Show("La duración debe ser un valor numérico válido");
                    return; // No modificamos la cita si la duración no es válida
                }

                // Actualiza el DataGrid después de modificar la cita
                dgCitas.Items.Refresh();

                // Limpia los campos después de modificar
                tbPaciente.Clear();
                tbProfesional.Clear();
                tbInformacion.Clear();
                tbDuracion.Clear();
            }
        }

        private void deleteCita(object sender, RoutedEventArgs e)
        {
            if (dgCitas.SelectedItem is Cita selectedCita)
            {
                CitasCollection.Remove(selectedCita);
            }
        }
        private void dgCitas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgCitas.SelectedItem is Cita selectedCita)
            {
                // Recuperar información del datagrid a los campos
                tbPaciente.Text = selectedCita.Paciente;
                tbProfesional.Text = selectedCita.Profesional;
                tbInformacion.Text = selectedCita.Informacion;
                tbDuracion.Text = selectedCita.Duracion.ToString(); 
                                                                  
            }
        }
        private void SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            //CitasCollection.Clear();

            //DateTime fechaSeleccionada = dpFecha.SelectedDate.GetValueOrDefault();

            //// Obtén la fecha actual
            //DateTime fechaActual = DateTime.Now.Date;

            //// Compara la fecha seleccionada con la fecha actual
            //if (fechaSeleccionada == fechaActual)
            //{
            //    CargarContenido();
            //    dgCitas.ItemsSource = CitasCollection;
            //}

        }

 
        private void tbDuracion_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Solo se permiten dígitos para la duracion
            if (!int.TryParse(e.Text, out _))
            {
                e.Handled = true;
            }
        }
    }
}
