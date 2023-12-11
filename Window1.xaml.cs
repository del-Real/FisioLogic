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

namespace FisioLogic
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void mainFrame_Navigated_1(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new Uri("pages/Citas.xaml", UriKind.Relative));

        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new Uri("pages/Pacientes.xaml", UriKind.Relative));
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new Uri("pages/Personal.xaml", UriKind.Relative));
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new Uri("pages/Historiales.xaml", UriKind.Relative));
        }
    }
}

