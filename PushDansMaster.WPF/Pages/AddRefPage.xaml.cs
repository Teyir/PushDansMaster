using Microsoft.Win32;
using PushDansMaster.WPF.Pages.CustomControl;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;

namespace PushDansMaster.WPF.Pages
{
    /// <summary>
    /// Logique d'interaction pour AddPanierPage.xaml
    /// </summary>
    public partial class AddRefPage : Page
    {
        public AddRefPage()
        {
            InitializeComponent();
        }

        private void Rectangle_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                Processing(sender, e, files);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog() { Multiselect = true };
            bool? response = openFileDialog.ShowDialog();
            if (response == true)
            {
                string[] files = openFileDialog.FileNames;
                Processing(sender, e, files);
            }
        }

        private async void Processing(object sender, RoutedEventArgs e, string[] files)
        {
            Client clientApi = new Client("https://localhost:44304", new HttpClient());

            string fileExt = System.IO.Path.GetExtension(files[0]);
            string filePath = System.IO.Path.GetFullPath(files[0]);
            if (fileExt == ".csv")
            {
                List<string> reference = new List<string>();
                List<string> libelle = new List<string>();
                List<string> marque = new List<string>();
                int i = 0;
                using (StreamReader rd = new StreamReader(filePath))
                {
                    while (!rd.EndOfStream)
                    {
                        string[] splits = rd.ReadLine().Split(';');
                        if (splits[0] != "reference")
                        {
                            reference.Add(splits[0]);
                            libelle.Add(splits[1]);
                            marque.Add(splits[2]);
                        }
                    }
                    foreach (string reff in reference)
                    {
                        Reference_DTO refDTO = new Reference_DTO
                        {
                            Reference = reff,
                            Libelle = libelle[i],
                            Marque = marque[i],
                            Quantite = 9999999
                        };
                        await clientApi.Insert7Async(refDTO);
                        i++;
                    }
                    for (int j = 0; j < files.Length; j++)
                    {
                        string filename = System.IO.Path.GetFileName(files[j]);
                        FileInfo fileInfo = new FileInfo(files[j]);
                        UploadingFilesList.Items.Add(new fileDetail()
                        {
                            FileName = filename,
                            // ici on convertit la taille des fichiers de bits vers MB, la formule est bonne mais je sais pas pourquoi c'est pas bon pour résultat affiché dans le client ^^'
                            FileSize = string.Format("{0} {1}", (fileInfo.Length / 1.049e+6).ToString("0.0"), "Mb"),
                            UploadProgress = 100
                        });
                    }
                }
            }
            else
            {
                MessageBox.Show("Veuillez déposer un fichier au format .csv", "Erreur fichier");
            }
        }
    }
}
