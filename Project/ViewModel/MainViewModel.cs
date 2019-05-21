using System;
using System.Collections.Generic;
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
        private string username = "";
        public string UserName { get; set; }
        public ICommand Li_LoCommand { get; set; }

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
        }
    }
}
