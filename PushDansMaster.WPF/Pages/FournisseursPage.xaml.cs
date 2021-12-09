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

        private async void Click_Btn_ADD_FournisseurAsync(object sender,RoutedEventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync("https://localhost:44304/api/Fournisseurs/insert");
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    message.Text = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    message.Text = $"Server error code {response.StatusCode}";
                }

            }
        }

        private async void Click_Btn_GetALL_FournisseurAsync(object sender, RoutedEventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync("https://localhost:44304/api/Fournisseurs/getall");
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    message.Text = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    message.Text = $"Server error code {response.StatusCode}";
                }

            }
        }

        private void Click_Btn_Delete_Fournisseur(object sender, RoutedEventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                 client.DeleteAsync("https://localhost:44304/api/Fournisseurs/delete/"+ deleteInsertID.Text);
            }

        }


    }
}
