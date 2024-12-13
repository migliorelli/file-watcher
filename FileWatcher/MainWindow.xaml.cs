using System;
using System.Data;
using System.Windows;
using FileWatcher.MVVM.ViewModel;

namespace FileWatcher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainViewModel mainViewModel;

        public MainWindow()
        {
            InitializeComponent();
            mainViewModel = DataContext as MainViewModel;
        }

        private void Window_StateChanged(object sender, EventArgs e)
        {
            if (WindowState == WindowState.Minimized)
            {
                mainViewModel?.MinimizeToTrayCommand.Execute(null);
            }
        }
    }
}
