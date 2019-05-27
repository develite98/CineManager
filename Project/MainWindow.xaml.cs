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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjectVideo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(string UserName)
        {
            InitializeComponent();
            if (UserName != null)
            {
                //txtModule.Text = UserName;
                btnLi_Lo.Content = "Logout";
            }
        }
        private void BtnOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            btnOpenMenu.Visibility = Visibility.Collapsed;
            btnCloseMenu.Visibility = Visibility.Visible;
        }

        private void BtnCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            btnOpenMenu.Visibility = Visibility.Visible;
            btnCloseMenu.Visibility = Visibility.Collapsed;
        }

        private void MainViewWindow_Loaded(object sender, RoutedEventArgs e)
        {
            List<test> list = new List<test>();
            list.Add(new test { ImagePATH = "/Resources/br1.jpg", TEST_NAME = "Phong", INFO = "Phim con heo" });
            list.Add(new test { ImagePATH = "/Resources/br2.jpg", TEST_NAME = "Arrr", INFO = "Phim con heo" });
            list.Add(new test { ImagePATH = "/Resources/br3.jpg", TEST_NAME = "BBB", INFO = "Phim con heo" });
            list.Add(new test { ImagePATH = "/Resources/br4.jpg", TEST_NAME = "RRR", INFO = "Phim con heo" });
            list.Add(new test { ImagePATH = "/Resources/br5.jpg", TEST_NAME = "CCC", INFO = "Phim con heo" });
            list1.ItemsSource = list;
        }


        public class test
        {
            private string test_name;
            private string ipath;
            private string info;
            public string TEST_NAME
            {
                get
                {
                    return test_name;
                }
                set
                {
                    test_name = value;
                }
            }
            public string ImagePATH
            {
                get
                {
                    return ipath;
                }
                set
                {
                    ipath = value;
                }
            }
            public string INFO
            {
                get
                {
                    return info;
                }
                set
                {
                    info = value;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


        }
    }
}
