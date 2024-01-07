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
using static System.Net.Mime.MediaTypeNames;
using FisioLogicV2.pages;

namespace FisioLogicV2.Pages
{
    /// <summary>
    /// Interaction logic for Pacientes.xaml
    /// </summary>
    public partial class Pacientes : Page
    {
        //private EditarPaciente ventanaeditar;
        //int id = 0;
        List<Paciente> listaPacientes;
        public Pacientes()
        {
            InitializeComponent();
            // Crear listado pacientes
            listaPacientes = new List<Paciente>();
            // Se cargarán los datos de prueba de un fichero XML
            listaPacientes = CargarContenidoXML();
            // Indicar que el origen de datos del ListBox es listadoPeliculas
            
            dgPacientes.ItemsSource = listaPacientes;
            
        }
        
        private List<Paciente> CargarContenidoXML()
        {   
            List<Paciente> listado = new List<Paciente>();
            string rutaFoto = "FisioLogic\\Assets\\m_user.png";
            Uri uriImagen = new Uri(rutaFoto, UriKind.RelativeOrAbsolute);
            listado.Add(new Paciente(0, "Pedro", "García López", "Calle Manzana, 103", "Manzanares", 123456789, 40, "Masculino", uriImagen, "pedro@example.com"));
            listado.Add(new Paciente(1, "María", "Martínez Gómez", "Avenida Principal, 45", "Granada", 987654321, 35, "Femenino", uriImagen, "maria@example.com"));
            listado.Add(new Paciente(2, "Juan", "López González", "Carrera 245, Portal A", "Valdepeñas", 567890123, 50, "Masculino", uriImagen, "juan@example.com"));
            listado.Add(new Paciente(3, "Laura", "Rodríguez Fernández", "Callejón Albolote, 3", "Toledo", 654321987, 42, "Femenino", uriImagen, "laura@example.com"));
            listado.Add(new Paciente(4, "Carlos", "Pérez Díaz", "Paseo de las Tinajas, 1", "Bolaños de Calatrava", 789012345, 28, "Masculino", uriImagen, "carlos@example.com"));
            listado.Add(new Paciente(5, "Sofía", "Sánchez Romero", "Avenida Principal, 203B", "Valencia", 456789012, 48, "Femenino", uriImagen, "sofia@example.com"));
            listado.Add(new Paciente(6, "Diego", "Alvarez Moreno", "Calle Magdalena, 13", "Valdepeñas", 345678901, 55, "Masculino", uriImagen, "diego@example.com"));
            listado.Add(new Paciente(7, "Ana", "González García", "Calle Cardenal Monescillo, 12", "La Solana", 234567890, 33, "Femenino", uriImagen, "ana@example.com"));
            listado.Add(new Paciente(8, "Javier", "Martínez López", "Calle de las Virtudes, 21", "Manzanares", 123456789, 60, "Masculino", uriImagen, "javier@example.com"));
            listado.Add(new Paciente(9, "Elena", "Rodríguez Fernández", "Calle Neotica, 4", "Ciudad Real", 890123456, 25, "Femenino", uriImagen, "elena@example.com"));
            listado.Add(new Paciente(10, "Luis", "Fernández Pérez", "Calle Princesa, 9", "Valdepeñas", 901234567, 37, "Masculino", uriImagen, "luis@example.com"));
            listado.Add(new Paciente(11, "Lucía", "García Martínez", "Calle de la Mesta, 44", "Granada", 678901234, 45, "Femenino", uriImagen, "lucia@example.com"));
            /*
            // Cargar contenido de prueba
            
            XmlDocument doc = new XmlDocument();
            var fichero = Application.GetResourceStream(new Uri("Datos/Pacientes.xml", UriKind.Relative));
            doc.Load(fichero.Stream);
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                var nuevoPaciente = new Paciente();
                nuevoPaciente.IdPaciente = Convert.ToInt32(node.Attributes["IdPaciente"].Value);
                nuevoPaciente.Nombre = node.Attributes["Nombre"].Value;
                nuevoPaciente.Apellidos = node.Attributes["Apellidos"].Value;
      
            }*/

            return listado;
            
        }

        private void btn_eliminar_pac_Click(object sender, RoutedEventArgs e)
        {
            listaPacientes.RemoveAt(dgPacientes.SelectedIndex);
            dgPacientes.Items.Refresh();
        }

        private void btn_modificar_pac_Click(object sender, RoutedEventArgs e)
        {
            if(dgPacientes.SelectedItems.Count > 1)
            {
                MessageBox.Show("No se puede modificar más de un paciente simultáneamente.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
            }else
            {
                foreach(var column in dgPacientes.Columns)
                {
                    column.Visibility = Visibility.Hidden;
                }

                tb_nombre_pac.Visibility = Visibility.Visible;
                tb_apellido_pac.Visibility = Visibility.Visible;
                tb_direccion_pac.Visibility = Visibility.Visible;
                tb_ciudad_pac.Visibility = Visibility.Visible;
                tb_telefono_pac.Visibility = Visibility.Visible;
                tb_edad_pac.Visibility = Visibility.Visible;
                tb_email_pac.Visibility = Visibility.Visible;

                tb_nombre_pac.Text = ((Paciente)dgPacientes.SelectedItem).Nombre;
                tb_apellido_pac.Text = ((Paciente)dgPacientes.SelectedItem).Apellidos;
                tb_direccion_pac.Text = ((Paciente)dgPacientes.SelectedItem).Direccion;
                tb_ciudad_pac.Text = ((Paciente)dgPacientes.SelectedItem).Ciudad;
                tb_telefono_pac.Text = ((Paciente)dgPacientes.SelectedItem).Telefono.ToString();
                tb_edad_pac.Text = ((Paciente)dgPacientes.SelectedItem).Edad.ToString();
                tb_email_pac.Text = ((Paciente)dgPacientes.SelectedItem).Email;

                btn_cancelar_modificar_pac.Visibility = Visibility.Visible;
                btn_confirmar_modificar_pac.Visibility=Visibility.Visible;
                
            }
        }

        private void btn_anadir_pac_Click(object sender, RoutedEventArgs e)
        {
            tb_nombre_pac.Visibility = Visibility.Visible;
            tb_apellido_pac.Visibility = Visibility.Visible;
            tb_direccion_pac.Visibility = Visibility.Visible;
            tb_ciudad_pac.Visibility = Visibility.Visible;
            tb_telefono_pac.Visibility = Visibility.Visible;
            tb_edad_pac.Visibility = Visibility.Visible;
            tb_email_pac.Visibility = Visibility.Visible;

            btn_cancelar_anadir_pac.Visibility = Visibility.Visible;
            btn_confirmar_anadir_pac.Visibility = Visibility.Visible;
        }

        private void dgPacientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgPacientes.SelectedItems.Count == 0)
            {
                btn_anadir_pac.IsEnabled = true;
                btn_eliminar_pac.IsEnabled = false;
                btn_modificar_pac.IsEnabled = false;
            }
            else if (dgPacientes.SelectedItems.Count == 1)
            {
                btn_anadir_pac.IsEnabled = false;
                btn_eliminar_pac.IsEnabled = true;
                btn_modificar_pac.IsEnabled = true;
            }
            else // Mas de un elemento seleccionado
            {
                btn_anadir_pac.IsEnabled = false;
                btn_eliminar_pac.IsEnabled = true;
                btn_modificar_pac.IsEnabled = false;
            }
        }

        private void btn_cancelar_exc_Click(object sender, RoutedEventArgs e)
        {
            tb_nombre_pac.Visibility = Visibility.Hidden;
            tb_apellido_pac.Visibility = Visibility.Hidden;
            tb_direccion_pac.Visibility = Visibility.Hidden;
            tb_ciudad_pac.Visibility = Visibility.Hidden;
            tb_telefono_pac.Visibility = Visibility.Hidden;
            tb_edad_pac.Visibility = Visibility.Hidden;
            tb_email_pac.Visibility = Visibility.Hidden;

            btn_anadir_pac.IsEnabled = true;
            btn_modificar_pac.IsEnabled = false;
            btn_eliminar_pac.IsEnabled = false;

            foreach (var column in dgPacientes.Columns)
            {
                column.Visibility = Visibility.Visible;
            }
        }

        private void btn_confirmar_anadir_pac_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_cancelar_anadir_pac_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_confirmar_modificar_pac_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_cancelar_modificar_pac_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
