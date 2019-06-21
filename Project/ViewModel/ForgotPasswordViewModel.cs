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
    class ForgotPasswordViewModel : BaseViewModel
    {
        public string userName;
        private string newPassword;
        private string rePassword;
        public string NewPassword { get { return newPassword; } set { newPassword = value; OnPropertyChanged(); } }
        public string RePassword { get { return rePassword; } set { rePassword = value; OnPropertyChanged(); } }

        public ICommand NewPasswordChangedCommand { get; set; }
        public ICommand RePasswordChangedCommand { get; set; }
        public ICommand ConfirmCommand { get; set; }

        public ForgotPasswordViewModel()
        {
            NewPasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) =>
            {
                NewPassword = LoginViewModel.MD5Hash(LoginViewModel.Base64Encode(p.Password));
            });

            RePasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) =>
            {
                RePassword = LoginViewModel.MD5Hash(LoginViewModel.Base64Encode(p.Password));
            });

            ConfirmCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                if (NewPassword != RePassword)
                {
                    MessageBox.Show("Confirm password is incorrect!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    var user = DataProvider.Ins.DB.Users.Where(us => us.userName == userName).SingleOrDefault();
                    user.userPassword = NewPassword;
                    DataProvider.Ins.DB.SaveChanges();
                    MessageBox.Show("Changed password success!", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                    p.Close();
                }
            });
        }
    }
}
