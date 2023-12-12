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
using System.Windows.Shapes;

namespace FisioLogicV2.Windows
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        public LoginScreen()
        {
            InitializeComponent();
        }
        //Evento: Al escribir en la contraseña, al levantar el click del teclado, se muestra la tecla que se ha pulsado 
        private void passContrasena_KeyUp(object sender, KeyEventArgs e)
        {
            lblEstado.Content = "Has pulsado la tecla <<" + e.Key.ToString() + ">>";
        }
        //Evento: Pulsar el boton de login
        private string usuario = "admin";
        private string contrasena = "admin";
        private void btnLogin_click(object sender, RoutedEventArgs e)
        {
            // Si no se ha introducido el login
            if (String.IsNullOrEmpty(txtUsuario.Text) || String.IsNullOrEmpty(passContrasena.Password))
            {
                // feedback al usuario
                lblEstado.Foreground = Brushes.Red;
                lblEstado.Content = "Introduzca el usuario y la contraseña";
            }
            else
            {
                if (txtUsuario.Text.Equals(usuario) && passContrasena.Password.Equals(contrasena))
                {
                    Application.Current.Shutdown();
                }
                else
                {
                    // feedback al usuario
                    lblEstado.Foreground = Brushes.Red;
                    lblEstado.Content = "Combinación usuario-contraseña incorrecta";
                }
            }
        }
        //Evento: Verifica si el primer TextBox tiene algún texto. Si se escribe algo de texto, se habilita la contraseña
        private void habilitarContrasena(object sender, TextChangedEventArgs e)
        {

            if (!string.IsNullOrEmpty(txtUsuario.Text))
            {
                passContrasena.IsEnabled = true; // Habilita el textbox de la contraseña
            }
            else
            {
                passContrasena.IsEnabled = false; // Deshabilita el textbox si no hay texto en el usuario
            }
        }
        //Evento: Si se pulsa el boton del ojo, se muestra la contraseña
        private void MostrarContrasena_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
