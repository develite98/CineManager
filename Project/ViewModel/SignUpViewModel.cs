using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ProjectVideo.Models;

namespace ProjectVideo.ViewModel
{
    public class SignUpViewModel : BaseViewModel
    {
        public ICommand SignUpCommand { get; set; }
        public ICommand PasswordChangedCommand { get; set; }
        public ICommand PasswordChangedAgainCommand { get; set; }

        private string userName;
        private string password;
        private string confirmPassword;
        private string email;
        private string fullName;
        private string phone;
        private DateTime birthday;
        private string visa;

        public string UserName { get { return userName; } set { userName = value; OnPropertyChanged(); } }
        public string Password { get { return password; } set { password = value; OnPropertyChanged(); } }
        public string ConfirmPassword { get { return confirmPassword; } set { confirmPassword = value; OnPropertyChanged(); } }
        public string Email { get { return email; } set { email = value; OnPropertyChanged(); } }
        public string FullName { get { return fullName; } set { fullName = value; OnPropertyChanged(); } }
        public string PhoneNumber { get { return phone; } set { phone = value; OnPropertyChanged(); } }
        public DateTime BirthDay { get { return birthday; } set { birthday = value; OnPropertyChanged(); } }
        public string Visa { get { return visa; } set { visa = value; OnPropertyChanged(); } }

        public SignUpViewModel()
        {
            SignUpCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { SignUp(p); });
            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { Password = LoginViewModel.MD5Hash(LoginViewModel.Base64Encode(p.Password)); });
            PasswordChangedAgainCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { ConfirmPassword = LoginViewModel.MD5Hash(LoginViewModel.Base64Encode(p.Password)); });
        }

        private void SignUp(Window p)
        {
            if (p == null)
                return;
            if (Password != ConfirmPassword) // Check the password entered again
            {
                MessageBox.Show("Repeat password is incorrect!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            int checkUser = DataProvider.Ins.DB.Users.Where(us => us.userName == UserName).Count(); // Check user exist
            if (checkUser != 0) // user was exist
            {
                MessageBox.Show("Account was exist!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            // check emty input info -> insert success
            if (!string.IsNullOrEmpty(FullName) && !string.IsNullOrEmpty(BirthDay.Date.ToString("d")) && !string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password) &&
                !string.IsNullOrEmpty(ConfirmPassword) && !string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(PhoneNumber) && !string.IsNullOrEmpty(Visa))
            {
                // insert database 
                var user = new User() { Name = FullName, birthday = BirthDay.Date.ToString("d") /*get date*/, userName = UserName, userPassword = Password, Email = Email, phoneNumber = PhoneNumber, pay = Visa, isAdmin = false };
                DataProvider.Ins.DB.Users.Add(user);
                DataProvider.Ins.DB.SaveChanges();
                MessageBox.Show("Register success!", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                p.Close();
                Login loginView = new Login();
                loginView.ShowDialog();
            }
            else
            {
                MessageBox.Show("Must be not emty!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
