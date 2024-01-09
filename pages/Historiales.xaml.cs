using FisioLogic.pages;
using FisioLogicV2.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace FisioLogicV2.Pages
{
    /// <summary>
    /// Interaction logic for Historiales.xaml
    /// </summary>
    public partial class Historiales : Page
    {
        internal ObservableCollection<Historial> HistorialCollection { get; }

        public Historiales()
        {
            InitializeComponent();

            HistorialCollection = new ObservableCollection<Historial>();
            CargarContenido();
            dgHistoriales.ItemsSource = HistorialCollection;
        }

        private void dgHistoriales_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (dgHistoriales.SelectedItem is Historial selectedHistorial)
            {
                // Recupera información del datagrid a los campos
                tbPaciente.Text = selectedHistorial.paciente;
                tbProfesional.Text = selectedHistorial.profesional;
                tbEspecialidad.Text = selectedHistorial.especialidad;
                tbTelefono.Text = selectedHistorial.telefono.ToString();

                // Deshabilitar el botón cuando hay un elemento seleccionado
                btnanadirHistorial.IsEnabled = false;
                lbInfo.Visibility = Visibility.Visible;
            }
            else
            {
                // Habilitar el botón cuando no hay elementos seleccionados
                btnanadirHistorial.IsEnabled = true;
                lbInfo.Visibility = Visibility.Hidden;
            }

            if (dgHistoriales.SelectedItems.Count == 1)
            {
                btneditarHistorial.IsEnabled = true;
            }
            else if (dgHistoriales.SelectedItems.Count > 1)
            {
                btneditarHistorial.IsEnabled = false;
            }
            else
            {
                btneditarHistorial.IsEnabled = false;
            }
        }
        private void addHistorial(object sender, RoutedEventArgs e)
        {
            string paciente = tbPaciente.Text;
            int telefono = 0;
            string especialidad = tbProfesional.Text;
            string profesional = tbProfesional.Text;
       
            if (string.IsNullOrWhiteSpace(paciente) || string.IsNullOrWhiteSpace(profesional) || string.IsNullOrWhiteSpace(especialidad))
            {
                MessageBox.Show("Por favor, completa los campos obligatorios.");
                return;
            }

            if (dpFecha.SelectedDate.HasValue)
            {
                DateTime selectedDate = dpFecha.SelectedDate.Value;

                // Dia | Mes | Año
                int selectedDay = selectedDate.Day;
                int selectedMonth = selectedDate.Month;
                int selectedYear = selectedDate.Year;

                // Devuelve hora
                var item = (ComboBoxItem)cbHora.SelectedValue;
                var hora = (string)item.Content;

                if (int.TryParse(tbTelefono.Text, out telefono) && hora != null)
                {
                    // Constructor Historial
                    Historial nuevoHistorial = new Historial(
                        idHistorial: HistorialCollection.Count + 1,
                        dia: selectedDay,
                        mes: selectedMonth,
                        year: selectedYear,
                        hora: hora,
                        paciente: paciente,
                        telefono: telefono,
                        especialidad: especialidad,
                        profesional: profesional
              
                    );

                    HistorialCollection.Add(nuevoHistorial);

                    // Limpiar campos después de añadir cita
                    tbPaciente.Clear();
                    tbProfesional.Clear();
                    tbEspecialidad.Clear();
                    tbTelefono.Clear();
                    cbHora.SelectedIndex = -1;
                    dpFecha.SelectedDate = null; // Limpiar fecha
                }
                else
                {
                    MessageBox.Show("La hora deben ser un valor numérico válido");
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una fecha");
            }
        }

        private void modifyHistorial(object sender, RoutedEventArgs e)
        {
            if (dgHistoriales.SelectedItem is Historial selectedHistorial)
            {
                MessageBoxResult result = MessageBox.Show("¿Desea aplicar la modificación?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    // Modificar los datos del historial con los valores de los TextBox y otros controles
                    selectedHistorial.paciente = tbPaciente.Text;
                    selectedHistorial.profesional = tbProfesional.Text;
                    selectedHistorial.especialidad = tbEspecialidad.Text;

                    if (int.TryParse(tbTelefono.Text, out int telefono))
                    {
                        selectedHistorial.telefono = telefono;
                    }
                    else
                    {
                        MessageBox.Show("El teléfono debe ser un valor numérico válido", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    // Actualiza la hora solo si hay una selección en cbHora
                    if (cbHora.SelectedItem is ComboBoxItem selectedHoraItem)
                    {
                        selectedHistorial.Hora = (string)selectedHoraItem.Content;
                    }

                    // Actualiza el DataGrid después de modificar la cita
                    dgHistoriales.Items.Refresh();

                    // Limpia los campos después de modificar
                    tbPaciente.Clear();
                    tbProfesional.Clear();
                    tbTelefono.Clear();
                    tbEspecialidad.Clear();
                    cbHora.SelectedIndex = -1; // Desselecciona la hora en el ComboBox
                }
            }
        }

        private void deleteHistorial(object sender, RoutedEventArgs e)
        {
            // Obtener historiales seleccionados
            List<Historial> historialesSeleccionados = new List<Historial>();
            foreach (var selectedItem in dgHistoriales.SelectedItems)
            {
                if (selectedItem is Historial selectedHistorial)
                {
                    historialesSeleccionados.Add(selectedHistorial);
                }
            }

            if (historialesSeleccionados.Count > 0)
            {
                MessageBoxResult result = MessageBox.Show("¿Desea eliminar los historiales seleccionados?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    // Eliminar historiales seleccionados
                    foreach (var historial in historialesSeleccionados)
                    {
                        HistorialCollection.Remove(historial);
                    }
                }
            }
        }

        private void tbTelefono_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Solo se permiten dígitos para telefono
            if (!int.TryParse(e.Text, out _))
            {
                e.Handled = true;
            }
        }

        private void tbInformacion_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void clean(object sender, RoutedEventArgs e)
        {
            tbPaciente.Clear();
            tbProfesional.Clear();
            tbTelefono.Clear();
            tbEspecialidad.Clear();

            // Reactiva botón añadir
            btnanadirHistorial.IsEnabled = true;
            lbInfo.Visibility = Visibility.Hidden;
        }

        private void SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CargarContenido()
        {
            HistorialCollection.Add(new Historial(1, DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year, "9.00", "García López",  999887766, "Traumatología", "Jesus López Velasco"));
            HistorialCollection.Add(new Historial(2, DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year, "9.30", "Martínez Gómez", 987654456, "Reumatología", "Carlos Díaz Alonso"));
            HistorialCollection.Add(new Historial(3, DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year, "10.00", "García Martínez",  999777441, "Entrenamiento", "Amanda Martínez López"));
            HistorialCollection.Add(new Historial(4, DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year, "11.00", "González García", 604123456, "Traumatología", "Óscar Rodríguez de la Torre"));
            HistorialCollection.Add(new Historial(5, DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year, "12.00", "Rodríguez Fernández",  765123456, "Reumatología", "Óscar Rodríguez de la Torre"));
            HistorialCollection.Add(new Historial(6, DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year, "12.30", "Martínez López", 601234654, "Entrenamiento", "Amanda Martínez López"));
            HistorialCollection.Add(new Historial(7, DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year, "13.30", "Sánchez Romero", 512234657, "Reumatología", "Carlos Díaz Alonso"));
        }

     
    }
}

