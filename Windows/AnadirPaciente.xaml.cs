using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using FisioLogicV2.Classes;

namespace FisioLogicV2.Windows
{
    /// <summary>
    /// Lógica de interacción para AnadirPaciente.xaml
    /// </summary>
    public partial class AnadirPaciente : Window
    {
        public AnadirPaciente()
        {
            InitializeComponent();
        }

        private void cbGeneroPaciente_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Click_Cancelar_Anadir_Paciente(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Click_Limpiar_Anadir_Paciente(object sender, RoutedEventArgs e)
        {
            tbApellidosPaciente.Text = String.Empty;
            tbNombrePaciente.Text = String.Empty;
            tbDireccionPaciente.Text = String.Empty;
            tbTelefonoPaciente.Text = String.Empty;
            tbEdadPaciente.Text = String.Empty;
            cbGeneroPaciente.SelectedIndex = -1;
            tbEmailPaciente.Text = String.Empty;
            tbFotoPaciente.Text = String.Empty;

        }

        private void Click_Anadir_Anadir_Paciente(object sender, RoutedEventArgs e)
        {
            Paciente nuevoPac = new Paciente();
            nuevoPac.Nombre = tbNombrePaciente.Text;
            nuevoPac.Apellidos = tbApellidosPaciente.Text;
            nuevoPac.Direccion = tbDireccionPaciente.Text;
            if ((int.Parse(tbTelefonoPaciente.Text) < 0 || int.Parse(tbTelefonoPaciente.Text) > 999999999))
            {
                MessageBox.Show("El número de teléfono es incorrecto.", "Error");
            } else if (int.Parse(tbEdadPaciente.Text) < 0)
            {
                MessageBox.Show("La edad es incorrecta.", "Error");
            }
        }
    }
}
