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
using System.Windows.Navigation;
using System.Windows.Shapes;
using FisioLogicV2.Classes;

namespace FisioLogicV2.Windows
{
    /// <summary>
    /// Lógica de interacción para EditarPaciente.xaml
    /// </summary>
    public partial class EditarPaciente : Window
    {
        public EditarPaciente(Paciente p)
        {
            InitializeComponent();
        }

        private void GuardarCambios_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
