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
using FisioLogicV2.Pages;

namespace FisioLogicV2.pages
{
    /// <summary>
    /// Lógica de interacción para FichaPaciente.xaml
    /// </summary>
    public partial class FichaPaciente : Page
    {
        public FichaPaciente()
        {
            InitializeComponent();
        }
        private void ButtonBackFichaPaciente_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            Pacientes paciente = new Pacientes();
            mainWindow.mainFrame.Content = paciente;
        }
    }
}
