using ProjectVideo.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ProjectVideo.ViewModel
{
    public class MyPlayListViewModel:BaseViewModel
    {
        private string userCurrent;

        public string UserCurrent { get { return userCurrent; } set { userCurrent = value; OnPropertyChanged(); } }

        private ObservableCollection<Video> listFilm;
        public ObservableCollection<Video> ListFilm { get { return listFilm; } set { listFilm = value; OnPropertyChanged(); } }

        public ICommand LoadedWindowCommand { get; set; }

        public MyPlayListViewModel()
        {
            LoadedWindowCommand = new RelayCommand<MyPlayList>((p) => { return true; }, (p) => {
                try
                {
                    var idUser = DataProvider.Ins.DB.Users.FirstOrDefault(us => us.userName == userCurrent); // get id user current 
                    var videoTemp = DataProvider.Ins.DB.PlayLists.Where(pl => pl.idUser == idUser.ID); // get the lines where idUser == id user current
                    ListFilm = new ObservableCollection<Video>();
                    foreach (var item in videoTemp)  // insert all video to ListFilm where id = idVideo belong to playlist of user current
                    {
                        var video = DataProvider.Ins.DB.Videos.FirstOrDefault(vd => vd.ID == item.idVideo);
                        ListFilm.Add(video);
                    }
                }
                catch (Exception ex) { }
            });

        }
    }
}
