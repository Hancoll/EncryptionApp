using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using EncryptionApp.ViewModel;
using EncryptionApp.View;

namespace EncryptionApp
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            //Инициализация ViewModel
            MainViewModel mainViewModel = new MainViewModel();
            FileHandlerViewModel fileHandlerViewModel = new FileHandlerViewModel();

            fileHandlerViewModel.OnFileLoaded = (str) => mainViewModel.Source = str;
            fileHandlerViewModel.OnSavingFile = () => mainViewModel.Result;

            Action<FileHandlerWindow.FileOperationType> applyBttn = (type) =>
            {
                FileHandlerWindow fileHandlerWindow = new FileHandlerWindow(type)
                {
                    DataContext = fileHandlerViewModel
                };

                fileHandlerWindow.Show();
                FileHandlerWindow.IsOpen = true;
            };

            MainWindow = new MainWindow()
            {
                DataContext = mainViewModel,
                OnOpenFileButtonClick = () =>
                {
                    if (!FileHandlerWindow.IsOpen)
                        applyBttn(FileHandlerWindow.FileOperationType.Open);
                },
                OnSaveFileButtonClick = () =>
                {
                    if (!FileHandlerWindow.IsOpen)
                        applyBttn(FileHandlerWindow.FileOperationType.Save);
                }
            };

            MainWindow.Show();
        }
    }
}
