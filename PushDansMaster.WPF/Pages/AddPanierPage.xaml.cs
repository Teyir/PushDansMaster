using Microsoft.Win32;
using PushDansMaster.WPF.Pages.CustomControl;
using System;
using System.Collections.Generic;
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

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog() { Multiselect = true };
            bool? response = openFileDialog.ShowDialog();
            if (response == true)
            {
                string[] files = openFileDialog.FileNames;

                for (int i = 0; i < files.Length; i++)
                {
                    string filename = System.IO.Path.GetFileName(files[i]);
                    FileInfo fileInfo = new FileInfo(files[i]);
                    UploadingFilesList.Items.Add(new fileDetail() {
                        FileName = filename,
                        // ici on convertit la taille des fichiers de bits vers MB
                        FileSize = string.Format("{0} {1}", (fileInfo.Length / (1024*1024)).ToString("0.0"), "Mb"),
                        UploadProgress = 100
                    });
                }
            }
        }
    }
}
