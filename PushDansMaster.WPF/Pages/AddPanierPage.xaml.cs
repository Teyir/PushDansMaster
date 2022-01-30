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

        public AddPanierPage()
        {
            InitializeComponent();

            DataContext = this;

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
