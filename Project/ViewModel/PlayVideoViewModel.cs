using ProjectVideo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ProjectVideo.ViewModel
{
    public class PlayVideoViewModel :BaseViewModel
    {
        private string pathVideo;
        public string PathVideo { get { return pathVideo; } set { pathVideo = value; OnPropertyChanged(); } }

        public string userCurrent;
        public string UserCurrent { get { return userCurrent; } set { userCurrent = value; OnPropertyChanged(); } }

        public ICommand AddMyPlayListCommand { get; set; }

        public PlayVideoViewModel()
        {
            AddMyPlayListCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                var videoTemp = DataProvider.Ins.DB.Videos.FirstOrDefault(vd => vd.videoPath == PathVideo); // get id video current
                var userTemp = DataProvider.Ins.DB.Users.FirstOrDefault(us => us.userName == UserCurrent); // get id user current
                var isExistsPlayList = DataProvider.Ins.DB.PlayLists.Where(pl => pl.idUser == userTemp.ID && pl.idVideo == videoTemp.ID).Count();
                if(isExistsPlayList != 0)
                {
                    messageBox ms = new messageBox("Video already exists in my playlist!");
                    ms.Show();
                    return;
                }
                if (!string.IsNullOrEmpty(videoTemp.ID.ToString()) && !string.IsNullOrEmpty(userTemp.ID.ToString()))
                {
                    PlayList playList = new PlayList() { idUser = userTemp.ID, idVideo = videoTemp.ID };
                    DataProvider.Ins.DB.PlayLists.Add(playList);
                    DataProvider.Ins.DB.SaveChanges();
                    messageBox ms = new messageBox("Add success");
                    ms.Show();
                }
                else
                {
                    messageBox ms = new messageBox("Add to my playlist False");
                    ms.Show();
                }
            });
        }
    }
}
