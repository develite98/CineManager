using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace ProjectVideo
{
    /// <summary>
    /// Interaction logic for PlayVideoForm.xaml
    /// </summary>
    public partial class PlayVideoForm : Window
    {
        string pathVideo;
        public PlayVideoForm()
        {
            InitializeComponent();
        }

        public PlayVideoForm(string path)
        {
            InitializeComponent();
            this.pathVideo = path;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PauseBtn.Visibility = Visibility.Visible;
            PlayBtn.Visibility = Visibility.Collapsed;
            MoviePlayer.FileName = ""/*"/Video/tinhcam/[Phim Ngắn] NOEL ĐẦU TIÊN - FU PRODUCTION.mp4"* OR pathVideo fix đường dẫn chổ này*/;
            MoviePlayer.Play();
        }

        private void PauseBtn_Click(object sender, RoutedEventArgs e)
        {
            PlayBtn.Visibility = Visibility.Visible;
            PauseBtn.Visibility = Visibility.Collapsed;
            MoviePlayer.Stop();
        }
    }
}
