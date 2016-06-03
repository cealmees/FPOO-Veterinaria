using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Veterinaria_FPOO
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

        }

        private void logIn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void logInbtn_Click(object sender, RoutedEventArgs e)
        {
            logInfrm.Visibility = Visibility.Visible;
        }

        private void enviarFrm_Click(object sender, RoutedEventArgs e)
        {
            LogIn accesoUsuario = new LogIn(userFrm.Text, passwordFrm.Password);

            bool aux = accesoUsuario.autenticarUsuario();
            if (aux == true)
            {
                logInfrm.Visibility = Visibility.Collapsed;



                MySplitView.Visibility = Visibility.Visible;

                logInbtn.Visibility = Visibility.Collapsed;
                logOutbtn.Visibility = Visibility.Visible;

            }

            else
                resultado.Visibility = Visibility.Visible;

        }

        private void cancerlarFrm_Click(object sender, RoutedEventArgs e)
        {
            logInfrm.Visibility = Visibility.Collapsed;
        }
        private void logOutbtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }



        private void Inventario_Click(object sender, RoutedEventArgs e)
        {

            lvInvProd.Visibility = Visibility.Collapsed;
            CreadorCitas.Visibility = Visibility.Collapsed;
            CreadorProductos.Visibility = Visibility.Visible;
            bienvenidaUsuario.Text = "Productos";

        }

        private void NuevoIngrediente_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CrearTortas_Click(object sender, RoutedEventArgs e)
        {
            CreadorProductos.Visibility = Visibility.Collapsed;
            lvInvProd.Visibility = Visibility.Visible;
            CreadorCitas.Visibility = Visibility.Collapsed;

            MostrarMySQL inventarioVet = new MostrarMySQL();
            InventarioProductosVeterinaria.ItemsSource = inventarioVet.mostrarLV();
        }



        private void Home_Click(object sender, RoutedEventArgs e)
        {
            CreadorProductos.Visibility = Visibility.Collapsed;
            CreadorCitas.Visibility = Visibility.Visible;
            lvInvProd.Visibility = Visibility.Collapsed;
            MostrarCitas ListaCitas = new MostrarCitas();
            FuturasCitas.ItemsSource = null;
            FuturasCitas.ItemsSource = ListaCitas.mostrarLV();

        }




        GenerarCita citaGenerar = new GenerarCita();

        private void btnEnviarCita_Click(object sender, RoutedEventArgs e)
        {
            citaGenerar.insertarDatos(tbNombreCliente.Text, tbApellidoCliente.Text, tbFechaCita.Date.ToString("yyyy-MM-dd"), tbCitaHora.Time.ToString());
            tbNombreCliente.Text = String.Empty;
            tbApellidoCliente.Text = String.Empty;
            tbCitaHora.Time = DateTime.Now.TimeOfDay;
            tbFechaCita.Date = DateTime.Now;
            GenerarProductos prueba = new GenerarProductos();
            prueba.insertarProductos("Alimento", 89, 5000);

        }
        GenerarProductos productoGenerar = new GenerarProductos();

        private void btnEnviarProducto_Click(object sender, RoutedEventArgs e)
        {
            int index = MenuCategorias.SelectedIndex;
            string opcion = "";

            switch (index)
            {
                case 0:
                    opcion = "Accesorios";
                    break;
                case 1:
                    opcion = "Alimento";
                    break;
                case 2:
                    opcion = "Mascotas";
                    break;
                case 3:
                    opcion = "Medicamento";
                    break;
                case 5:
                    opcion = "Vacunas";
                    break;
            }
            productoGenerar.insertarProductos(opcion, float.Parse(tbPrecio.Text), float.Parse(tbCantidad.Text));
        }
    }
}
