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
            this.Height = System.Windows.SystemParameters.WorkArea.Height;
            this.Width = System.Windows.SystemParameters.WorkArea.Width;
            GridMain.Width = System.Windows.SystemParameters.WorkArea.Width;
        }

        public MainWindow(string UserName)
        {
            InitializeComponent();
            this.Height = System.Windows.SystemParameters.WorkArea.Height;
            this.Width = System.Windows.SystemParameters.WorkArea.Width;
            GridMain.Width = System.Windows.SystemParameters.WorkArea.Width;
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


        private void Button_Click(object sender, RoutedEventArgs e)
        {


        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            ScrollView1.ScrollToVerticalOffset(5);
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            ScrollView1.ScrollToVerticalOffset(250);
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            ScrollView1.ScrollToVerticalOffset(500);
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            ScrollView1.ScrollToVerticalOffset(750);
        }


        public IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);

                    if (child != null && child is T)
                        yield return (T)child;

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                        yield return childOfChild;
                }
            }
        }

        private void Button_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //foreach (var grid in FindVisualChildren<Grid>(this))
            //{
            //    if (grid.Name == "GridInfo")
            //    {
            //        /*   Your code here  */
            //        grid.Visibility = Visibility.Visible;
            //    }
            //}
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
