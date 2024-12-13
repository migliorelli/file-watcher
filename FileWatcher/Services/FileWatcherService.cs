using System;
using System.IO;

namespace FileWatcher.Services
{
    internal class FileWatcherService
    {
        private FileSystemWatcher _watcher;
        public event EventHandler<FileSystemEventArgs> FileChanged;

        public void StartWatching(string filePath)
        {
            _watcher = new FileSystemWatcher()
            {
                NotifyFilter = NotifyFilters.LastWrite,
                Filter = Path.GetFileName(filePath),
                Path = Path.GetDirectoryName(filePath),
                EnableRaisingEvents = true
            };

            _watcher.Changed += OnChanged;
        }

        public void StopWatching()
        {
            if (_watcher != null)
            {
                _watcher.EnableRaisingEvents = false;
                _watcher.Changed -= OnChanged;
                _watcher.Dispose();
            }
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            FileChanged?.Invoke(this, e);
        }
    }
}
