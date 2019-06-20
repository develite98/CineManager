using System;
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
    public class UserViewModel: BaseViewModel
    {
        private string id;
        private string fullName;
        private string email;
        private string phone;
        private string pay;
        private DateTime birthday;

        public string userNameCurrent;

        public string IDUser { get { return id; } set { id = value; OnPropertyChanged(); } }
        public string FullName { get { return fullName; } set { fullName = value; OnPropertyChanged(); } }
        public string Email { get { return email; } set { email = value; OnPropertyChanged(); } }
        public string Phone { get { return phone; } set { phone = value; OnPropertyChanged(); } }
        public string Pay { get { return pay; } set { pay = value; OnPropertyChanged(); } }
        public DateTime BirthDay { get { return birthday; } set { birthday = value; OnPropertyChanged(); } }

        public ICommand LoadedWindowCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand FullNameChangedCommand { get; set; }

        public UserViewModel()
        {
            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                // init user current
                var user = DataProvider.Ins.DB.Users.FirstOrDefault(us => us.userName == userNameCurrent);
                IDUser = user.ID.ToString();
                FullName = user.Name;
                Email = user.Email;
                Phone = user.phoneNumber;
                Pay = user.pay;
                BirthDay = DateTime.Parse(user.birthday);
            });
            UpdateCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                int.TryParse(IDUser, out int userID);
                var userTemp = DataProvider.Ins.DB.Users.Where(us => us.ID == userID).SingleOrDefault() as User;
                if(userTemp == null)
                {
                    MessageBox.Show("Update fail!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    userTemp.Name = FullName;
                    userTemp.Email = Email;
                    userTemp.phoneNumber = Phone;
                    userTemp.pay = Pay;
                    userTemp.birthday = BirthDay.Date.ToString("d");

                    DataProvider.Ins.DB.SaveChanges();
                    MessageBox.Show("Update success!", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                p.Close();
            });
        }

    }
}
