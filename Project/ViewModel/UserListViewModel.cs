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
    public class UserListViewModel: BaseViewModel
    {

        private ObservableCollection<User> listUser;

        public ICommand LoadedWindowCommand { get; set; }
        public UserListViewModel()
        {
            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                LoadUserList();
            });
        }

        void LoadUserList()
        {
            listUser = new ObservableCollection<User>(DataProvider.Ins.DB.Users);
        }
    }
}
