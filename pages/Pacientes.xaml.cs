using FisioLogicV2.Classes;
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
        List<Paciente> listaPacientes;
        public Pacientes()
        {
            InitializeComponent();


            // Crear listado pacientes
            listaPacientes = new List<Paciente>();
            // Se cargarán los datos de prueba de un fichero XML
            listaPacientes = CargarContenidoXML();
            // Indicar que el origen de datos del ListBox es listadoPeliculas
            lstPacientes.ItemsSource = listaPacientes;
        }

        private void lstPacientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
                var nuevoPaciente = new Paciente(0, "", "", "", 0, 0, "", new Uri(""), "");
                nuevoPaciente.IdPaciente = Convert.ToInt32(node.Attributes["IdPaciente"].Value);
                nuevoPaciente.Nombre = node.Attributes["Nombre"].Value;
                nuevoPaciente.Apellidos = node.Attributes["Apellidos"].Value;
                nuevoPaciente.Direccion = node.Attributes["Direccion"].Value;
                nuevoPaciente.Telefono = Convert.ToInt32(node.Attributes["Teléfono"].Value);
                nuevoPaciente.Edad = Convert.ToInt32(node.Attributes["Edad"].Value);
                nuevoPaciente.Genero = node.Attributes["Género"].Value;
                nuevoPaciente.Foto = new Uri(node.Attributes["Foto"].Value, UriKind.Absolute);
                nuevoPaciente.Email = node.Attributes["Email"].Value;
            }
            return listado;
        }

    }
}
