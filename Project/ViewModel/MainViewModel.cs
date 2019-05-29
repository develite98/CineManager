using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ProjectVideo.Models;

namespace ProjectVideo.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private ObservableCollection<VideoKind> listFilmByKind;
        public ObservableCollection<VideoKind> ListFilmByKind { get { return listFilmByKind; } set { listFilmByKind = value; OnPropertyChanged(); } }

        private ObservableCollection<Video> lstFilm;

        private string username = "";
        public string UserName { get; set; }
        public ICommand Li_LoCommand { get; set; }
        public ICommand LoadedWindowCommand { get; set; }

        public MainViewModel()
        {
            // handle login - logout
            Li_LoCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                Login loginView = new Login();
                var loginViewModel = loginView.DataContext as LoginViewModel;
                MainWindow mainWindow = null;

                if (loginViewModel.UserName == null) // check user name = null -> handle login
                {
                    p.Hide();
                    loginView.ShowDialog();

                    if (loginViewModel.isLogin)
                    {
                        UserName = loginViewModel.UserName;
                        mainWindow = new MainWindow(UserName);
                        mainWindow.Show();
                        p.Close();
                    }
                    else
                    {
                        mainWindow = new MainWindow();
                        mainWindow.Show();
                        p.Close();
                    }
                }
                else // handle logout
                {
                    loginViewModel.UserName = null;
                    loginViewModel.Password = null;
                    mainWindow = new MainWindow();
                    mainWindow.Show();
                    p.Close();
                }
            });

            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                loadKindOfFilm();
            });
        }

        private void loadKindOfFilm()
        {
            ListFilmByKind = new ObservableCollection<VideoKind>(DataProvider.Ins.DB.VideoKinds);
            foreach (var lst in ListFilmByKind)
            {
                lstFilm = new ObservableCollection<Video>(DataProvider.Ins.DB.Videos.Where(x => x.videoKind == lst.ID));
                lst.listFilm = lstFilm;
            }
        }
    }
}

