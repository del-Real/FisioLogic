using FisioLogicV2.pages;
using FisioLogicV2.Windows;
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

namespace FisioLogicV2.Pages
{
    /// <summary>
    /// Interaction logic for Personal.xaml
    /// </summary>
    /// 
    public partial class Personal : Page
    {

        public Personal()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
          
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            FichaPersonal fichaPersonal = new FichaPersonal();
            mainWindow.mainFrame.Content = fichaPersonal;

        }
    }
}
