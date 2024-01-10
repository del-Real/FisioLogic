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
using FisioLogicV2.Pages;

namespace FisioLogicV2.pages
{
    /// <summary>
    /// Lógica de interacción para FichaPersonal.xaml
    /// </summary>
    public partial class FichaPersonal : Page
    {
        public FichaPersonal(Sanitario sanitario)
        {
            InitializeComponent();
        }
        private void ButtonBackFichaPersonal_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            Personal personal = new Personal();
            mainWindow.mainFrame.Content = personal;
        }
    }
}
