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
using System.Xml.Linq;

namespace FisioLogicV2.Pages
{
    public partial class Pacientes : Page
    {
        List<Paciente> listaPacientes;
        public Pacientes()
        {
            InitializeComponent();
            listaPacientes = new List<Paciente>();
            // Se cargarán los datos de prueba de un fichero XML
            listaPacientes = CargarContenidoXML();

            dgPacientes.ItemsSource = listaPacientes;
            
        }
        
        //Cargar los datos de los pacientes
        private List<Paciente> CargarContenidoXML()  //Nos seguia sin funcionar el metodo de cargar los datos del XML, como
        {                         //viste en la segunda defensa de la practica hemos optado por cargar asi algunos datos 
            List<Paciente> listado = new List<Paciente>();
            string rutaFoto0 = "Assets\\fotosPacientes\\pedrogarcia.jpg";
            string rutaFoto1 = "FisioLogic\\fotosPacientes\\mariamartinez.jpg";
            string rutaFoto2 = "FisioLogic\\fotosPacientes\\juanlopez.jpg";
            string rutaFoto3 = "FisioLogic\\fotosPacientes\\laurarodriguez.jpg";
            string rutaFoto4 = "FisioLogic\\fotosPacientes\\carlosperez.jpg";
            string rutaFoto5 = "FisioLogic\\fotosPacientes\\sofiasanchez.jpg";
            string rutaFoto6 = "FisioLogic\\fotosPacientes\\diegoalvarez.jpg";
            string rutaFoto7 = "FisioLogic\\fotosPacientes\\anagonzalez.jpg";
            string rutaFoto8 = "FisioLogic\\fotosPacientes\\javiermartinez.jpg";
            string rutaFoto9 = "FisioLogic\\fotosPacientes\\elenarodriguez.jpg";
            string rutaFoto10 = "FisioLogic\\fotosPacientes\\luisfernandez.jpg";
            string rutaFoto11 = "FisioLogic\\fotosPacientes\\luciagarcia.jpg";
            Uri uriImagen0 = new Uri(rutaFoto0, UriKind.RelativeOrAbsolute);
            Uri uriImagen1 = new Uri(rutaFoto1, UriKind.RelativeOrAbsolute);
            Uri uriImagen2 = new Uri(rutaFoto2, UriKind.RelativeOrAbsolute);
            Uri uriImagen3 = new Uri(rutaFoto3, UriKind.RelativeOrAbsolute);
            Uri uriImagen4 = new Uri(rutaFoto4, UriKind.RelativeOrAbsolute);
            Uri uriImagen5 = new Uri(rutaFoto5, UriKind.RelativeOrAbsolute);
            Uri uriImagen6 = new Uri(rutaFoto6, UriKind.RelativeOrAbsolute);
            Uri uriImagen7 = new Uri(rutaFoto7, UriKind.RelativeOrAbsolute);
            Uri uriImagen8 = new Uri(rutaFoto8, UriKind.RelativeOrAbsolute);
            Uri uriImagen9 = new Uri(rutaFoto9, UriKind.RelativeOrAbsolute);
            Uri uriImagen10 = new Uri(rutaFoto10, UriKind.RelativeOrAbsolute);
            Uri uriImagen11 = new Uri(rutaFoto11, UriKind.RelativeOrAbsolute);
            listado.Add(new Paciente(0, "Pedro", "García López", "Calle Manzana, 103", "Manzanares", 123456789, 40, "Masculino", uriImagen0, "pedro@example.com"));
            listado.Add(new Paciente(1, "María", "Martínez Gómez", "Avenida Principal, 45", "Granada", 987654321, 35, "Femenino", uriImagen1, "maria@example.com"));
            listado.Add(new Paciente(2, "Juan", "López González", "Carrera 245, Portal A", "Valdepeñas", 567890123, 50, "Masculino", uriImagen2, "juan@example.com"));
            listado.Add(new Paciente(3, "Laura", "Rodríguez Fernández", "Callejón Albolote, 3", "Toledo", 654321987, 42, "Femenino", uriImagen3, "laura@example.com"));
            listado.Add(new Paciente(4, "Carlos", "Pérez Díaz", "Paseo de las Tinajas, 1", "Bolaños de Calatrava", 789012345, 28, "Masculino", uriImagen4, "carlos@example.com"));
            listado.Add(new Paciente(5, "Sofía", "Sánchez Romero", "Avenida Principal, 203B", "Valencia", 456789012, 48, "Femenino", uriImagen5, "sofia@example.com"));
            listado.Add(new Paciente(6, "Diego", "Alvarez Moreno", "Calle Magdalena, 13", "Valdepeñas", 345678901, 55, "Masculino", uriImagen6, "diego@example.com"));
            listado.Add(new Paciente(7, "Ana", "González García", "Calle Cardenal Monescillo, 12", "La Solana", 234567890, 33, "Femenino", uriImagen7, "ana@example.com"));
            listado.Add(new Paciente(8, "Javier", "Martínez López", "Calle de las Virtudes, 21", "Manzanares", 123456789, 60, "Masculino", uriImagen8, "javier@example.com"));
            listado.Add(new Paciente(9, "Elena", "Rodríguez Fernández", "Calle Neotica, 4", "Ciudad Real", 890123456, 25, "Femenino", uriImagen9, "elena@example.com"));
            listado.Add(new Paciente(10, "Luis", "Fernández Pérez", "Calle Princesa, 9", "Valdepeñas", 901234567, 37, "Masculino", uriImagen10, "luis@example.com"));
            listado.Add(new Paciente(11, "Lucía", "García Martínez", "Calle de la Mesta, 44", "Granada", 678901234, 45, "Femenino", uriImagen11, "lucia@example.com"));

            return listado;
        }

        //Evento de cambio de indice del datagrid
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

        //Añadir un paciente
        private void btn_anadir_pac_Click(object sender, RoutedEventArgs e)
        {
            tb_nombre_pac.Visibility = Visibility.Visible;
            tb_apellido_pac.Visibility = Visibility.Visible;
            tb_direccion_pac.Visibility = Visibility.Visible;
            tb_ciudad_pac.Visibility = Visibility.Visible;
            tb_telefono_pac.Visibility = Visibility.Visible;
            tb_edad_pac.Visibility = Visibility.Visible;
            cb_genero_pac.Visibility = Visibility.Visible;
            tb_email_pac.Visibility = Visibility.Visible;

            btn_cancelar_anadir_pac.Visibility = Visibility.Visible;
            btn_confirmar_anadir_pac.Visibility = Visibility.Visible;
        }

        //Cancelar de añadir un nuevo paciente
        private void btn_cancelar_anadir_pac_Click(object sender, RoutedEventArgs e)
        {
            cancelar_mod_anadir();
        }

        //Confirmar de añadir un nuevo paciente
        private void btn_confirmar_anadir_pac_Click(object sender, RoutedEventArgs e)
        {
            int[] comprobar = ComprobarCampos();
            if (comprobar[0] == 0 && comprobar[1] == 0 && comprobar[2] == 0 && comprobar[3] == 0 && comprobar[4] == 0)
            {
                int id = listaPacientes.Count + 1;
                listaPacientes.Add(new Paciente(id, tb_nombre_pac.Text, tb_apellido_pac.Text, tb_direccion_pac.Text, tb_ciudad_pac.Text,
                    int.Parse(tb_telefono_pac.Text), int.Parse(tb_edad_pac.Text), cb_genero_pac.Text, tb_email_pac.Text));

                dgPacientes.Items.Refresh();
                cancelar_mod_anadir();
                MessageBox.Show("El paciente se ha añadido correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        //Modificar un paciente
        private void btn_modificar_pac_Click(object sender, RoutedEventArgs e)
        {
            if (dgPacientes.SelectedItems.Count > 1)
            {
                MessageBox.Show("No se puede modificar más de un paciente simultáneamente.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                foreach (var column in dgPacientes.Columns)
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
                btn_confirmar_modificar_pac.Visibility = Visibility.Visible;


            }
        }

        //Cancelar modificar un paciente
        private void btn_cancelar_modificar_pac_Click(object sender, RoutedEventArgs e)
        {
            cancelar_mod_anadir();
        }

        //Confirmar modificar un paciente
        private void btn_confirmar_modificar_pac_Click(object sender, RoutedEventArgs e)
        {
            int[] comprobar = ComprobarCampos();
            if (comprobar[0] == 0 && comprobar[1] == 0 && comprobar[2] == 0 && comprobar[3] == 0 && comprobar[4] == 0)
            {
                Paciente paciente = listaPacientes.ElementAt(dgPacientes.SelectedIndex);
                paciente.Nombre = tb_nombre_pac.Text;
                paciente.Apellidos = tb_apellido_pac.Text;
                paciente.Direccion = tb_direccion_pac.Text;
                paciente.Ciudad = tb_ciudad_pac.Text;
                paciente.Telefono = int.Parse(tb_telefono_pac.Text);
                paciente.Edad = int.Parse(tb_edad_pac.Text);
                paciente.Email = tb_email_pac.Text;

                dgPacientes.Items.Refresh();
                cancelar_mod_anadir();
                MessageBox.Show("El paciente se ha modificado correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }


        //Eliminar un paciente
        private void btn_eliminar_pac_Click(object sender, RoutedEventArgs e)
        {
            List<Paciente> filasSeleccionadas = new List<Paciente>();
            foreach (Paciente paciente in dgPacientes.SelectedItems)
            {
                filasSeleccionadas.Add(paciente);
            }
            if (MessageBox.Show("¿Esta convencido de eliminar el paciente seleccionado?", "Por favor, confirme para eliminar", MessageBoxButton.YesNo, MessageBoxImage.Warning).Equals(MessageBoxResult.Yes))
            {
                foreach (Paciente paciente in filasSeleccionadas)
                {
                    listaPacientes.Remove(paciente);
                }
            }
            dgPacientes.Items.Refresh();
            
        }

        //Lo que hacen los dos botones de cancelar (tanto en añadir como en modificar)
        private void cancelar_mod_anadir()
        {
            tb_nombre_pac.Text = string.Empty;
            tb_apellido_pac.Text = string.Empty;
            tb_direccion_pac.Text = string.Empty;
            tb_ciudad_pac.Text = string.Empty;
            tb_telefono_pac.Text = string.Empty;
            tb_edad_pac.Text = string.Empty;
            cb_genero_pac.SelectedIndex = -1;
            tb_email_pac.Text = string.Empty;

            tb_nombre_pac.Visibility = Visibility.Hidden;
            tb_apellido_pac.Visibility = Visibility.Hidden;
            tb_direccion_pac.Visibility = Visibility.Hidden;
            tb_ciudad_pac.Visibility = Visibility.Hidden;
            tb_telefono_pac.Visibility = Visibility.Hidden;
            tb_edad_pac.Visibility = Visibility.Hidden;
            cb_genero_pac.Visibility = Visibility.Hidden;
            tb_email_pac.Visibility = Visibility.Hidden;

            btn_anadir_pac.IsEnabled = true;
            btn_modificar_pac.IsEnabled = false;
            btn_eliminar_pac.IsEnabled = false;
            btn_cancelar_anadir_pac.Visibility = Visibility.Hidden;
            btn_cancelar_modificar_pac.Visibility = Visibility.Hidden;
            btn_confirmar_anadir_pac.Visibility = Visibility.Hidden;
            btn_confirmar_modificar_pac.Visibility = Visibility.Hidden;

        }

        //Comprobaciones
        private bool ContieneNumeros(string texto)
        {
            foreach (char caracter in texto)
            {
                if (char.IsDigit(caracter))
                {
                    return true; // Devuelve true si encuentra al menos un número
                }
            }
            return false; // Devuelve false si no encuentra ningún número
        }

        private bool ContieneCaracteres(string texto)
        {
            foreach (char caracter in texto)
            {
                if (char.IsLetter(caracter))
                {
                    return true; // Devuelve true si encuentra al menos una letra
                }
            }
            return false; // Devuelve false si no encuentra ninguna letra
        }

        private int[] ComprobarCampos()
        {
            int[] comprobacion = new int[5]; 

            if (ContieneNumeros(tb_nombre_pac.Text))
            {
                tb_nombre_pac.BorderBrush = Brushes.Red;
                tb_nombre_pac.BorderThickness = new Thickness(1.5);
                comprobacion[0] = -1;
            }
            else
            {
                tb_nombre_pac.ClearValue(Border.BorderBrushProperty);
                tb_nombre_pac.ClearValue(Border.BorderThicknessProperty);
            }

            if (ContieneNumeros(tb_apellido_pac.Text))
            {
                tb_apellido_pac.BorderBrush = Brushes.Red;
                tb_apellido_pac.BorderThickness = new Thickness(1.5);
                comprobacion[1] = -1;
            }
            else
            {
                tb_apellido_pac.ClearValue(Border.BorderBrushProperty);
                tb_apellido_pac.ClearValue(Border.BorderThicknessProperty);
            }

            if (ContieneNumeros(tb_ciudad_pac.Text))
            {
                tb_ciudad_pac.BorderBrush = Brushes.Red;
                tb_ciudad_pac.BorderThickness = new Thickness(1.5);
                comprobacion[2] = -1;
            }
            else
            {
                tb_ciudad_pac.ClearValue(Border.BorderBrushProperty);
                tb_ciudad_pac.ClearValue(Border.BorderThicknessProperty);
            }

            if (ContieneCaracteres(tb_telefono_pac.Text) || tb_telefono_pac.Text.Length != 9)
            {
                tb_telefono_pac.BorderBrush = Brushes.Red;
                tb_telefono_pac.BorderThickness = new Thickness(1.5);
                comprobacion[3] = -1;
            }
            else
            {
                tb_telefono_pac.ClearValue(Border.BorderBrushProperty);
                tb_telefono_pac.ClearValue(Border.BorderThicknessProperty);
            }

            if (ContieneCaracteres(tb_edad_pac.Text) || tb_edad_pac.Text.Length < 1 || tb_edad_pac.Text.Length > 2)
            {
                tb_edad_pac.BorderBrush = Brushes.Red;
                tb_edad_pac.BorderThickness = new Thickness(1.5);
                comprobacion[4] = -1;
            }
            else
            {
                tb_edad_pac.ClearValue(Border.BorderBrushProperty);
                tb_edad_pac.ClearValue(Border.BorderThicknessProperty);
            }

            return comprobacion;
        }
    }
}
