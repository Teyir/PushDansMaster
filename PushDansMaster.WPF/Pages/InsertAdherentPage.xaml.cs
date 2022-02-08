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
    public partial class InsertAdherentPage : Page
    {
        public InsertAdherentPage()
        {
            InitializeComponent();
        }

        private void Click_Btn_Valider_Adherent(object sender, RoutedEventArgs e)
        {
            var adherent = new Adherent_DTO();
            var clientApi = new Client("https://localhost:44304/", new HttpClient());

            adherent.SocieteAdherent = SocieteInsertAdherent.Text;

            adherent.NomAdherent = NomInsertAdherent.Text;
            adherent.PrenomAdherent = PrenomInsertAdherent.Text;
            adherent.EmailAdherent = EmailInsertAdherent.Text;
            adherent.AdresseAdherent = AdresseInsertAdherent.Text;
            adherent.StatusAdherent = int.Parse(StatusInsertAdherent.Text);

            clientApi.InsertAsync(adherent);

            NavigationService.GoBack();

        }

    }
}
