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
    public partial class FournisseursPage : Page
    {
        public FournisseursPage()
        {
            InitializeComponent();

        }
        private async void WindowIsOpen(object sender, RoutedEventArgs e)
        {
            var clientApi = new Client("https://localhost:44304/", new HttpClient());
            var fournisseur = await clientApi.Getall2Async();
            Liste.ItemsSource = fournisseur;
        }

        private async void Click_Btn_Go_Delete_Fournisseur(object sender, RoutedEventArgs e)
        {           
            var clientApi = new Client("https://localhost:44304/", new HttpClient());
            var four = ((Liste as DataGrid).SelectedItem as Fournisseurs_DTO);

            if (four is null)
                MessageBox.Show("Selectionner un fournisseur");
            else {
               if (MessageBox.Show("êtes vous sur de vouloir supprimer le fournisseur " + four.NomFournisseur + "?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    await clientApi.DeleteAsync(four.IdFournisseur);

                    var fournisseurs = await clientApi.Getall2Async();
                    Liste.ItemsSource = null;
                    Liste.ItemsSource = fournisseurs;
                }
            }
        }


        private void Click_Btn_Go_Insert_Fournisseur(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Pages/InsertFournisseurPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Click_Btn_Go_Update_Fournisseur(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Pages/UpdateFournisseurPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private async void Click_Btn_Actualiser(object sender, RoutedEventArgs e)
        {
            var clientApi = new Client("https://localhost:44304/", new HttpClient());
            var fournisseur = await clientApi.Getall2Async();       
            Liste.ItemsSource = null;
            Liste.ItemsSource = fournisseur;
        }
    }
}
