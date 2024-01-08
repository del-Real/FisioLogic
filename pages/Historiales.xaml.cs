using FisioLogic.pages;
using FisioLogicV2.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for Historiales.xaml
    /// </summary>
    public partial class Historiales : Page
    {
        internal ObservableCollection<Historial> HistorialCollection { get; }

        public Historiales()
        {
            InitializeComponent();

            HistorialCollection = new ObservableCollection<Historial>();
            CargarContenido();
            dgHistoriales.ItemsSource = HistorialCollection;
        }

        private void dgHistoriales_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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

        private void tbInformacion_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void clean(object sender, RoutedEventArgs e)
        {

        }

        private void SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CargarContenido()
        {
            HistorialCollection.Add(new Historial(1, DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year, "9.00", "García López",  999887766, "Traumatología", "Presenta molestias en hombros y bajoespalda"));
            HistorialCollection.Add(new Historial(2, DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year, "9.30", "Martínez Gómez", 987654456, "Traumatología", "Dolores punzantes"));
            HistorialCollection.Add(new Historial(3, DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year, "10.00", "García Martínez",  999777441, "Traumatología", "Incapacidad de incorporarse totalmente"));
            HistorialCollection.Add(new Historial(4, DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year, "11.00", "González García", 604123456, "Traumatología", "Ligera lesión cervical"));
            HistorialCollection.Add(new Historial(5, DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year, "12.00", "Rodríguez Fernández",  765123456, "Traumatología", "Hombros caídos"));
            HistorialCollection.Add(new Historial(6, DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year, "12.30", "Martínez López", 601234654, "Traumatología", "Lumbago"));
            HistorialCollection.Add(new Historial(7, DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year, "13.30", "Sánchez Romero", 512234657, "Traumatología", "Revisión anual"));
        }

   
    }
}

