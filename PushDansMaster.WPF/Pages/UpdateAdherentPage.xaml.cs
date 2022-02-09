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
            Client clientApi = new Client(new configAPI().getConfig(), new HttpClient());
            System.Collections.Generic.ICollection<Adherent_DTO> adherent = await clientApi.GetallAsync();
            Liste.ItemsSource = adherent;
        }

        private void Click_Btn_Valider_Adherent(object sender, RoutedEventArgs e)
        {
            Adherent_DTO adherent = new Adherent_DTO();
            Adherent_DTO adhSelected = (Liste.SelectedItem as Adherent_DTO);
            Client clientApi = new Client(new configAPI().getConfig(), new HttpClient());
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
