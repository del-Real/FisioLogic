using FisioLogicV2.Windows;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FisioLogicV2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCitas(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new Uri("Pages/Citas.xaml", UriKind.Relative));
        }

        private void btnPacientes(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new Uri("Pages/Pacientes.xaml", UriKind.Relative));
        }

        private void btnPersonal(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new Uri("Pages/Personal.xaml", UriKind.Relative));
        }

        private void btnHistoriales(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new Uri("Pages/Historiales.xaml", UriKind.Relative));
        }

        // Cierre sesión
        private void closeSession(object sender, RoutedEventArgs e)
        {

            LoginScreen loginScreen = new LoginScreen();
            loginScreen.Show();

            // cierre mainWindow
            this.Close();
        }

        // Ventana ayuda
        private void help(object sender, RoutedEventArgs e)
        {
            Ayuda ayuda = new Ayuda();
            ayuda.Show();
        }


     
    }
}