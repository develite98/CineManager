using ProjectVideo.ViewModel;
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
        public PlayVideoForm()
        {
            InitializeComponent();
        }

        void timer_tick(object sender, EventArgs e)
        {
            slider1.Value = MoviePlayer.Position.TotalSeconds;
           
        }
    

        public PlayVideoForm(string path, string fullName)
        {
            InitializeComponent();
            // handle parameters
            var playVideoVM = PlayVideoView.DataContext as PlayVideoViewModel;
            playVideoVM.UserCurrent = fullName;
            playVideoVM.PathVideo = path;
            // handle play video
            MoviePlayer.Source = new Uri(handlePathVideo(path), UriKind.Relative);
            MoviePlayer.Volume = (double)SliderVolumes.Value;
            MoviePlayer.Play();
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(timer_tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();

        }

        // handle path video
        private string handlePathVideo(string path)
        {
            string ap = System.IO.Path.GetFullPath(path);
            int s = ap.LastIndexOf("bin");
            string output = ap.Remove(s, 10);
            return output;
        }
        //----------------------------
        private void PlayBtn_Click(object sender, RoutedEventArgs e)
        {
            PauseBtn.Visibility = Visibility.Visible;
            PlayBtn.Visibility = Visibility.Collapsed;
            MoviePlayer.Play();
        }

        private void PauseBtn_Click(object sender, RoutedEventArgs e)
        {
            PlayBtn.Visibility = Visibility.Visible;
            PauseBtn.Visibility = Visibility.Collapsed;
            MoviePlayer.Pause();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Slider1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            TimeSpan ts = TimeSpan.FromSeconds(e.NewValue);
            MoviePlayer.Position = ts;

        }

        private void MoviePlayer_MediaOpened(object sender, RoutedEventArgs e)
        {
            if(MoviePlayer.NaturalDuration.HasTimeSpan)
            {
                TimeSpan ts = TimeSpan.FromMilliseconds(MoviePlayer.NaturalDuration.TimeSpan.TotalMilliseconds);
                slider1.Maximum = ts.TotalSeconds;
            }
        }

        private void SliderVolumes_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            MoviePlayer.Volume = (double)SliderVolumes.Value;
        }

        private void btnForward_Click(object sender, RoutedEventArgs e)
        {
            slider1.Value = slider1.Value + 40;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            slider1.Value = slider1.Value - 40;
        }

        private void ReplayButton_Click(object sender, RoutedEventArgs e)
        {
            MoviePlayer.Stop();
            MoviePlayer.Play();
            slider1.Value = 0;

        }

        private void Zoom_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Maximized;
            GridMain.Height = this.Height;
            MoviePlayer.Height = this.Height - 165;
            ZoomIn.Visibility = Visibility.Collapsed;
            ZoomOut.Visibility = Visibility.Visible;
        }

        private void ZoomOut_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Normal;
            MoviePlayer.Height = 500;

            ZoomIn.Visibility = Visibility.Visible;
            ZoomOut.Visibility = Visibility.Collapsed;
        }
    }
}
