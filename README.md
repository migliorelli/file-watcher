# FileWatcher

**FileWatcher** is an application developed in C# using WPF to monitor file changes and integrate with the system tray.

## Features

- **File Monitoring**: Observes changes in directories and files.
- **Graphical Interface (WPF)**: Provides a user-friendly interface.
- **System Tray Integration**: Uses tray icons for easy access.

## Technologies Used

- **.NET Framework 4.8**
- **WPF** for the user interface.
- **C#** as the main programming language.
- **MVVM (Model-View-ViewModel)** as the design pattern.

## Project Structure

- **`MVVM`**: Contains `Model`, `View`, and `ViewModel` folders to organize the MVVM pattern.
- **`Services`**: Includes services such as `FileWatcherService` and `SystemTrayService`.
- **`MainWindow.xaml`**: The main application interface.
- **`App.xaml`**: Configures the application startup.

## How to Use

### Prerequisites

- Visual Studio 2019 or later.
- .NET Framework 4.8 installed.

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/migliorelli/file-watcher.git
   ```
2. Open the `FileWatcher.sln` file in Visual Studio.
3. Build the project (`Ctrl + Shift + B`).

### Running the Application

1. After building, navigate to the `bin/Debug` or `bin/Release` folder.
2. Run the `FileWatcher.exe` file.

## Contributing

1. Fork the project.
2. Create a new branch:

   ```bash
   git checkout -b feature/new-feature
   ```

3. Make your changes and commit them:

   ```bash
   git commit -m "Add new feature"
   ```

4. Push your changes:

   ```bash
   git push origin feature/new-feature
   ```

5. Open a Pull Request.

## License

This project is licensed under the [MIT License](LICENSE).

## Contact

- Author: **Migliorelli**
- Email: [miglenten@gmail.com](mailto:miglenten@gmail.com)
