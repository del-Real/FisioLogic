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
        List<Sanitario> listaSanitarios;
        List<Profesional> listaLimpiadores;
        public Personal()
        {
            InitializeComponent();

            listaSanitarios = new List<Sanitario>();
            listaLimpiadores = new List<Profesional>();
            listaSanitarios = CargarContenidoXMLSanitarios();
            listaLimpiadores = CargarContenidoXMLLimpiadores();

            lstSanitarios.ItemsSource = listaSanitarios;
            lstLimpiadores.ItemsSource = listaLimpiadores;

        }
        private List<Sanitario> CargarContenidoXMLSanitarios()  //Nos seguia sin funcionar el metodo de cargar los datos del XML, como
        {                         //viste en la segunda defensa de la practica hemos optado por cargar asi algunos datos 
            List<Sanitario> listado = new List<Sanitario>();

            string rutaFoto0 = "FisioLogic\\fotosPacientes\\pedrogarcia.jpg";
            string rutaFoto1 = "FisioLogic\\fotosPacientes\\mariamartinez.jpg";
            string rutaFoto2 = "FisioLogic\\fotosPacientes\\juanlopez.jpg";
            string rutaFoto3 = "FisioLogic\\fotosPacientes\\laurarodriguez.jpg";
            Uri uriImagen0 = new Uri(rutaFoto0, UriKind.RelativeOrAbsolute);
            Uri uriImagen1 = new Uri(rutaFoto1, UriKind.RelativeOrAbsolute);
            Uri uriImagen2 = new Uri(rutaFoto2, UriKind.RelativeOrAbsolute);
            Uri uriImagen3 = new Uri(rutaFoto3, UriKind.RelativeOrAbsolute);
            listado.Add(new Sanitario(0, "Jesus", "López Velasco", 28, uriImagen0, 656434287, "Traumatologia"));
            listado.Add(new Sanitario(1, "Amanda", "Martínez López", 32, uriImagen1, 667721990, "Traumatologia"));
            listado.Add(new Sanitario(3, "Óscar", "Rodríguez de la Torre", 33, uriImagen2, 654321987, "Entrenamiento"));
            listado.Add(new Sanitario(4, "Carlos", "Díaz Alonso", 26, uriImagen3, 612347645, "Reumatología"));

            return listado;
        }

        private List<Profesional> CargarContenidoXMLLimpiadores()  //Nos seguia sin funcionar el metodo de cargar los datos del XML, como
        {                         //viste en la segunda defensa de la practica hemos optado por cargar asi algunos datos 
            List<Profesional> listado = new List<Profesional>();

            string rutaFoto4 = "FisioLogic\\fotosPacientes\\carlosperez.jpg";
            string rutaFoto5 = "FisioLogic\\fotosPacientes\\sofiasanchez.jpg";
            string rutaFoto6 = "FisioLogic\\fotosPacientes\\diegoalvarez.jpg";
            Uri uriImagen4 = new Uri(rutaFoto4, UriKind.RelativeOrAbsolute);
            Uri uriImagen5 = new Uri(rutaFoto5, UriKind.RelativeOrAbsolute);
            Uri uriImagen6 = new Uri(rutaFoto6, UriKind.RelativeOrAbsolute);
            listado.Add(new Limpiador(5, "Lucía", "Garrido Bonito", 47, uriImagen4, 678901234, "Clínica"));
            listado.Add(new Limpiador(6, "Manuel", "García Caro", 38, uriImagen5, 687670441, "Recibidor"));
            listado.Add(new Limpiador(7, "Sonia", "Francisco Rey", 45, uriImagen6, 600675923, "Salas"));

            return listado;
        }

        private void lstSanitarios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstSanitarios.Items.Count > 0)
            {
                visibilidad_botones_sanitarios(false, true, true);
            }
        }

        private void lstLimpiadores_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstLimpiadores.Items.Count > 0)
            {
                visibilidad_botones_limpiadores(false, true, true);
            }
        }

        private void btn_anadir_san_Click(object sender, RoutedEventArgs e)
        {
            visibilidad_botones_sanitarios(false, false, false);
            btn_cancelar_anadir_san.Visibility = Visibility.Visible;
            btn_confirmar_anadir_san.Visibility= Visibility.Visible;
            activar_textboxes();
        }

        private void btn_cancelar_anadir_san_Click(object sender, RoutedEventArgs e)
        {
            cancelar_mod_anadir_san();
        }

        private void btn_confirmar_anadir_san_Click(object sender, RoutedEventArgs e)
        {
            int[] comprobar = ComprobarCampos();
            if (comprobar[0] == 0 && comprobar[1] == 0 && comprobar[2] == 0 && comprobar[3] == 0 && comprobar[4] == 0)
            {
                int id = listaSanitarios.Count + 1;
                listaSanitarios.Add(new Sanitario(id, tb_nombre_san.Text, tb_apellido_san.Text, int.Parse(tb_telefono_san.Text), 
                    int.Parse(tb_edad_san.Text), cb_especialidad_san.Text));

                lstSanitarios.Items.Refresh();
                cancelar_mod_anadir_san();
                MessageBox.Show("El sanitario se ha añadido correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btn_modificar_san_Click(object sender, RoutedEventArgs e)
        {
            visibilidad_botones_sanitarios(false, false, false);
            btn_cancelar_modificar_san.Visibility = Visibility.Visible;
            btn_confirmar_modificar_san.Visibility = Visibility.Visible;

            tb_nombre_san.Text = ((Sanitario)lstSanitarios.SelectedItem).Nombre;
            tb_apellido_san.Text = ((Sanitario)lstSanitarios.SelectedItem).Apellidos;
            tb_telefono_san.Text = ((Sanitario)lstSanitarios.SelectedItem).Telefono.ToString();
            tb_edad_san.Text = ((Sanitario)lstSanitarios.SelectedItem).Edad.ToString();
            cb_especialidad_san.Text = ((Sanitario)lstSanitarios.SelectedItem).Especialidad.ToString();

            activar_textboxes();
        }

        private void btn_cancelar_modificar_san_Click(object sender, RoutedEventArgs e)
        {
            cancelar_mod_anadir_san();
        }

        private void btn_confirmar_modificar_san_Click(object sender, RoutedEventArgs e)
        {
            int[] comprobar = ComprobarCampos();
            if (comprobar[0] == 0 && comprobar[1] == 0 && comprobar[2] == 0 && comprobar[3] == 0 && comprobar[4] == 0)
            {
                Sanitario sanitario = listaSanitarios.ElementAt(lstSanitarios.SelectedIndex);
                sanitario.Nombre = tb_nombre_san.Text;
                sanitario.Apellidos = tb_apellido_san.Text;
                sanitario.Edad = int.Parse(tb_edad_san.Text);
                sanitario.Telefono = int.Parse(tb_telefono_san.Text);
                sanitario.Especialidad = cb_especialidad_san.Text;
                lstSanitarios.Items.Refresh();
                cancelar_mod_anadir_san();
                MessageBox.Show("El paciente se ha modificado correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btn_eliminar_san_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("¿Esta convencido de eliminar el sanitario seleccionado?", "Por favor, confirme para eliminar", MessageBoxButton.YesNo, MessageBoxImage.Warning).Equals(MessageBoxResult.Yes))
            {
                listaSanitarios.RemoveAt(lstSanitarios.SelectedIndex);
                lstSanitarios.Items.Refresh();
                visibilidad_botones_sanitarios(true, false, false);
            }
        }

        private void btn_anadir_lim_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_modificar_lim_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_eliminar_lim_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("¿Esta convencido de eliminar el limpiador seleccionado?", "Por favor, confirme para eliminar", MessageBoxButton.YesNo, MessageBoxImage.Warning).Equals(MessageBoxResult.Yes))
            {
                listaLimpiadores.RemoveAt(lstLimpiadores.SelectedIndex);
                lstLimpiadores.Items.Refresh();
                visibilidad_botones_limpiadores(true, false, false);
            }
        }

        private void visibilidad_botones_sanitarios(Boolean anadir, Boolean modificar, Boolean eliminar)
        {
            btn_anadir_san.IsEnabled = anadir;
            btn_modificar_san.IsEnabled = modificar;
            btn_eliminar_san.IsEnabled = eliminar;
        }

        private void visibilidad_botones_limpiadores(Boolean anadir, Boolean modificar, Boolean eliminar)
        {
            btn_anadir_lim.IsEnabled = anadir;
            btn_modificar_lim.IsEnabled = modificar;
            btn_eliminar_lim.IsEnabled = eliminar;
        }

        private void cancelar_mod_anadir_san()
        {
            tb_nombre_san.Text = string.Empty;
            tb_apellido_san.Text = string.Empty;
            tb_edad_san.Text = string.Empty;
            tb_telefono_san.Text = string.Empty;
            btn_cancelar_anadir_san.Visibility = Visibility.Hidden;
            btn_confirmar_anadir_san.Visibility = Visibility.Hidden;
            visibilidad_botones_sanitarios(true, false, false);
            desactivar_textboxes();
        }

        private void activar_textboxes()
        {
            tb_nombre_san.IsEnabled = true;
            tb_apellido_san.IsEnabled = true;
            tb_edad_san.IsEnabled = true;
            tb_telefono_san.IsEnabled = true;
            cb_especialidad_san.IsEnabled = true;
        }

        private void desactivar_textboxes()
        {
            tb_nombre_san.IsEnabled = false;
            tb_apellido_san.IsEnabled = false;
            tb_edad_san.IsEnabled = false;
            tb_telefono_san.IsEnabled = false;
            cb_especialidad_san.IsEnabled = false;
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
            int[] comprobacion = new int[4];

            if (ContieneNumeros(tb_nombre_san.Text))
            {
                tb_nombre_san.BorderBrush = Brushes.Red;
                tb_nombre_san.BorderThickness = new Thickness(1.5);
                comprobacion[0] = -1;
            }
            else
            {
                tb_nombre_san.ClearValue(Border.BorderBrushProperty);
                tb_nombre_san.ClearValue(Border.BorderThicknessProperty);
            }

            if (ContieneNumeros(tb_apellido_san.Text))
            {
                tb_apellido_san.BorderBrush = Brushes.Red;
                tb_apellido_san.BorderThickness = new Thickness(1.5);
                comprobacion[1] = -1;
            }
            else
            {
                tb_apellido_san.ClearValue(Border.BorderBrushProperty);
                tb_apellido_san.ClearValue(Border.BorderThicknessProperty);
            }

            if (ContieneCaracteres(tb_telefono_san.Text) || tb_telefono_san.Text.Length != 9)
            {
                tb_telefono_san.BorderBrush = Brushes.Red;
                tb_telefono_san.BorderThickness = new Thickness(1.5);
                comprobacion[3] = -1;
            }
            else
            {
                tb_telefono_san.ClearValue(Border.BorderBrushProperty);
                tb_telefono_san.ClearValue(Border.BorderThicknessProperty);
            }

            if (ContieneCaracteres(tb_edad_san.Text) || tb_edad_san.Text.Length < 1 || tb_edad_san.Text.Length > 2)
            {
                tb_edad_san.BorderBrush = Brushes.Red;
                tb_edad_san.BorderThickness = new Thickness(1.5);
                comprobacion[4] = -1;
            }
            else
            {
                tb_edad_san.ClearValue(Border.BorderBrushProperty);
                tb_edad_san.ClearValue(Border.BorderThicknessProperty);
            }

            return comprobacion;
        }
    }
}
