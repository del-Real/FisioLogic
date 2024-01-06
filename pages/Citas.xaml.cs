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
            dgCitas.ItemsSource = CitasCollection;
        }

        private void addCita(object sender, RoutedEventArgs e)
        {
            string paciente = tbPaciente.Text;
            string profesional = tbProfesional.Text;
            string informacion = tbInformacion.Text;
            int duracion = 0;
            var item = (ComboBoxItem)cbHora.SelectedValue;
            var hora = (string)item.Content;


            if (int.TryParse(tbDuracion.Text, out duracion) && hora != null)
            {
                // Constructor cita
                Cita nuevaCita = new Cita(
                    id: CitasCollection.Count + 1, 
                    dia: DateTime.Now.Day,
                    hora: hora,
                    mes: DateTime.Now.Month,
                    year: DateTime.Now.Year,
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
            }
            else
            {
                MessageBox.Show("La duración y la hora deben ser un valor numérico válido");
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
