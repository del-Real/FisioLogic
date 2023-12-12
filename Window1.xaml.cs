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

        private void enter_Mouse(object sender, MouseEventArgs e)
        {
            imgAvatar.Width = 250;
            imgAvatar.Height = 250;
        }

        private void leave_Mouse(object sender, MouseEventArgs e)
        {
            imgAvatar.Width = 150;
            imgAvatar.Height = 150;
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

