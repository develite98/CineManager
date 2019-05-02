using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjectVideo.ViewModel
{
    public class MainViewModel: BaseViewModel
    {
        public MainViewModel()
        {
            Login LoginWD = new Login();
            LoginWD.ShowDialog();
            
        }
    }
}
