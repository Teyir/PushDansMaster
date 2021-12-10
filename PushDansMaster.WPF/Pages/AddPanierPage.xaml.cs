using Microsoft.Win32;
using PushDansMaster.DAL;
using PushDansMaster.WPF.Pages.CustomControl;
using System;
using System.Collections.Generic;
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
        public AddPanierPage()
        {
            InitializeComponent();
        }

        private void Rectangle_Drop(object sender, DragEventArgs e)
        {
            var reference = new List<string>();
            var quantite = new List<int>();
            var dt = DateTime.Now;

            var dppG = new PanierGlobalDepot_DAL();
            var dpadh = new AdherentDepot_DAL();
            var dpla = new LignesAdherentDepot_DAL();
            var dpreff = new ReferenceDepot_DAL();

            CultureInfo cultureInfo = new CultureInfo("fr-EU");
            System.Globalization.Calendar calendar = cultureInfo.Calendar;
            CalendarWeekRule myCWR = cultureInfo.DateTimeFormat.CalendarWeekRule;
            DayOfWeek myFirstDOW = cultureInfo.DateTimeFormat.FirstDayOfWeek;
            int week = calendar.GetWeekOfYear(dt, myCWR, myFirstDOW) - 1;

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                string fileName = System.IO.Path.GetFileName(files[0]);
                string fileExt = System.IO.Path.GetExtension(files[0]);
                string filePath = System.IO.Path.GetFullPath(files[0]);

                if (fileExt == ".csv")
                {
                    using (var rd = new StreamReader(filePath))
                    {
                        while (!rd.EndOfStream)
                        {
                            var splits = rd.ReadLine().Split(';');
                            if (splits[0] != "reference") { 
                                reference.Add(splits[0]);
                                quantite.Add(Int32.Parse(splits[1]));
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
                else
                {
                    MessageBox.Show("Veuillez déposer un fichier au format .csv", "Erreur");
                }
            }

            List<PanierGlobal_DAL> panierGlobal_DALs = new();
            panierGlobal_DALs = dppG.getAll();
            PanierGlobal_DAL pG;

            if (panierGlobal_DALs[panierGlobal_DALs.Count-1].getSemaine != week)
            {
                pG = new PanierGlobal_DAL(0, week);
                dppG.insert(pG);
            }
            else
            {
                pG = panierGlobal_DALs[panierGlobal_DALs.Count-1];
            }

            var adh = dpadh.getByID(int.Parse(txtBxAdh.Text));

            var padh = new PanierAdherent_DAL(false, week, adh.getID, pG.getID);
            var dppadh = new PanierAdherentDepot_DAL();
            dppadh.insert(padh);

            List<Reference_DAL> allRef = new();
            allRef = dpreff.getAll();
            int refID = 0;

            for (int i = 0; i < reference.Count; i++)
            {
                for (int y = 0; y < allRef.Count; y++)
                {
                    if (reference[i] == allRef[y].getReference)
                    {
                        refID = allRef[y].getID;
                    }
                    else
                    {
                        MessageBox.Show("La référence : " + reference[i] + " n'est pas répertoriée dans la BDD", "Erreur");
                    }
                }
                var ligneAdh = new LignesAdherent_DAL(quantite[i], refID, padh.getID);
                dpla.insert(ligneAdh);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog() { Multiselect = true };
            bool? response = openFileDialog.ShowDialog();
            if (response == true)
            {
                string[] files = openFileDialog.FileNames;
                string fileExt = System.IO.Path.GetExtension(files[0]);
                if (fileExt == ".csv")
                {
                    for (int i = 0; i < files.Length; i++)
                    {
                        string filename = System.IO.Path.GetFileName(files[i]);
                        FileInfo fileInfo = new FileInfo(files[i]);
                        UploadingFilesList.Items.Add(new fileDetail()
                        {
                            FileName = filename,
                            FileSize = string.Format("{0} {1}", (fileInfo.Length / (1024 * 1024)).ToString("0.0"), "Mb"),
                            UploadProgress = 100
                        });
                    }
                }
                else
                {
                    MessageBox.Show("Veuillez choisir un fichier au format .csv", "Erreur");
                }
            }
        }
    }
}
