using FisioLogicV2.Classes;
using FisioLogicV2.Windows;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Linq;

namespace FisioLogicV2.Pages
{
    /// <summary>
    /// Interaction logic for Pacientes.xaml
    /// </summary>
    public partial class Pacientes : Page
    {
        List<Paciente> listaPacientes;
        List<Paciente> listaNuevos;
        public Pacientes()
        {
            InitializeComponent();
            // Crear listado pacientes
            listaPacientes = new List<Paciente>();
            // Se cargarán los datos de prueba de un fichero XML
            listaPacientes = CargarContenidoXML();
            // Indicar que el origen de datos del ListBox es listadoPeliculas
            if (listaNuevos is not null)
            {
                foreach (var item in listaNuevos)
                {
                    listaPacientes.Add(item);
                }
            }
            dgPacientes.ItemsSource = listaPacientes;
        }
        
        private List<Paciente> CargarContenidoXML()
        {   
            List<Paciente> listado = new List<Paciente>();
            string rutaFoto = "C:\\Users\\palen\\OneDrive\\Escritorio\\Ingeniería Informática\\3º Año, 1º Cuatrimestre\\IPO\\Laboratorio\\FisioLogic\\Assets\\m_user.png";
            Uri uriImagen = new Uri(rutaFoto, UriKind.RelativeOrAbsolute);
            var nuevoPaciente = new Paciente(0,"Pedro","García López","Calle 123, Ciudad A",123456789,40,"Masculino","pedro@example.com");
            nuevoPaciente.Foto = uriImagen;
            for (int i=0; i<10; i++)
            {
                nuevoPaciente.IdPaciente = listado.Count;
                listado.Add(nuevoPaciente);
            }
            // Cargar contenido de prueba
            /*
            XmlDocument doc = new XmlDocument();
            var fichero = Application.GetResourceStream(new Uri("Datos/paciente.xml", UriKind.Relative));
            doc.Load(fichero.Stream);
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                var nuevoPaciente = new Paciente();
                nuevoPaciente.IdPaciente = Convert.ToInt32(node.Attributes["IdPaciente"].Value);
                nuevoPaciente.Nombre = node.Attributes["Nombre"].Value;
                nuevoPaciente.Apellidos = node.Attributes["Apellidos"].Value;
                nuevoPaciente.Direccion = node.Attributes["Direccion"].Value;
                nuevoPaciente.Telefono = Convert.ToInt32(node.Attributes["Teléfono"].Value);
                nuevoPaciente.Edad = Convert.ToInt32(node.Attributes["Edad"].Value);
                nuevoPaciente.Genero = node.Attributes["Género"].Value;
                nuevoPaciente.Foto = new Uri(node.Attributes["Foto"].Value, UriKind.Absolute);
                nuevoPaciente.Email = node.Attributes["Email"].Value;
            }*/
            
            return listado;
            
        }

        private void anadir_Paciente(object sender, RoutedEventArgs e)
        {
            AnadirPaciente ventanaAnadirPaciente = new AnadirPaciente();

            // Mostrar la ventana
            ventanaAnadirPaciente.Show();
        }

        private void borrar_Paciente(object sender, RoutedEventArgs e)
        {

        }
    }
}
