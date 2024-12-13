using System;
using System.Windows.Forms;
using FileWatcher.Core;
using FileWatcher.Services;
using Microsoft.Toolkit.Uwp.Notifications;

namespace FileWatcher.MVVM.ViewModel
{
    internal class MainViewModel : ObservableObject
    {

        private readonly SystemTrayService _systemTray;
        private readonly FileWatcherService _fileWatcher;

        private bool _watching = false;
        public bool Watching
        {
            get { return _watching; }
            set { _watching = value; OnPropertyChanged(); }
        }

        private string _filePath;
        public string FilePath
        {
            get { return _filePath; }
            set
            {
                _filePath = value;
                OnPropertyChanged();
                if (value != null && value != string.Empty)
                {
                    StartWatching();
                }
            }
        }

        public RelayCommand SelectFileCommand { get; set; }
        public RelayCommand StopWatchingCommand { get; set; }
        public RelayCommand MinimizeToTrayCommand { get; set; }


        public MainViewModel()
        {
            SelectFileCommand = new RelayCommand(o => SelectFile());
            StopWatchingCommand = new RelayCommand(o => StopWatching());
            MinimizeToTrayCommand = new RelayCommand(o => MinimizeToTray());

            _systemTray = new SystemTrayService();
            _systemTray.Opening += (sender, args) => UpdateTrayIcon();
            _systemTray.StartWatching += (sender, args) => SelectFile();
            _systemTray.StopWatching += (sender, args) => StopWatching();

            _fileWatcher = new FileWatcherService();
            _fileWatcher.FileChanged += (sender, args) => ShowNotification();
        }

        private void UpdateTrayIcon()
        {
            _systemTray.EditItem(SystemTrayService.MenuItemKey.Watching, GetWatchingText());
        }

        private void ShowNotification()
        {
            string[] names = FilePath.Split('\\');
            string fileName = names[names.Length - 1];

            new ToastContentBuilder()
                .AddText($"The file {fileName} changed.");
        }

        private string GetWatchingText()
        {
            // minus 3 for the ellipsis
            int maxLength = 27 - 3;
            bool filePathNotNull = _filePath != string.Empty && _filePath != null;
            string text = "Watching nothing";

            if (filePathNotNull)
            {
                // check length
                if (_filePath.Length >= maxLength)
                {
                    // reset text
                    text = "";
                    // add visible text
                    for (int i = 0; i < maxLength; i++)
                    {
                        text += _filePath[i];
                    }

                    // ellipsis
                    text += "...";
                }
                else text = $"Watching: {_filePath}";

            }

            return text;
        }

        private void SelectFile()
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                InitialDirectory = @"%USERPROFILE%/Downloads",
                Filter = "All files (*.*)|*.*",
                RestoreDirectory = true
            };

            var result = dialog.ShowDialog();

            if (result == DialogResult.OK) FilePath = dialog.FileName;


        }

        private void StartWatching()
        {
            if (FilePath != string.Empty)
            {
                Watching = true;
                _fileWatcher.StartWatching(FilePath);
            }
        }

        private void StopWatching()
        {
            Watching = false;
            FilePath = null;
            _fileWatcher.StopWatching();
        }

        private void MinimizeToTray()
        {
            System.Windows.Application.Current.MainWindow.Hide();
        }


    }
}
