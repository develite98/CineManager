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
    class AdminViewModel : BaseViewModel
    {
        private ObservableCollection<User> listUser;

        public ObservableCollection<User> ListUser { get { return listUser; } set { listUser = value; OnPropertyChanged(); } }

        private ObservableCollection<Video> listFilm;

        public ObservableCollection<Video> ListFilm { get { return listFilm; } set { listFilm = value; OnPropertyChanged(); } }

        public ICommand LoadedWindowCommand { get; set; }

        public AdminViewModel()
        {
            LoadedWindowCommand = new RelayCommand<AdminManager>((p) => { return true; }, (p) => {
                ListUser = new ObservableCollection<User>(DataProvider.Ins.DB.Users);
                ListFilm = new ObservableCollection<Video>(DataProvider.Ins.DB.Videos);
            });
        }
    }
}
