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

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new Uri("Pages/Citas.xaml", UriKind.Relative));
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new Uri("Pages/Pacientes.xaml", UriKind.Relative));
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new Uri("Pages/Personal.xaml", UriKind.Relative));
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new Uri("Pages/Historiales.xaml", UriKind.Relative));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}