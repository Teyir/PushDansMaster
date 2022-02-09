using System;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

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
            Client clientApi = new Client(new configAPI().getConfig(), new HttpClient());
            System.Collections.Generic.ICollection<Fournisseurs_DTO> fournisseur = await clientApi.Getall2Async();
            Liste.ItemsSource = fournisseur;
        }

        private async void OnPageLoad(object sender, RoutedEventArgs e)
        {
            Client clientApi = new Client(new configAPI().getConfig(), new HttpClient());
            System.Collections.Generic.ICollection<Fournisseurs_DTO> fournisseur = await clientApi.Getall2Async();
            Liste.ItemsSource = fournisseur;
        }

        private async void Click_Btn_Go_Delete_Fournisseur(object sender, RoutedEventArgs e)
        {
            Client clientApi = new Client(new configAPI().getConfig(), new HttpClient());
            Fournisseurs_DTO four = (Liste.SelectedItem as Fournisseurs_DTO);

            if (four is null)
            {
                MessageBox.Show("Selectionner un fournisseur");
            }
            else
            {
                if (MessageBox.Show("êtes vous sur de vouloir supprimer le fournisseur " + four.NomFournisseur + "?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    await clientApi.Delete2Async(four.IdFournisseur);

                    System.Collections.Generic.ICollection<Fournisseurs_DTO> fournisseurs = await clientApi.Getall2Async();
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
            Client clientApi = new Client(new configAPI().getConfig(), new HttpClient());
            System.Collections.Generic.ICollection<Fournisseurs_DTO> fournisseur = await clientApi.Getall2Async();
            Liste.ItemsSource = null;
            Liste.ItemsSource = fournisseur;
        }
    }
}
