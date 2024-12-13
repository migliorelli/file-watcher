using System;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Forms;

namespace FileWatcher.Services
{

    internal class SystemTrayService
    {
        public readonly NotifyIcon NotifyIcon;
        public ContextMenuStrip CTXMenuStrip = new ContextMenuStrip();

        public event Action<object, EventArgs> DoubleClick;
        public event Action<object, EventArgs> Opening;

        public event Action<object, EventArgs> StartWatching;
        public event Action<object, EventArgs> StopWatching;

        public enum MenuItemKey
        {
            Watching,
            StartWatching,
            StopWatching,
            Quit
        }

        public SystemTrayService()
        {
            NotifyIcon = new NotifyIcon
            {
                Visible = true,
                Text = "File Watcher",
                ContextMenuStrip = CTXMenuStrip,
                Icon = new Icon(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Icons/eye.ico")),
            };

            NotifyIcon.ContextMenuStrip.Items.Add("Watching nothing").Tag = MenuItemKey.Watching;
            NotifyIcon.ContextMenuStrip.Items.Add("Watch another file", null, (sender, args) => OnStartWatching(sender, args)).Tag = MenuItemKey.StartWatching;
            NotifyIcon.ContextMenuStrip.Items.Add("Stop watching", null, (sender, args) => OnStopWatching(sender, args)).Tag = MenuItemKey.StopWatching;
            NotifyIcon.ContextMenuStrip.Items.Add("Quit", null, (sender, args) => OnQuit()).Tag = MenuItemKey.Quit;

            NotifyIcon.DoubleClick += (sender, args) => OnDoubleClick(sender, args);
            NotifyIcon.ContextMenuStrip.Opening += (sender, args) => OnOpening(sender, args);
        }

        public void EditItem(MenuItemKey key, string newText = null, bool? isEnabled = null, bool? isVisible = null)
        {
            string keyName = key.ToString();

            if (CTXMenuStrip.Items.ContainsKey(keyName))
            {
                ToolStripItem item = CTXMenuStrip.Items[keyName];

                if (newText != null)
                {
                    item.Text = newText;
                }

                if (isEnabled.HasValue)
                {
                    item.Enabled = isEnabled.Value;
                }

                if (isVisible.HasValue)
                {
                    item.Visible = isVisible.Value;
                }
            }

        }

        private void OnDoubleClick(object sender, EventArgs args)
        {
            NotifyIcon.Visible = true;
            System.Windows.Application.Current.MainWindow.Show();
            System.Windows.Application.Current.MainWindow.WindowState = WindowState.Normal;
            System.Windows.Application.Current.MainWindow.Activate();

            DoubleClick?.Invoke(this, args);
        }

        private void OnOpening(object sender, EventArgs args)
        {
            Opening?.Invoke(this, args);
        }

        private void OnStartWatching(object sender, EventArgs args)
        {
            StartWatching?.Invoke(this, args);
        }

        private void OnStopWatching(object sender, EventArgs args)
        {
            StopWatching?.Invoke(this, args);
        }

        private void OnQuit()
        {
            System.Windows.Application.Current.Shutdown();
        }



    }
}
