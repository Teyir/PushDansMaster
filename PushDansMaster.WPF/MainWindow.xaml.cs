﻿using System;
using System.Windows;
using System.Windows.Input;

namespace PushDansMaster.WPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PagesNavigation.Navigate(new System.Uri("Pages/HomePage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void DragWithHeader(object sender, MouseButtonEventArgs drag)
        {
            if (drag.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        private void btnRestore_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
            {
                WindowState = WindowState.Maximized;
            }
            else
            {
                WindowState = WindowState.Normal;
            }
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void rdHome_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("Pages/HomePage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void rdFournisseur_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("Pages/FournisseursPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void rdReference_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("Pages/AddRefPage.xaml", UriKind.RelativeOrAbsolute));
        }
        private void rdAdherent_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("Pages/AdherentPage.xaml", UriKind.RelativeOrAbsolute));
        }
        private void rdAddPanier_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("Pages/AddPanierPage.xaml", UriKind.RelativeOrAbsolute));
        }
        private void rdSendPanier_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("Pages/SendPanierPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void gridgrid_DragEnter(object sender, DragEventArgs e)
        {

        }
    }
}