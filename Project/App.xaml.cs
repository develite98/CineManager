using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ProjectVideo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var splashScreen = new SlashScreen();
            this.MainWindow = splashScreen;
            splashScreen.Show();
            Task.Factory.StartNew(() =>
            {
                for (int i = 1; i <= 100; i++)
                {
                    System.Threading.Thread.Sleep(30);
                    splashScreen.Dispatcher.Invoke(() => splashScreen.Progress = i);
                }
                this.Dispatcher.Invoke(() =>
                {
                    var mainWindow = new MainWindow();
                    this.MainWindow = mainWindow;
                    mainWindow.Show();
                    splashScreen.Close();
                });
            });
        }
    }
}
