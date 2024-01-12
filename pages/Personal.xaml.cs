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
        List<Limpiador> listaLimpiadores;
        private FichaPersonal ficha;
        public Personal()
        {
            InitializeComponent();

            listaSanitarios = new List<Sanitario>();
            listaLimpiadores = new List<Limpiador>();
            listaSanitarios = CargarContenidoXMLSanitarios();
            listaLimpiadores = CargarContenidoXMLLimpiadores();

            lstSanitarios.ItemsSource = listaSanitarios;
            lstLimpiadores.ItemsSource = listaLimpiadores;

        }

        //Cargar datos de los sanitarios
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

        //Cargar datos de los limpiadores
        private List<Limpiador> CargarContenidoXMLLimpiadores()  //Nos seguia sin funcionar el metodo de cargar los datos del XML, como
        {                         //viste en la segunda defensa de la practica hemos optado por cargar asi algunos datos 
            List<Limpiador> listado = new List<Limpiador>();

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

        //*******************************************************************************************************//
        //----------------------------------------- S A N I T A R I O S -----------------------------------------//
        //*******************************************************************************************************//

        //Cambiar de indice en la lista de sanitarios
        private void lstSanitarios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstSanitarios.Items.Count > 0)
            {
                visibilidad_botones_sanitarios(true, true, true);
                btn_ficha_san.IsEnabled = true;
            }
        }

        //Boton añadir un sanitario
        private void btn_anadir_san_Click(object sender, RoutedEventArgs e)
        {
            visibilidad_botones_sanitarios(false, false, false);
            btn_cancelar_anadir_san.Visibility = Visibility.Visible;
            btn_confirmar_anadir_san.Visibility= Visibility.Visible;
            activar_textboxes_san();
        }

        //Boton cancelar el añadir un sanitario
        private void btn_cancelar_anadir_san_Click(object sender, RoutedEventArgs e)
        {
            cancelar_mod_anadir_san();
        }

        //Boton confirmar el añadir un sanitario
        private void btn_confirmar_anadir_san_Click(object sender, RoutedEventArgs e)
        {
            int[] comprobar = ComprobarCampos_san();
            if (comprobar[0] == 0 && comprobar[1] == 0 && comprobar[2] == 0 && comprobar[3] == 0)
            {
                int id = listaSanitarios.Count + 1;
                listaSanitarios.Add(new Sanitario(id, tb_nombre_san.Text, tb_apellido_san.Text, int.Parse(tb_telefono_san.Text), 
                    int.Parse(tb_edad_san.Text), cb_especialidad_san.Text));

                lstSanitarios.Items.Refresh();
                cancelar_mod_anadir_san();
                MessageBox.Show("El sanitario se ha añadido correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        //Boton modificar un sanitario
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

            activar_textboxes_san();
        }

        //Boton cancelar el modificar un sanitario
        private void btn_cancelar_modificar_san_Click(object sender, RoutedEventArgs e)
        {
            cancelar_mod_anadir_san();
        }

        //Boton confirmar el modificar un sanitario
        private void btn_confirmar_modificar_san_Click(object sender, RoutedEventArgs e)
        {
            int[] comprobar = ComprobarCampos_san();
            if (comprobar[0] == 0 && comprobar[1] == 0 && comprobar[2] == 0 && comprobar[3] == 0)
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

        //Boton eliminar un sanitario
        private void btn_eliminar_san_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("¿Esta convencido de eliminar el sanitario seleccionado?", "Por favor, confirme para eliminar", MessageBoxButton.YesNo, MessageBoxImage.Warning).Equals(MessageBoxResult.Yes))
            {
                listaSanitarios.RemoveAt(lstSanitarios.SelectedIndex);
                lstSanitarios.Items.Refresh();
                visibilidad_botones_sanitarios(true, false, false);
            }
        }

        //Boton ficha de sanitario
        private void btn_ficha_san_Click(object sender, RoutedEventArgs e)
        {
            //Sanitario sanitario = listaSanitarios.ElementAt(lstSanitarios.SelectedIndex);
            //ficha = new FichaPersonal(sanitario);

            VentanaPersonal winPersonal = new VentanaPersonal();
            winPersonal.Show();

        }

        //Metodo para modificar visibilidad botones de sanitarios (añadir, modificar y eliminar)
        private void visibilidad_botones_sanitarios(Boolean anadir, Boolean modificar, Boolean eliminar)
        {
            btn_anadir_san.IsEnabled = anadir;
            btn_modificar_san.IsEnabled = modificar;
            btn_eliminar_san.IsEnabled = eliminar;
        }

        //Metodo desactivar todos los textboxes de sanitarios 
        private void desactivar_textboxes_san()
        {
            tb_nombre_san.IsEnabled = false;
            tb_apellido_san.IsEnabled = false;
            tb_edad_san.IsEnabled = false;
            tb_telefono_san.IsEnabled = false;
            cb_especialidad_san.IsEnabled = false;
        }

        //Metodo activar todos los textboxes de sanitarios
        private void activar_textboxes_san()
        {
            tb_nombre_san.IsEnabled = true;
            tb_apellido_san.IsEnabled = true;
            tb_edad_san.IsEnabled = true;
            tb_telefono_san.IsEnabled = true;
            cb_especialidad_san.IsEnabled = true;
        }

        //Metodo de lo que hace pulsar el boton cancelar tanto al estar añadiendo como modificando
        private void cancelar_mod_anadir_san()
        {
            tb_nombre_san.Text = string.Empty;
            tb_apellido_san.Text = string.Empty;
            tb_edad_san.Text = string.Empty;
            tb_telefono_san.Text = string.Empty;
            btn_cancelar_anadir_san.Visibility = Visibility.Hidden;
            btn_confirmar_anadir_san.Visibility = Visibility.Hidden;
            visibilidad_botones_sanitarios(true, false, false);
            desactivar_textboxes_san();
        }

        //*******************************************************************************************************//
        //---------------------------------------- L I M P I A D O R E S ----------------------------------------//
        //*******************************************************************************************************//

        //Cambiar de indice en la lista de limpiadores
        private void lstLimpiadores_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstLimpiadores.Items.Count > 0)
            {
                visibilidad_botones_limpiadores(true, true, true);
                btn_ficha_lim.IsEnabled = true;
            }
        }

        //Boton añadir un limpiador
        private void btn_anadir_lim_Click(object sender, RoutedEventArgs e)
        {
            visibilidad_botones_limpiadores(false, false, false);
            btn_cancelar_anadir_lim.Visibility = Visibility.Visible;
            btn_confirmar_anadir_lim.Visibility = Visibility.Visible;
            activar_textboxes_lim();
        }

        //Boton cancelar el añadir un limpiador
        private void btn_cancelar_anadir_lim_Click(object sender, RoutedEventArgs e)
        {
            cancelar_mod_anadir_lim();
        }

        //Boton confirmar el añadir un limpiador
        private void btn_confirmar_anadir_lim_Click(object sender, RoutedEventArgs e)
        {
            int[] comprobar = ComprobarCampos_lim();
            if (comprobar[0] == 0 && comprobar[1] == 0 && comprobar[2] == 0 && comprobar[3] == 0)
            {
                int id = listaLimpiadores.Count + 1;
                listaLimpiadores.Add(new Limpiador(id, tb_nombre_lim.Text, tb_apellido_lim.Text, int.Parse(tb_edad_lim.Text),
                    int.Parse(tb_telefono_lim.Text), cb_areaasignada_lim.Text));

                lstLimpiadores.Items.Refresh();
                cancelar_mod_anadir_lim();
                MessageBox.Show("El limpiador se ha añadido correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        //Boton modificar un limpiador
        private void btn_modificar_lim_Click(object sender, RoutedEventArgs e)
        {
            visibilidad_botones_limpiadores(false, false, false);
            btn_cancelar_modificar_lim.Visibility = Visibility.Visible;
            btn_confirmar_modificar_lim.Visibility = Visibility.Visible;

            tb_nombre_lim.Text = ((Limpiador)lstLimpiadores.SelectedItem).Nombre;
            tb_apellido_lim.Text = ((Limpiador)lstLimpiadores.SelectedItem).Apellidos;
            tb_edad_lim.Text = ((Limpiador)lstLimpiadores.SelectedItem).Edad.ToString();
            tb_telefono_lim.Text = ((Limpiador)lstLimpiadores.SelectedItem).Telefono.ToString();
            cb_areaasignada_lim.Text = ((Limpiador)lstLimpiadores.SelectedItem).AreaAsignada.ToString();

            activar_textboxes_lim();
        }

        //Boton cancelar el modificar un limpiador
        private void btn_cancelar_modificar_lim_Click(object sender, RoutedEventArgs e)
        {
            cancelar_mod_anadir_lim();
        }

        //Boton confirmar el modificar un limpiador
        private void btn_confirmar_modificar_lim_Click(object sender, RoutedEventArgs e)
        {
            int[] comprobar = ComprobarCampos_lim();
            if (comprobar[0] == 0 && comprobar[1] == 0 && comprobar[2] == 0 && comprobar[3] == 0)
            {
                Limpiador limpiador = listaLimpiadores.ElementAt(lstLimpiadores.SelectedIndex);
                limpiador.Nombre = tb_nombre_lim.Text;
                limpiador.Apellidos = tb_apellido_lim.Text;
                limpiador.Edad = int.Parse(tb_edad_lim.Text);
                limpiador.Telefono = int.Parse(tb_telefono_lim.Text);
                limpiador.AreaAsignada = cb_areaasignada_lim.Text;
                lstLimpiadores.Items.Refresh();
                cancelar_mod_anadir_lim();
                MessageBox.Show("El limpiador se ha modificado correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        //Boton eliminar un limpiador
        private void btn_eliminar_lim_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("¿Esta convencido de eliminar el limpiador seleccionado?", "Por favor, confirme para eliminar", MessageBoxButton.YesNo, MessageBoxImage.Warning).Equals(MessageBoxResult.Yes))
            {
                listaLimpiadores.RemoveAt(lstLimpiadores.SelectedIndex);
                lstLimpiadores.Items.Refresh();
                visibilidad_botones_limpiadores(true, false, false);
            }
        }

        //Boton ficha de limpiador
        private void btn_ficha_lim_Click(object sender, RoutedEventArgs e)
        {
            //Limpiador limpiador = listaLimpiadores.ElementAt(lstLimpiadores.SelectedIndex);
            //ficha = new FichaPersonal(limpiador);

            VentanaPersonal winPersonal = new VentanaPersonal();
            winPersonal.Show();
        }

        //Metodo para modificar visibilidad botones de limpiadores (añadir, modificar y eliminar)
        private void visibilidad_botones_limpiadores(Boolean anadir, Boolean modificar, Boolean eliminar)
        {
            btn_anadir_lim.IsEnabled = anadir;
            btn_modificar_lim.IsEnabled = modificar;
            btn_eliminar_lim.IsEnabled = eliminar;
        }

        //Metodo desactivar todos los textboxes de limpiadores 
        private void desactivar_textboxes_lim()
        {
            tb_nombre_lim.IsEnabled = false;
            tb_apellido_lim.IsEnabled = false;
            tb_edad_lim.IsEnabled = false;
            tb_telefono_lim.IsEnabled = false;
            cb_areaasignada_lim.IsEnabled = false;
        }

        //Metodo activar todos los textboxes de limpiadores
        private void activar_textboxes_lim()
        {
            tb_nombre_lim.IsEnabled = true;
            tb_apellido_lim.IsEnabled = true;
            tb_edad_lim.IsEnabled = true;
            tb_telefono_lim.IsEnabled = true;
            cb_areaasignada_lim.IsEnabled = true;
        }

        //Metodo de lo que hace pulsar el boton cancelar tanto al estar añadiendo como modificando
        private void cancelar_mod_anadir_lim()
        {
            tb_nombre_lim.Text = string.Empty;
            tb_apellido_lim.Text = string.Empty;
            tb_edad_lim.Text = string.Empty;
            tb_telefono_lim.Text = string.Empty;
            btn_cancelar_anadir_lim.Visibility = Visibility.Hidden;
            btn_confirmar_anadir_lim.Visibility = Visibility.Hidden;
            visibilidad_botones_limpiadores(true, false, false);
            desactivar_textboxes_lim();
        }

        //*******************************************************************************************************//
        //------------------------------------- C O M P R O B A C I O N E S -------------------------------------//
        //*******************************************************************************************************//

        //Comprobar que un string contiene algun numero
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

        //Comprobar que un string contiene algun caracter
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

        //Comprobar campos de los sanitarios
        private int[] ComprobarCampos_san()
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
                comprobacion[2] = -1;
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
                comprobacion[3] = -1;
            }
            else
            {
                tb_edad_san.ClearValue(Border.BorderBrushProperty);
                tb_edad_san.ClearValue(Border.BorderThicknessProperty);
            }

            return comprobacion;
        }

        //Comprobar campos de los limpiadores
        private int[] ComprobarCampos_lim()
        {
            int[] comprobacion = new int[4];

            if (ContieneNumeros(tb_nombre_lim.Text))
            {
                tb_nombre_lim.BorderBrush = Brushes.Red;
                tb_nombre_lim.BorderThickness = new Thickness(1.5);
                comprobacion[0] = -1;
            }
            else
            {
                tb_nombre_lim.ClearValue(Border.BorderBrushProperty);
                tb_nombre_lim.ClearValue(Border.BorderThicknessProperty);
            }

            if (ContieneNumeros(tb_apellido_lim.Text))
            {
                tb_apellido_lim.BorderBrush = Brushes.Red;
                tb_apellido_lim.BorderThickness = new Thickness(1.5);
                comprobacion[1] = -1;
            }
            else
            {
                tb_apellido_lim.ClearValue(Border.BorderBrushProperty);
                tb_apellido_lim.ClearValue(Border.BorderThicknessProperty);
            }

            if (ContieneCaracteres(tb_telefono_lim.Text) || tb_telefono_lim.Text.Length != 9)
            {
                tb_telefono_lim.BorderBrush = Brushes.Red;
                tb_telefono_lim.BorderThickness = new Thickness(1.5);
                comprobacion[2] = -1;
            }
            else
            {
                tb_telefono_lim.ClearValue(Border.BorderBrushProperty);
                tb_telefono_lim.ClearValue(Border.BorderThicknessProperty);
            }

            if (ContieneCaracteres(tb_edad_lim.Text) || tb_edad_lim.Text.Length < 1 || tb_edad_lim.Text.Length > 2)
            {
                tb_edad_lim.BorderBrush = Brushes.Red;
                tb_edad_lim.BorderThickness = new Thickness(1.5);
                comprobacion[3] = -1;
            }
            else
            {
                tb_edad_lim.ClearValue(Border.BorderBrushProperty);
                tb_edad_lim.ClearValue(Border.BorderThicknessProperty);
            }

            return comprobacion;
        }
    }
}
