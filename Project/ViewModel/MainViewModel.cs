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
        public ICommand LoginViewCommand { get; set; }

        public MainViewModel()
        {
            LoginViewCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { p.Hide(); Login login = new Login(); login.ShowDialog(); });
        }
    }
}
