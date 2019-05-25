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

namespace ProjectVideo.UserControlS
{
    /// <summary>
    /// Interaction logic for ControlBars.xaml
    /// </summary>
    public partial class ControlBars : UserControl
    {
        public ControlBarViewModel Viewmodel { get; set; }

        public ControlBars()
        {
            InitializeComponent();
            this.DataContext = Viewmodel = new ControlBarViewModel();
        }

       
    }
}
