using Microsoft.Win32;
using PushDansMaster.WPF.Pages.CustomControl;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;

namespace PushDansMaster.WPF.Pages
{
    /// <summary>
    /// Logique d'interaction pour AddPanierPage.xaml
    /// </summary>
    public partial class AddPanierPage : Page
    {
        public ObservableCollection<ComboBoxItem> adh { get; set; }
        public ComboBoxItem selectedAdh { get; set; }
        public string ComboBoxSelectedItem { get; set; }
        public int IdPanierGlobal { get; set; }
        public int IdPanierAdherent { get; set; }

        public AddPanierPage()
        {
            InitializeComponent();
        }

        private async void OnPageLoad(object sender, RoutedEventArgs e)
        {
            DataContext = this;

            adh = new ObservableCollection<ComboBoxItem>();
            ComboBoxItem cbItem = new ComboBoxItem { Content = "<--Select-->" };
            selectedAdh = cbItem;
            adh.Add(cbItem);

            Client clientApi = new Client("https://localhost:44304", new HttpClient());
            ICollection<Adherent_DTO> listAdh = await clientApi.GetallAsync();

            foreach (Adherent_DTO adhItem in listAdh)
            {
                adh.Add(new ComboBoxItem { Content = adhItem.SocieteAdherent });
            }
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
                ComboBox comboBox = sender as ComboBox;
                string adhStr = (string)(cbAdh.SelectedItem as ComboBoxItem).Content;

                if (adhStr != "<--Select-->")
                {
                    List<string> references = new List<string>();
                    List<int> quantites = new List<int>();
                    DateTime dt = DateTime.Now;

                    PanierGlobal_DTO pG = new PanierGlobal_DTO();
                    PanierAdherent_DTO pA = new PanierAdherent_DTO();
                    LigneAdherent_DTO la = new LigneAdherent_DTO();
                    LigneGlobal_DTO lg = new LigneGlobal_DTO();

                    CultureInfo cultureInfo = new CultureInfo("fr-EU");
                    System.Globalization.Calendar calendar = cultureInfo.Calendar;
                    CalendarWeekRule myCWR = cultureInfo.DateTimeFormat.CalendarWeekRule;
                    DayOfWeek myFirstDOW = cultureInfo.DateTimeFormat.FirstDayOfWeek;
                    int week = calendar.GetWeekOfYear(dt, myCWR, myFirstDOW) - 1;

                    ICollection<PanierGlobal_DTO> panierGlobals = await clientApi.Getall4Async();
                    bool panierFound = false;
                    foreach (PanierGlobal_DTO pg in panierGlobals)
                    {
                        if (pg.Semaine == week)
                        {
                            IdPanierGlobal = pg.Id;
                            panierFound = true;
                            break;
                        }
                    }
                    if (!panierFound)
                    {
                        pG.Status = 0;
                        pG.Semaine = week;
                        await clientApi.Insert6Async(pG);
                    }





                    int adhID = 0;
                    ICollection<PanierAdherent_DTO> panierAdherents = await clientApi.Getall3Async();

                    Adherent_DTO AdhSelected = (cbAdh.SelectedItem as Adherent_DTO);

                    ICollection<Adherent_DTO> adhs = await clientApi.GetallAsync();
                    foreach (Adherent_DTO item in adhs)
                    {
                        if (item.SocieteAdherent == adhStr)
                        {
                            adhID = item.IdAdherent;
                            AdhSelected = item;
                            break;
                        }
                    }
                    bool foundPanierAdh = false;
                    foreach (PanierAdherent_DTO padhd in panierAdherents)
                    {
                        if (padhd.Id_adherent == adhID)
                        {
                            foundPanierAdh = true;
                            IdPanierAdherent = padhd.Id;
                            break;
                        }
                    }
                    if (!foundPanierAdh)
                    {
                        ICollection<PanierGlobal_DTO> listPanierglob = await clientApi.Getall4Async();
                        int IDtmp = 0;
                        foreach (PanierGlobal_DTO item in listPanierglob)
                        {
                            if (item.Semaine == week)
                            {
                                IDtmp = item.Id;
                                break;
                            }
                        }
                        pA.Semaine = week;
                        pA.Status = 0;
                        pA.Id_panierGlobal = IDtmp;
                        pA.Id_adherent = AdhSelected.IdAdherent;
                        await clientApi.Insert5Async(pA);
                    }

                    using (StreamReader rd = new StreamReader(filePath))
                    {
                        while (!rd.EndOfStream)
                        {
                            string[] splits = rd.ReadLine().Split(';');
                            if (splits[0] != "reference")
                            {
                                references.Add(splits[0]);
                                quantites.Add(int.Parse(splits[1]));
                            }
                        }
                    }

                    ICollection<Reference_DTO> reference_DTOs = await clientApi.Getall5Async();
                    if (reference_DTOs.Count == 0)
                    {
                        MessageBox.Show("Aucune référence dans la BDD", "Erreur référence");
                    }
                    else
                    {
                        int v = 0;

                        foreach (Reference_DTO reff in reference_DTOs)
                        {
                            foreach (string refStr in references)
                            {
                                if (refStr == reff.Reference && v < quantites.Count)
                                {
                                    int refID = reff.Id;
                                    int idpatmp = 0;
                                    foreach (PanierAdherent_DTO item in panierAdherents)
                                    {
                                        if (item.Id_adherent == AdhSelected.IdAdherent)
                                        {
                                            idpatmp = item.Id;
                                        }
                                    }
                                    la.Quantite = quantites[v];
                                    la.Id_reference = refID;
                                    la.Id_panier = idpatmp;
                                    lg.Id_panier = IdPanierGlobal;
                                    lg.Quantite = quantites[v];
                                    lg.Reference = reff.Reference;
                                    lg.Id_reference = refID;
                                    await clientApi.Insert3Async(la);
                                    await clientApi.Insert4Async(lg);
                                    v++;
                                    break;
                                }
                            }
                        }
                        for (int i = 0; i < files.Length; i++)
                        {
                            string filename = System.IO.Path.GetFileName(files[i]);
                            FileInfo fileInfo = new FileInfo(files[i]);
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
                    MessageBox.Show("Veuillez choisir un Adherent", "Erreur adherent");
                }
            }
            else
            {
                MessageBox.Show("Veuillez déposer un fichier au format .csv", "Erreur fichier");
            }
        }
    }
}
