﻿using ProjectVideo.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjectVideo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Height = System.Windows.SystemParameters.WorkArea.Height;
            this.Width = System.Windows.SystemParameters.WorkArea.Width;
            GridMain.Width = System.Windows.SystemParameters.WorkArea.Width;
            lvFilm.Height = this.Height - 127;
        }

        public MainWindow(string FullName, string UserName)
        {
            InitializeComponent();
            this.Height = System.Windows.SystemParameters.WorkArea.Height;
            this.Width = System.Windows.SystemParameters.WorkArea.Width;
            GridMain.Width = System.Windows.SystemParameters.WorkArea.Width;
            if (UserName != null)
            {
                GuesInfo.Visibility = Visibility.Collapsed;
                if (FullName != "Admin") // user
                {        
                    userInfoTool.Visibility = Visibility.Visible;
                    UserInfo.Visibility = Visibility.Visible;
                    adminInfoTool.Visibility = Visibility.Collapsed;
                    AdminInfo.Visibility = Visibility.Collapsed;
                    btnRefresh.Visibility = Visibility.Visible;
                    txtFullName.Text = FullName;
                    txtUserName.Text = UserName;
                    MyPlayList mp = new MyPlayList(txtUserName.Text);
                }
                else // admin
                {
                    adminInfoTool.Visibility = Visibility.Visible;
                    AdminInfo.Visibility = Visibility.Visible;
                    userInfoTool.Visibility = Visibility.Collapsed;
                    UserInfo.Visibility = Visibility.Collapsed;
                    btnRefresh.Visibility = Visibility.Visible;
                    txtFullName.Text = FullName;
                    txtUserName.Text = UserName;
                }
            }
            lvFilm.Height = this.Height - 127;
        }
        private void BtnOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            btnOpenMenu.Visibility = Visibility.Collapsed;
            btnCloseMenu.Visibility = Visibility.Visible;
        }

        private void BtnCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            btnOpenMenu.Visibility = Visibility.Visible;
            btnCloseMenu.Visibility = Visibility.Collapsed;
        }


        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            lvFilm.ScrollIntoView(lvFilm.Items[0]);
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            lvFilm.ScrollIntoView(lvFilm.Items[1]);
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            lvFilm.ScrollIntoView(lvFilm.Items[2]);
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            lvFilm.ScrollIntoView(lvFilm.Items[3]);
        }


        public IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);

                    if (child != null && child is T)
                        yield return (T)child;

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                        yield return childOfChild;
                }
            }
        }

        private void BtnPlay_Click(object sender, RoutedEventArgs e)
        {
            // check logged in
            if ((!string.IsNullOrEmpty(txtUserName.Text) && !string.IsNullOrEmpty(txtFullName.Text)))
            {
                // handle click video move to form play film
                string pathVideo = "";
                var btnClick = (sender) as Button;
                foreach (var textblock in FindVisualChildren<TextBlock>(this))
                {
                    if (textblock.Name == "tbVideoPath")
                    {
                        if (textblock.Tag.ToString() == btnClick.Tag.ToString()) // search textblock contain ID film and compare with btnClick contain ID film
                        {                                                       // it mean is got the film is pressed
                            pathVideo = textblock.Text;
                            break;
                        }
                    }
                }
                trailerFilm.Stop();
                PlayVideoForm pvf = new PlayVideoForm(pathVideo, txtUserName.Text);
                pvf.ShowDialog();
            }
            else
            {
                MessageBox.Show("Must be login to continue!", "Suggestions", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BtnEditInfo_Click(object sender, RoutedEventArgs e)
        {
            UserInfo usf = new UserInfo(txtUserName.Text);
            usf.ShowDialog();
        }

        private void AminTool_Click(object sender, RoutedEventArgs e)
        {
            adminView.Visibility = Visibility.Visible;
            filmViewALL.Visibility = Visibility.Collapsed;
        }

        private void btnMyPlayList_Click(object sender, RoutedEventArgs e)
        {
            //MyPlayList mp = new MyPlayList();
            //mp.Show();
            //filmViewALL.Visibility = Visibility.Collapsed;
            //filmViewMy.Visibility = Visibility.Visible;

        }

        private void ShowINFOBTN_Click(object sender, RoutedEventArgs e)
        {
            string trailerPath = "";
            string pathVideo = "";
            string posterVideo = "";
            string nameVideo = "";
            string desVideo = "";
            var btnClick = (sender) as Button;
            foreach (var textblock in FindVisualChildren<TextBlock>(this))
            {
                if (textblock.Name == "tbVideoPoster")
                {
                    if (textblock.Tag.ToString() == btnClick.Tag.ToString())
                    {
                        posterVideo = textblock.Text;
                        break;
                    }
                }
            }
            foreach (var textblock in FindVisualChildren<TextBlock>(this))
            {
                if (textblock.Name == "tbVideoDes")
                {
                    if (textblock.Tag.ToString() == btnClick.Tag.ToString())
                    {
                        desVideo = textblock.Text;
                        break;
                    }
                }
            }
            foreach (var textblock in FindVisualChildren<TextBlock>(this))
            {
                if (textblock.Name == "tbVideoName")
                {
                    if (textblock.Tag.ToString() == btnClick.Tag.ToString())
                    {
                        nameVideo = textblock.Text;
                        break;
                    }
                }


            }
            foreach (var textblock in FindVisualChildren<TextBlock>(this))
            {
                if (textblock.Name == "tbTrailerPath")
                {
                    if (textblock.Tag.ToString() == btnClick.Tag.ToString())
                    {
                        trailerPath = textblock.Text;
                        break;
                    }
                }
            }
            foreach (var textblock in FindVisualChildren<TextBlock>(this))
            {
                if (textblock.Name == "tbVideoPath")
                {
                    if (textblock.Tag.ToString() == btnClick.Tag.ToString())
                    {
                        pathVideo = textblock.Text;
                        break;
                    }
                }
            }
            trailerFilm.Stop();
            playVideo.Tag = btnClick.Tag.ToString();
            trailerFilm.Source = new Uri(handlePathVideo(trailerPath), UriKind.Relative);
            txtNameFilm.Text = nameVideo;
            txtInfoFilm.Text = desVideo;
            INFOSHOW.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            trailerFilm.Play();
        }

        private void INFOSHOW_Click(object sender, RoutedEventArgs e)
        {
            GridFilm.Opacity = 0.5;
            GridFilm.IsEnabled = false;
        }

        private void BtnBackHome_Click(object sender, RoutedEventArgs e)
        {
            trailerFilm.Stop();
            GridFilm.Opacity = 1;
            GridFilm.IsEnabled = true;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void BackHome_Click(object sender, RoutedEventArgs e)
        {
            charVIEW.Visibility = Visibility.Collapsed;
            adminView.Visibility = Visibility.Collapsed;
            filmViewALL.Visibility = Visibility.Visible;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            //if(filmViewALL.Visibility == Visibility.Visible)
            //{
            //    btnBack.IsEnabled = false;
            //}
            charVIEW.Visibility = Visibility.Collapsed;
            filmViewMy.Visibility = Visibility.Collapsed;
            adminView.Visibility = Visibility.Collapsed;
            filmViewALL.Visibility = Visibility.Visible;
        }

        private void BtnAdmintool_Click(object sender, RoutedEventArgs e)
        {
            charVIEW.Visibility = Visibility.Collapsed;
            adminView.Visibility = Visibility.Visible;
            filmViewALL.Visibility = Visibility.Collapsed;
        }

        private void BtnMyPlaylist_Click_1(object sender, RoutedEventArgs e)
        {
            //MyPlayList mp = new MyPlayList(txtUserName.Text);
            filmViewMy.Visibility = Visibility.Visible;
            filmViewALL.Visibility = Visibility.Collapsed;
        }

        private void BtnTCam_MouseEnter(object sender, MouseEventArgs e)
        {
            lvFilm.ScrollIntoView(lvFilm.Items[0]);
        }

        private void BtnHDong_MouseEnter(object sender, MouseEventArgs e)
        {
            lvFilm.ScrollIntoView(lvFilm.Items[2]);
        }

        private void BtnVTuong_MouseEnter(object sender, MouseEventArgs e)
        {
            lvFilm.ScrollIntoView(lvFilm.Items[3]);
        }

        private void BtnPLuu_MouseEnter(object sender, MouseEventArgs e)
        {
            lvFilm.ScrollIntoView(lvFilm.Items[4]);
        }

        private void BtnANhac_MouseEnter(object sender, MouseEventArgs e)
        {
            lvFilm.ScrollIntoView(lvFilm.Items[5]);
        }

        private void BtnHHuoc_MouseEnter(object sender, MouseEventArgs e)
        {
            lvFilm.ScrollIntoView(lvFilm.Items[6]);
        }

        private void BtnLSu_MouseEnter(object sender, MouseEventArgs e)
        {
            lvFilm.ScrollIntoView(lvFilm.Items[7]);
        }

        private void BtnHHinh_MouseEnter(object sender, MouseEventArgs e)
        {
            lvFilm.ScrollIntoView(lvFilm.Items[8]);
        }

        private void BtnKDi_MouseEnter(object sender, MouseEventArgs e)
        {
            lvFilm.ScrollIntoView(lvFilm.Items[9]);

        }

        private void BtnTThoai_MouseEnter(object sender, MouseEventArgs e)
        {
            lvFilm.ScrollIntoView(lvFilm.Items[10]);
        }

        private void BtnHSu_MouseEnter(object sender, MouseEventArgs e)
        {
            lvFilm.ScrollIntoView(lvFilm.Items[11]);
        }

        private void BtnHBi_MouseEnter(object sender, MouseEventArgs e)
        {
            lvFilm.ScrollIntoView(lvFilm.Items[11]);
        }


        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            var user = DataProvider.Ins.DB.Users.FirstOrDefault(us => us.userName == txtUserName.Text);
            MainWindow mwd = new MainWindow(user.Name, txtUserName.Text);
            MainViewWindow.Close();
            mwd.ShowDialog();


        }
        private string handlePathVideo(string path)
        {
            string output = "";
            try
            {
                string ap = System.IO.Path.GetFullPath(path);
                int s = ap.LastIndexOf("bin");
                output = ap.Remove(s, 10);
            }
            catch (Exception ex)
            {

            }
            return output;
        }

        private void ChartTool_Click(object sender, RoutedEventArgs e)
        {
            adminView.Visibility = Visibility.Collapsed;
            charVIEW.Visibility = Visibility.Visible;
            filmViewALL.Visibility = Visibility.Collapsed;
        }
    }

    
}
