using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
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
using System.Xml;
using FisioLogicV2.Classes;
using FisioLogicV2.Pages;

namespace FisioLogic.pages
{
    /// <summary>
    /// Interaction logic for Citas.xaml
    /// </summary>
    public partial class Citas : Page
    {
        List<Cita> listaCitas;
        public Citas()
        {
            InitializeComponent();
            listaCitas = new List<Cita>();
            listaCitas = CargarContenidoXML();

            dgCitas.ItemsSource = listaCitas;
        }

        private List<Cita> CargarContenidoXML()
        {
            List<Cita> listado = new List<Cita>();
            var nuevaCita = new Cita(0, 22, 10, 12, 2023, 0, 0, 30, "null");
            for (int i = 0; i < 10; i++)
            {
                nuevaCita.IdCita = listado.Count;
                listado.Add(nuevaCita);
            }

            return listado;

        }

         private void addCita(object sender, RoutedEventArgs e)
        {

        }
        private void modifyCita(object sender, RoutedEventArgs e)
        {

        }

        private void deleteCita(object sender, RoutedEventArgs e)
        {

        }

        private void SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
