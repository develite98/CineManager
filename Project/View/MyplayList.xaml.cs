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
    /// Interaction logic for MyplayList.xaml
    /// </summary>
    public partial class MyplayList : Window
    {
        public MyplayList()
        {
            InitializeComponent();
        }
        public MyplayList(string userCurrent)
        {
            InitializeComponent();
            txtUserCurrent.Text = userCurrent;
        }

        private void BtnPlay_Click(object sender, RoutedEventArgs e)
        {
            string pathVideo = "";
            var btnClick = (sender) as Button;
            foreach (var textblock in FindVisualChildren<TextBlock>(this))
            {
                if (textblock.Name == "tbVideoPath")
                {
                    if (textblock.Tag.ToString() == btnClick.Tag.ToString())
                    {
                        pathVideo = textblock.Text;
                        break;
                    }
                }
            }
            PlayVideoForm pvf = new PlayVideoForm(pathVideo, txtUserCurrent.Text);
            pvf.ShowDialog();
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
    }
}
