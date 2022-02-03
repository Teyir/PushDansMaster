using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace PushDansMaster.WPF.Pages
{
    public partial class AdherentPage : Page
    {
        public AdherentPage()
        {
            InitializeComponent();
        }

        private async void WindowIsOpen(object sender, RoutedEventArgs e)
        {
            var clientApi = new Client("https://localhost:44304/", new HttpClient());
            var adherent = await clientApi.GetallAsync();
            Liste.ItemsSource = adherent;
        }

        private async void Click_Btn_Actualiser(object sender, RoutedEventArgs e)
        {
            var clientApi = new Client("https://localhost:44304/", new HttpClient());
            var adherent = await clientApi.GetallAsync();

            Liste.ItemsSource = null;
            Liste.ItemsSource = adherent;
        }
    }
}
