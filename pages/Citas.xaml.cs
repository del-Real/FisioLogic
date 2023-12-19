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
        List<Cita> listadoCitas;
        public Citas()
        {
            InitializeComponent();
            /*
            listadoCitas = new List<Cita>();
            // Se cargarán los datos de prueba de un fichero XML
            listadoCitas = CargarContenidoXML();
            // Indicar que el origen de datos del ListBox es listadoPeliculas
            lstListaCitas.ItemsSource = listadoCitas;
            */
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        /*
        private List<Cita> CargarContenidoXML()
        {
            List<Cita> listado = new List<Cita>();
            // Cargar contenido de prueba
            XmlDocument doc = new XmlDocument();
            var fichero = Application.GetResourceStream(new Uri("Datos/peliculas.xml", UriKind.Relative)); doc.Load(fichero.Stream);
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                var nuevaPelicula = new Pelicula("", 0, null, "", 0);
                nuevaPelicula.Titulo = node.Attributes["Titulo"].Value;
                nuevaPelicula.Anio = Convert.ToInt32(node.Attributes["Anio"].Value);
                nuevaPelicula.Duracion = Convert.ToInt32(node.Attributes["Duracion"].Value);
                nuevaPelicula.Argumento = node.Attributes["Argumento"].Value;
                nuevaPelicula.Caratula = new Uri(node.Attributes["Caratula"].Value, UriKind.Relative); nuevaPelicula.Director = node.Attributes["Director"].Value;
                nuevaPelicula.GeneroPelicula = node.Attributes["Genero"].Value;
                nuevaPelicula.AltaEnVideoteca = Convert.ToDateTime(node.Attributes["AltaEnVideoteca"].Value); nuevaPelicula.Visualizada = Convert.ToBoolean(node.Attributes["Visualizada"].Value); nuevaPelicula.URL_IMDB = new Uri(node.Attributes["URL_IMDB"].Value, UriKind.Absolute); listado.Add(nuevaPelicula);
            }
            return listado;
        }
        */
    }
}
