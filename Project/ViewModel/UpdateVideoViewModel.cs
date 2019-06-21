using ProjectVideo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ProjectVideo.ViewModel
{
    class UpdateVideoViewModel:BaseViewModel
    {
        public string ID { get; set; }
        private string nameVideo;
        private string category;
        private string describe;

        public string NameVideo { get { return nameVideo; } set { nameVideo = value; OnPropertyChanged(); } }
        public string Category { get { return category; } set { category = value; OnPropertyChanged(); } }
        public string Describe { get { return describe; } set { describe = value; OnPropertyChanged(); } }

        public ICommand LoadedWindowCommand { get; set; }
        public ICommand ConfirmCommand { get; set; }

        public UpdateVideoViewModel()
        {
            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                int.TryParse(ID, out int idVideo);
                // init video current
                var video = DataProvider.Ins.DB.Videos.FirstOrDefault(vd => vd.ID == idVideo);
                NameVideo = video.videoName;
                Category = video.videoKind.ToString();
                Describe = video.describe;
            });

            ConfirmCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                int.TryParse(ID, out int idVideo);
                var videoTemp = DataProvider.Ins.DB.Videos.Where(vd => vd.ID == idVideo).SingleOrDefault() as Video;
                if (videoTemp == null)
                {
                    MessageBox.Show("Update video fail!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    videoTemp.videoName = NameVideo;
                    int.TryParse(Category, out int kind);
                    videoTemp.videoKind = kind;
                    videoTemp.describe = Describe;

                    DataProvider.Ins.DB.SaveChanges();
                    MessageBox.Show("Update video success!", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                p.Close();
            });
        }
    }
}
