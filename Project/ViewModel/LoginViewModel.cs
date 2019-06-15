using ProjectVideo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ProjectVideo.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        public bool isLogin = false;
        public ICommand LoginCommand { get; set; }
        public ICommand PasswordChangedCommand { get; set; }
        public ICommand SignUpFormCommand { get; set; }

        private string userName;
        public string UserName { get { return userName; } set { userName = value; OnPropertyChanged(); } }

        public string fullNameUser;

        private string password;
        public string Password { get { return password; } set { password = value; OnPropertyChanged(); } }

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { Login(p); });
            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { Password = MD5Hash(Base64Encode(p.Password)); });
            SignUpFormCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { MoveToSignUpForm(p); });
        }

        private void Login(Window p)
        {
            if (p == null)
                return;
            // check admin
            int admin = DataProvider.Ins.DB.Users.Where(us => us.userName == UserName && us.userPassword == Password && us.isAdmin == true).Count();
            //---------------
            // check user
            int user = DataProvider.Ins.DB.Users.Where(us => us.userName == UserName && us.userPassword == Password).Count();
            //---------------
            if (admin > 0 || user > 0) // module Admin
            {
                var temp = DataProvider.Ins.DB.Users.Where(us => us.userName == userName && us.userPassword == Password).FirstOrDefault();
                fullNameUser = temp.Name;
                isLogin = true;
                p.Close();
            }
            //else if (user > 0) // module User
            //{
            //    isLogin = true;
            //    p.Close();
            //}
            else // Login fail
            {
                isLogin = false;
                MessageBox.Show("Wrong account or password!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }

        private void MoveToSignUpForm(Window p)
        {
            if (p == null)
                return;
            p.Hide();
            SignUp signUpForm = new SignUp();
            signUpForm.ShowDialog();
            p.Close();
        }
    }
}
