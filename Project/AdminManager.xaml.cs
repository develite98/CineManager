using ProjectVideo.Models;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for AdminManager.xaml
    /// </summary>
    public partial class AdminManager : UserControl
    {
        public AdminManager()
        {

            InitializeComponent();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var row = dgV.SelectedItem as Video;
                string nameVideo = row.videoName;
                var videoDel = DataProvider.Ins.DB.Videos.FirstOrDefault(vd => vd.videoName == nameVideo);
                DataProvider.Ins.DB.Videos.Remove(videoDel);
                DataProvider.Ins.DB.SaveChanges();
                MessageBox.Show("Delete video success!", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch(Exception ex) { }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var row = dgV.SelectedItem as Video;
                string nameVideo = row.videoName;
                string id = row.ID.ToString();
                string cate = row.videoKind.ToString();
                string des = row.describe;
                UpdateVideoAdmin updateVideo = new UpdateVideoAdmin(id, nameVideo, cate, des);
                updateVideo.ShowDialog();
            }
            catch(Exception ex) { }
        }

        private void btnDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var btnClick = sender as Button;
                int.TryParse(btnClick.Tag.ToString(), out int idUser);
                var user = DataProvider.Ins.DB.Users.FirstOrDefault(us => us.ID == idUser);
                DataProvider.Ins.DB.Users.Remove(user);
                DataProvider.Ins.DB.SaveChanges();
                MessageBox.Show("Block user success!", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex) { }
            
        }
    }
}
