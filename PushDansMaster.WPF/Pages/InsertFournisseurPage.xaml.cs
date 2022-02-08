using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace PushDansMaster.WPF.Pages
{
    public partial class InsertFournisseurPage : Page
    {
        public InsertFournisseurPage()
        {
            InitializeComponent();
        }

        private void Click_Btn_Valider_Fournisseur(object sender, RoutedEventArgs e)
        {
            Fournisseurs_DTO fournisseur = new Fournisseurs_DTO();
            Client clientApi = new Client(new configAPI().getConfig(), new HttpClient());

            fournisseur.SocieteFournisseur = SocieteInsert.Text;
            if ((bool)radio1.IsChecked)
            {
                fournisseur.CiviliteFournisseur = true;
            }
            else if ((bool)radio2.IsChecked)
            {
                fournisseur.CiviliteFournisseur = false;
            }
            fournisseur.NomFournisseur = NomInsert.Text;
            fournisseur.PrenomFournisseur = PrenomInsert.Text;
            fournisseur.EmailFournisseur = EmailInsert.Text;
            fournisseur.AdresseFournisseur = AdresseInsert.Text;
            fournisseur.StatusFournisseur = int.Parse(StatusInsert.Text);

            clientApi.Insert2Async(fournisseur);

            NavigationService.GoBack();

        }

    }
}
