using ProjectVideo.Models;
using ProjectVideo.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjectVideo
{
    /// <summary>
    /// Interaction logic for UserInfo.xaml
    /// </summary>
    public partial class UserInfo : Window
    {
        public UserInfo()
        {
            InitializeComponent();
        }

        public UserInfo(string userName)
        {
            InitializeComponent();
            var userViewModel = UserView.DataContext as UserViewModel;
            try
            {
                var userCurrent = DataProvider.Ins.DB.Users.FirstOrDefault(us => us.userName == userName);
                userViewModel.userNameCurrent = userName;
                
                // show info user current
                txtFullName.Text = userCurrent.Name;
                txtEmail.Text = userCurrent.Email;
                txtPhone.Text = userCurrent.phoneNumber;
                txtPay.Text = userCurrent.pay;
                BirhtDay.Text = userCurrent.birthday;
            }
            catch (Exception ex) { }
        }
    }
}
