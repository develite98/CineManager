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
    /// Interaction logic for ForgotPasswordView.xaml
    /// </summary>
    public partial class ForgotPasswordView : Window
    {
        public ForgotPasswordView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var user = DataProvider.Ins.DB.Users.FirstOrDefault(us => us.userName == txtUserName.Text);
            if ( user != null && user.Email == txtEmail.Text)
            {
                Tab2.IsSelected = true;
                Tab2.Visibility = Visibility.Visible;
                var userTemp = ForgotPassView.DataContext as ForgotPasswordViewModel;
                userTemp.userName = txtUserName.Text;
            }
            else
            {
                MessageBox.Show("User name or Email is incorrect!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
