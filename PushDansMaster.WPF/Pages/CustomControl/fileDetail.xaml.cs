using System.Windows;
using System.Windows.Controls;

namespace PushDansMaster.WPF.Pages.CustomControl
{
    /// <summary>
    /// Logique d'interaction pour fileDetail.xaml
    /// </summary>
    public partial class fileDetail : UserControl
    {
        public fileDetail()
        {
            InitializeComponent();
        }



        public string FileName
        {
            get => (string)GetValue(FileNameProperty);
            set => SetValue(FileNameProperty, value);
        }

        // Using a DependencyProperty as the backing store for FileName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FileNameProperty =
            DependencyProperty.Register("FileName", typeof(string), typeof(fileDetail));



        public string FileSize
        {
            get => (string)GetValue(FileSizeProperty);
            set => SetValue(FileSizeProperty, value);
        }

        // Using a DependencyProperty as the backing store for FileSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FileSizeProperty =
            DependencyProperty.Register("FileSize", typeof(string), typeof(fileDetail));




        public int UploadProgress
        {
            get => (int)GetValue(UploadProgressProperty);
            set => SetValue(UploadProgressProperty, value);
        }

        // Using a DependencyProperty as the backing store for UploadProgress.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UploadProgressProperty =
            DependencyProperty.Register("UploadProgress", typeof(int), typeof(fileDetail));



        public int UploadSpeed
        {
            get => (int)GetValue(UploadSpeedProperty);
            set => SetValue(UploadSpeedProperty, value);
        }

        // Using a DependencyProperty as the backing store for UploadSpeed.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UploadSpeedProperty =
            DependencyProperty.Register("UploadSpeed", typeof(int), typeof(fileDetail));



    }
}
