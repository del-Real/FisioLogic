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

namespace FisioLogicV2.Pages
{
    /// <summary>
    /// Interaction logic for Pacientes.xaml
    /// </summary>
    public partial class Pacientes : Page
    {
        List<Pacientes> listadoPacientes;
        public Pacientes()
        {
            InitializeComponent();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private List<Paciente> CargarContenidoXML()
        {
            List<Paciente> listado = new List<Paciente>();
            // Cargar contenido de prueba
            XmlDocument doc = new XmlDocument();
            var fichero = Application.GetResourceStream(new Uri("Datos/pacientes.xml", UriKind.Relative)); 
            doc.Load(fichero.Stream);
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                var nuevoPaciente = new Paciente(0,"","","",0,0,"",new Uri(""),"");
                nuevoPaciente.IdPaciente = Convert.ToInt32(node.Attributes["IdPaciente"].Value);
                nuevoPaciente.Nombre = node.Attributes["Nombre"].Value;
                nuevoPaciente.Apellidos = node.Attributes["Apellidos"].Value;
                nuevoPaciente.Direccion = node.Attributes["Direccion"].Value;
                nuevaPelicula.Argumento = node.Attributes["Argumento"].Value;
                nuevaPelicula.Caratula = new Uri(node.Attributes["Caratula"].Value, UriKind.Relative); nuevaPelicula.Director = node.Attributes["Director"].Value;
                nuevaPelicula.GeneroPelicula = node.Attributes["Genero"].Value;
                nuevaPelicula.AltaEnVideoteca = Convert.ToDateTime(node.Attributes["AltaEnVideoteca"].Value); nuevaPelicula.Visualizada = Convert.ToBoolean(node.Attributes["Visualizada"].Value); nuevaPelicula.URL_IMDB = new Uri(node.Attributes["URL_IMDB"].Value, UriKind.Absolute); listado.Add(nuevaPelicula);
            }
            return listado;
        }
    }
}
