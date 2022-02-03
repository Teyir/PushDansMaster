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
    public partial class InsertFournisseurPage : Page
    {
        public InsertFournisseurPage()
        {
            InitializeComponent();
        }

        private void Click_Btn_Valider_Fournisseur(object sender, RoutedEventArgs e)
        {
            var fournisseur = new Fournisseurs_DTO();
            var clientApi = new Client("https://localhost:44304/", new HttpClient());

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

            clientApi.InsertAsync(fournisseur);

            NavigationService.GoBack();

        }

    }
}
