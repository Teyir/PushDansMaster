using Microsoft.Win32;
using PushDansMaster.DAL;
using PushDansMaster.WPF.Pages.CustomControl;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
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
        public PanierGlobal_DAL PanierGlobal { get; set; }
        public Adherent_DAL AdhSelected { get; set; }
        private PanierAdherent_DAL PanierAdherent { get; set; }

        public AddPanierPage()
        {
            InitializeComponent();

            DataContext = this;

            AdhSelected = new Adherent_DAL("", "", "", "", "", DateTime.Now, 0);

            adh = new ObservableCollection<ComboBoxItem>();
            var cbItem = new ComboBoxItem { Content = "<--Select-->" };
            selectedAdh = cbItem;
            adh.Add(cbItem);

            AdherentDepot_DAL dpadh = new AdherentDepot_DAL();
            List<Adherent_DAL> listAdh = dpadh.getAll();

            foreach (Adherent_DAL adhItem in listAdh)
            {
                adh.Add(new ComboBoxItem { Content = adhItem.getSocieteAdherent });
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

        private void Processing(object sender, RoutedEventArgs e, string[] files)
        {
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
                    var dpadh = new AdherentDepot_DAL();
                    var dpla = new LignesAdherentDepot_DAL();
                    var dplg = new LignesGlobalDepot_DAL();
                    var dpref = new ReferenceDepot_DAL();

                    CultureInfo cultureInfo = new CultureInfo("fr-EU");
                    System.Globalization.Calendar calendar = cultureInfo.Calendar;
                    CalendarWeekRule myCWR = cultureInfo.DateTimeFormat.CalendarWeekRule;
                    DayOfWeek myFirstDOW = cultureInfo.DateTimeFormat.FirstDayOfWeek;
                    int week = calendar.GetWeekOfYear(dt, myCWR, myFirstDOW) - 1;

                    List<PanierGlobal_DAL> panierGlobals = dppG.getAll();
                    bool panierFound = false;
                    foreach (PanierGlobal_DAL pg in panierGlobals)
                    {
                        if (pg.getSemaine == week)
                        {
                            PanierGlobal = pg;
                            panierFound = true;
                        }
                    }
                    if (!panierFound)
                    {
                        PanierGlobal_DAL panierGlobal = new PanierGlobal_DAL(0, week);
                        PanierGlobal_DAL pGID = dppG.insert(panierGlobal);
                        PanierGlobal = pGID;
                    }

                    int adhID = 0;
                    List<PanierAdherent_DAL> panierAdherents = dppA.getAll();
                    if (adhStr != AdhSelected.getSocieteAdherent || AdhSelected.getSocieteAdherent == "")
                    {
                        List<Adherent_DAL> adhs = dpadh.getAll();
                        foreach (Adherent_DAL item in adhs)
                        {
                            if (item.getSocieteAdherent == adhStr)
                            {
                                adhID = item.getIdAdherent;
                                AdhSelected = item;
                                break;
                            }
                        }
                        bool foundPanierAdh = false;
                        foreach (PanierAdherent_DAL padhd in panierAdherents)
                        {
                            if (padhd.getId_adherent == adhID)
                            {
                                PanierAdherent = padhd;
                                foundPanierAdh = true;
                                break;
                            }
                        }
                        if (!foundPanierAdh)
                        {
                            PanierAdherent = new PanierAdherent_DAL(0, week, adhID, PanierGlobal.getID);
                            dppA.insert(PanierAdherent);
                        }
                    }
                    else
                    {
                        adhID = AdhSelected.getIdAdherent;
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

                    List<Reference_DAL> reference_DALs = dpref.getAll();
                    if (reference_DALs.Count == 0)
                    {
                        MessageBox.Show("Aucune référence dans la BDD", "Erreur référence");
                    }
                    else
                    {
                        bool exit = false;
                        foreach (Reference_DAL reff in reference_DALs)
                        {
                            foreach (String refStr in references)
                            {
                                int i = 0;
                                if (refStr != reff.getReference)
                                {
                                    // Message d'erreur
                                    MessageBox.Show("Référence : " + refStr + " pas présente dans la BDD, veuillez réessayer", "Erreur référence");
                                    exit = true;
                                    break;
                                }
                                else
                                {
                                    int refID = reff.getID;
                                    LignesAdherent_DAL lignesAdherent = new LignesAdherent_DAL(PanierAdherent.getID, refID, quantites[i]);
                                    LignesGlobal_DAL lignesGlobal = new LignesGlobal_DAL(PanierGlobal.getID, quantites[i], reff.getReference, refID);
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
