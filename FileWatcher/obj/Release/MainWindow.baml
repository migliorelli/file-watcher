   M S B A M L   `   `   `  ���� F  BFileWatcher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:FileWatcherFileWatcher  G(clr-namespace:FileWatcher.MVVM.ViewModelFileWatcher.MVVM.ViewModel      FileWatcher.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:FileWatcher     >	viewModel(clr-namespace:FileWatcher.MVVM.ViewModel     -     � Title$  FileWatcher�� � Icon$ /Icons/eye.ico�� � 
ResizeMode$ CanMinimize=� � SizeToContent$ Height=�$	��300�� � DataContext .  (FileWatcher.MVVM.ViewModel.MainViewModel  .��� $��
10,0,10,10q� � RowDefinitions �� $
��Auto ��� $��* ��� $
��Auto �.+��� $��File Watcher��$��20(�$��Center=�$��0���� $	��Top=�$��	0,10,0,10q�$��1�� �� 
IsReadOnly .  �� TextWrapping$
 Wrap=�$��0q����� *
FilePath+ �� StringFormat$ 	Path: {0}��	 �� Mode$	 OneWay=��� $��3��.+��� $��Select file��$��Center=�$��2������ *SelectFileCommand+�� $��Stop watching��$��Center=�$��3������ *StopWatchingCommand+���� 
 �� 
TargetType"
 �� �� Triggers ��  �� Binding �� *
Watching+ �� Value	 False.a���  �� Property � y� �� Value$ Hidden=���  � ��$ 0��