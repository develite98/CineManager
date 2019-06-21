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
    class ChangePasswordViewModel : BaseViewModel
    {
        public string userNameCurrent;
        private string oldPassword;
        private string newPassword;
        private string rePassword;

        public string OldPassword { get { return oldPassword; } set { oldPassword = value; OnPropertyChanged(); } }
        public string NewPassword { get { return newPassword; } set { newPassword = value; OnPropertyChanged(); } }
        public string RePassword { get { return rePassword; } set { rePassword = value; OnPropertyChanged(); } }

        public ICommand PasswordChangedCommand { get; set; }
        public ICommand NewPasswordChangedCommand { get; set; }
        public ICommand RePasswordChangedCommand { get; set; }
        public ICommand UpdatePassCommand { get; set; }

        public ChangePasswordViewModel()
        {
            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) =>
            {
                OldPassword = LoginViewModel.MD5Hash(LoginViewModel.Base64Encode(p.Password));
            });

            NewPasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) =>
            {
                NewPassword = LoginViewModel.MD5Hash(LoginViewModel.Base64Encode(p.Password));
            });

            RePasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) =>
            {
                RePassword = LoginViewModel.MD5Hash(LoginViewModel.Base64Encode(p.Password));
            });

            UpdatePassCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                var user = DataProvider.Ins.DB.Users.FirstOrDefault(us => us.userName == userNameCurrent);
                if(OldPassword != user.userPassword) // check password in database
                {
                    MessageBox.Show("Password is incorrect!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    if(NewPassword != RePassword) // check confirm password 
                    {
                        MessageBox.Show("Confirm password is incorrect!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else // success
                    {
                        user.userPassword = NewPassword;
                        DataProvider.Ins.DB.SaveChanges();
                        MessageBox.Show("Update password success!", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                        p.Close();
                    }
                }
            });
        }
    }
}
