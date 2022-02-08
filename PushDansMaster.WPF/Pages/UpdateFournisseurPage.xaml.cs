using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace PushDansMaster.WPF.Pages
{
    public partial class UpdateFournisseurPage : Page
    {
        public UpdateFournisseurPage()
        {
            InitializeComponent();
        }

        private async void WindowIsOpen(object sender, RoutedEventArgs e)
        {
            var clientApi = new Client("https://localhost:44304/", new HttpClient());
            var fournisseur = await clientApi.Getall2Async();
            Liste.ItemsSource = fournisseur;
        }

        private void Click_Btn_Valider_Fournisseur(object sender, RoutedEventArgs e)
        {
            var fournisseur = new Fournisseurs_DTO();
            var fourSelected = ((Liste as DataGrid).SelectedItem as Fournisseurs_DTO);
            var clientApi = new Client("https://localhost:44304/", new HttpClient());
            if (fourSelected is null)
            {
                MessageBox.Show("Selectionner un fournisseur");
            }
            else
            {
                fournisseur.SocieteFournisseur = SocieteUpdate.Text;
                if ((bool)radio1.IsChecked)
                {
                    fournisseur.CiviliteFournisseur = true;
                }
                else if ((bool)radio2.IsChecked)
                {
                    fournisseur.CiviliteFournisseur = false;
                }
                fournisseur.NomFournisseur = NomUpdate.Text;
                fournisseur.PrenomFournisseur = PrenomUpdate.Text;
                fournisseur.EmailFournisseur = EmailUpdate.Text;
                fournisseur.AdresseFournisseur = AdresseUpdate.Text;
                fournisseur.StatusFournisseur = int.Parse(StatusUpdate.Text);

                clientApi.Update2Async(fourSelected.IdFournisseur, fournisseur);

                NavigationService.GoBack();
            }

        }
    }
}
