﻿using System;
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
            var clientApi = new Client("https://localhost:44304/", new HttpClient());

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

            int id = Int32.Parse(IdSelect.Text);
            clientApi.UpdateAsync(id, fournisseur);

            NavigationService.GoBack();

        }
    }
}
