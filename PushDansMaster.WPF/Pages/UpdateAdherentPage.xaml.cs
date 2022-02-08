using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace PushDansMaster.WPF.Pages
{
    public partial class UpdateAdherentPage : Page
    {
        public UpdateAdherentPage()
        {
            InitializeComponent();
        }

        private async void WindowIsOpen(object sender, RoutedEventArgs e)
        {
            var clientApi = new Client("https://localhost:44304/", new HttpClient());
            var adherent = await clientApi.GetallAsync();
            Liste.ItemsSource = adherent;
        }

        private void Click_Btn_Valider_Adherent(object sender, RoutedEventArgs e)
        {
            var adherent = new Adherent_DTO();
            var adhSelected = ((Liste as DataGrid).SelectedItem as Adherent_DTO);
            var clientApi = new Client("https://localhost:44304/", new HttpClient());
            if (adhSelected is null)
            {
                MessageBox.Show("Selectionner un adherent");
            }
            else
            {
                adherent.SocieteAdherent = SocieteUpdateAdherent.Text;
                adherent.NomAdherent = NomUpdateAdherent.Text;
                adherent.PrenomAdherent = PrenomUpdateAdherent.Text;
                adherent.EmailAdherent = EmailUpdateAdherent.Text;
                adherent.AdresseAdherent = AdresseUpdateAdherent.Text;
                adherent.StatusAdherent = int.Parse(StatusUpdateAdherent.Text);

                clientApi.UpdateAsync(adhSelected.IdAdherent, adherent);

                NavigationService.GoBack();
            }

        }
    }
}
