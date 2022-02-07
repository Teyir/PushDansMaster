using Microsoft.Win32;
using PushDansMaster.DAL;
using PushDansMaster.WPF.Pages.CustomControl;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
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
            var cbItem = new ComboBoxItem { Content = "<--Select-->" };
            selectedAdh = cbItem;
            adh.Add(cbItem);

            var clientApi = new Client("https://localhost:44304", new HttpClient());
            var listAdh = await clientApi.GetallAsync();

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
            var clientApi = new Client("https://localhost:44304", new HttpClient());

            string fileExt = System.IO.Path.GetExtension(files[0]);
            string filePath = System.IO.Path.GetFullPath(files[0]);
            if (fileExt == ".csv")
            {
                var comboBox = sender as ComboBox;
                string adhStr = (string)(cbAdh.SelectedItem as ComboBoxItem).Content;

                if (adhStr != "<--Select-->")
                {
                    var references = new List<string>();
                    var quantites = new List<int>();
                    var dt = DateTime.Now;

                    var dppG = new PanierGlobalDepot_DAL();
                    var dppA = new PanierAdherentDepot_DAL();
                    var dpla = new LignesAdherentDepot_DAL();
                    var dplg = new LignesGlobalDepot_DAL();

                    CultureInfo cultureInfo = new CultureInfo("fr-EU");
                    System.Globalization.Calendar calendar = cultureInfo.Calendar;
                    CalendarWeekRule myCWR = cultureInfo.DateTimeFormat.CalendarWeekRule;
                    DayOfWeek myFirstDOW = cultureInfo.DateTimeFormat.FirstDayOfWeek;
                    int week = calendar.GetWeekOfYear(dt, myCWR, myFirstDOW) - 1;

                    var panierGlobals = await clientApi.Getall4Async();
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
                        PanierGlobal_DAL panierGlobal = new PanierGlobal_DAL(0, week);
                        PanierGlobal_DAL insertedPG = dppG.insert(panierGlobal);
                        IdPanierGlobal = insertedPG.getID;
                    }

                    int adhID = 0;
                    var panierAdherents = await clientApi.Getall3Async();

                    var AdhSelected = ((cbAdh as ComboBox).SelectedItem as Adherent_DTO);

                    if (adhStr != AdhSelected.SocieteAdherent || AdhSelected.SocieteAdherent == "")
                    {
                        var adhs = await clientApi.GetallAsync();
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
                            PanierAdherent_DAL PanierAdherent = new PanierAdherent_DAL(0, week, adhID, IdPanierGlobal);
                            PanierAdherent_DAL panier = dppA.insert(PanierAdherent);
                            IdPanierGlobal = panier.getID;
                        }
                    }
                    else
                    {
                        adhID = AdhSelected.IdAdherent;
                    }

                    using (var rd = new StreamReader(filePath))
                    {
                        while (!rd.EndOfStream)
                        {
                            var splits = rd.ReadLine().Split(';');
                            if (splits[0] != "reference")
                            {
                                references.Add(splits[0]);
                                quantites.Add(Int32.Parse(splits[1]));
                            }
                        }
                    }

                    /*var reference_DTOs = await clientApi.Getall5Async();
                    if (reference_DTOs.Count == 0)
                    {
                        MessageBox.Show("Aucune référence dans la BDD", "Erreur référence");
                    }
                    else
                    {
                        bool exit = false;
                        foreach (Reference_DTO reff in reference_DTOs)
                        {
                            foreach (String refStr in references)
                            {
                                int i = 0;
                                if (refStr != reff.Reference)
                                {
                                    // Message d'erreur
                                    MessageBox.Show("Référence : " + refStr + " pas présente dans la BDD, veuillez réessayer", "Erreur référence");
                                    exit = true;
                                    break;
                                }
                                else
                                {
                                    int refID = reff.ID;
                                    LignesAdherent_DAL lignesAdherent = new LignesAdherent_DAL(IdPanierAdherent, refID, quantites[i]);
                                    LignesGlobal_DAL lignesGlobal = new LignesGlobal_DAL(IdPanierGlobal, quantites[i], reff.Reference, refID);
                                    dpla.insert(lignesAdherent);
                                    dplg.insert(lignesGlobal);
                                }
                                i++;
                            }
                            if (exit == true) { break; }
                        }

                        if (!exit) { 
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
                    }*/
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
