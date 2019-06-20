using ProjectVideo.Models;
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
    /// Interaction logic for MyplayList.xaml
    /// </summary>
    public partial class MyPlayList : UserControl
    {
        private string userCurrent;
        public MyPlayList()
        {
            InitializeComponent();
        }
        public MyPlayList(string userCurrent)
        {
            InitializeComponent();
            this.userCurrent = userCurrent;
            var myPlayListVM = MyPlayListView.DataContext as MyPlayListViewModel;
            myPlayListVM.UserCurrent = userCurrent;
        }

        private void BtnPlay_Click(object sender, RoutedEventArgs e)
        {
            string pathVideo = "";
            var btnClick = (sender) as Button;
            foreach (var textblock in FindVisualChildren<TextBlock>(this))
            {
                if (textblock.Name == "tbVideoPath")
                {
                    if (textblock.Tag.ToString() == btnClick.Tag.ToString()) // compare index of pathvideo and index button when click (get path of video when click button)
                    {
                        pathVideo = textblock.Text;
                        break;
                    }
                }
            }
            PlayVideoForm pvf = new PlayVideoForm(pathVideo, userCurrent);
            pvf.ShowDialog();
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

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var btnClick = sender as Button;
            int.TryParse(btnClick.Tag.ToString(), out int idVideoTag);
            var myPlayList = MyPlayListView.DataContext as MyPlayListViewModel;
            var user = DataProvider.Ins.DB.Users.FirstOrDefault(us => us.userName == myPlayList.UserCurrent);
            var playListVideo = DataProvider.Ins.DB.PlayLists.Where(pl => pl.idUser == user.ID);

            foreach(var video in playListVideo)
            {
                var videoDel = DataProvider.Ins.DB.PlayLists.Where(pl => pl.idVideo == idVideoTag).SingleOrDefault();
                DataProvider.Ins.DB.PlayLists.Remove(videoDel);
            }
            DataProvider.Ins.DB.SaveChanges();
            MessageBox.Show("Delete video from my playlist success(refresh page to see the result)!", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
