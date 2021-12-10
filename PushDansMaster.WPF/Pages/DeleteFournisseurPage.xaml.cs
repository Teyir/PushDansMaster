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
    public partial class DeleteFournisseurPage : Page
    {
        public DeleteFournisseurPage()
        {
            InitializeComponent();
        }

        private async void WindowIsOpen(object sender, RoutedEventArgs e)
        {
            var clientApi = new Client("https://localhost:44304/", new HttpClient());
            var fournisseur = await clientApi.Getall2Async();
            Liste.ItemsSource = fournisseur;
        }

        private void Click_Btn_Delete_Fournisseur(object sender, RoutedEventArgs e)
        {
            var clientApi = new Client("https://localhost:44304/", new HttpClient());
            int id = Int32.Parse(deleteInsertID.Text);
            clientApi.DeleteAsync(id);
            NavigationService.GoBack();
        }
    }
}
