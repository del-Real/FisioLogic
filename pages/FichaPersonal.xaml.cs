using FisioLogicV2.Pages;
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

namespace FisioLogicV2.pages
{
    /// <summary>
    /// Interaction logic for FichaPersonal.xaml
    /// </summary>
    public partial class FichaPersonal : Page
    {
        public FichaPersonal()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            Personal personal = new Personal();
            mainWindow.mainFrame.Content = personal;
        }
    }
}
