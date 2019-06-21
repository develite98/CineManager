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
    /// Interaction logic for UpdateVideoAdmin.xaml
    /// </summary>
    public partial class UpdateVideoAdmin : Window
    {
        public UpdateVideoAdmin()
        {
            InitializeComponent();
        }

        public UpdateVideoAdmin(string id, string nameVideo, string cate, string describe)
        {
            InitializeComponent();
            var videoUpdate = UpdateVideoView.DataContext as UpdateVideoViewModel;
            videoUpdate.ID = id;

            txtNameVideo.Text = nameVideo;
            txtCategory.Text = cate;
            txtDescribe.Text = describe;
        }
    }
}
