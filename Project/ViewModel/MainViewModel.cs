﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ProjectVideo.Models;

namespace ProjectVideo.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private ObservableCollection<VideoKind> listFilmByKind;
        public ObservableCollection<VideoKind> ListFilmByKind { get { return listFilmByKind; } set { listFilmByKind = value; OnPropertyChanged(); } }
        private ObservableCollection<Video> lstFilm;

        private string userCurrent;

        public string UserCurrent { get { return userCurrent; } set { userCurrent = value; OnPropertyChanged(); } }

        private ObservableCollection<Video> mylistFilm;
        public ObservableCollection<Video> MyListFilm { get { return mylistFilm; } set { mylistFilm = value; OnPropertyChanged(); } }


        public string UserName { get; set; }
        public string FullName { get; set; }

        private string videoPath = "";
        public string VideoPath { get { return videoPath; } set { videoPath = value; OnPropertyChanged(); } }

        public ICommand LoginCommand { get; set; }
        public ICommand LoadedWindowCommand { get; set; }

        public ICommand SignUpCommand { get; set; }

        public ICommand LogoutCommand { get; set; }

        public MainViewModel()
        {
            // handle login
            LoginCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
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
                        FullName = loginViewModel.fullNameUser;
                        mainWindow = new MainWindow(FullName,UserName);
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
                //else // handle logout
                //{
                //    loginViewModel.UserName = null;
                //    loginViewModel.Password = null;
                //    mainWindow = new MainWindow();
                //    mainWindow.Show();
                //    p.Close();
                //}
            });

            SignUpCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (p == null)
                    return;
                p.Hide();
                SignUp signUpView = new SignUp();
                signUpView.ShowDialog();
                var signUpViewModel = signUpView.DataContext as SignUpViewModel;
                MainWindow mainWindow = null;
                if (!signUpViewModel.isSignup)   //check signup fail
                {
                    mainWindow = new MainWindow();
                    mainWindow.Show();
                    p.Close();
                }
            });

            LogoutCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                Login loginView = new Login();
                var loginViewModel = loginView.DataContext as LoginViewModel;
                loginViewModel.UserName = null;
                loginViewModel.Password = null;
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                p.Close();
            });

            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                loadKindOfFilm();
            });
        }

        private void loadKindOfFilm()
        {
            ListFilmByKind = new ObservableCollection<VideoKind>(DataProvider.Ins.DB.VideoKinds); // Load category film
            foreach (var lst in ListFilmByKind) // load film by category
            {
                lstFilm = new ObservableCollection<Video>(DataProvider.Ins.DB.Videos.Where(x => x.videoKind == lst.ID)); 
                lst.listFilm = lstFilm;
            }
        }
    }
}

