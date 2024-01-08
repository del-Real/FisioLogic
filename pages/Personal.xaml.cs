using FisioLogicV2.Classes;
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
        List<Profesional> listaProfesionales;
        public Personal()
        {
            InitializeComponent();

            listaProfesionales = new List<Profesional>();
            listaProfesionales = CargarContenidoXML();

        }
        private List<Profesional> CargarContenidoXML()  //Nos seguia sin funcionar el metodo de cargar los datos del XML, como
        {                         //viste en la segunda defensa de la practica hemos optado por cargar asi algunos datos 
            List<Profesional> listado = new List<Profesional>();
            string rutaFoto0 = "FisioLogic\\fotosPacientes\\pedrogarcia.jpg";
            string rutaFoto1 = "FisioLogic\\fotosPacientes\\mariamartinez.jpg";
            string rutaFoto2 = "FisioLogic\\fotosPacientes\\juanlopez.jpg";
            string rutaFoto3 = "FisioLogic\\fotosPacientes\\laurarodriguez.jpg";
            string rutaFoto4 = "FisioLogic\\fotosPacientes\\carlosperez.jpg";
            string rutaFoto5 = "FisioLogic\\fotosPacientes\\sofiasanchez.jpg";
            string rutaFoto6 = "FisioLogic\\fotosPacientes\\diegoalvarez.jpg";
            Uri uriImagen0 = new Uri(rutaFoto0, UriKind.RelativeOrAbsolute);
            Uri uriImagen1 = new Uri(rutaFoto1, UriKind.RelativeOrAbsolute);
            Uri uriImagen2 = new Uri(rutaFoto2, UriKind.RelativeOrAbsolute);
            Uri uriImagen3 = new Uri(rutaFoto3, UriKind.RelativeOrAbsolute);
            Uri uriImagen4 = new Uri(rutaFoto4, UriKind.RelativeOrAbsolute);
            Uri uriImagen5 = new Uri(rutaFoto5, UriKind.RelativeOrAbsolute);
            Uri uriImagen6 = new Uri(rutaFoto6, UriKind.RelativeOrAbsolute);

            listado.Add(new Sanitario(0, "Jesus", "López Velasco", 28, uriImagen0, 656434287, "Traumatologia"));
            listado.Add(new Sanitario(1, "Amanda", "Martínez López", 32, uriImagen1, 667721990, "Traumatologia"));
            listado.Add(new Sanitario(3, "Óscar", "Rodríguez de la Torre", 33, uriImagen2, 654321987, "Entrenamiento"));
            listado.Add(new Sanitario(4, "Carlos", "Díaz Alonso", 26, uriImagen3, 612347645, "Reumatología"));
    
            listado.Add(new Limpiador(5, "Lucía", "Garrido Bonito", 47, uriImagen4, 678901234, "Clínica"));
            listado.Add(new Limpiador(6, "Manuel", "García Caro", 38, uriImagen5, 687670441, "Recibidor"));
            listado.Add(new Limpiador(7, "Sonia", "Francisco Rey", 45, uriImagen6, 600675923, "Salas"));
            return listado;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
          
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            FichaPersonal fichaPersonal = new FichaPersonal();
            mainWindow.mainFrame.Content = fichaPersonal;

        }
    }
}
