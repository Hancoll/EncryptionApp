using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using EncryptionApp.Model;
using EncryptionApp.View;

namespace EncryptionApp.ViewModel
{
    public class FileHandlerViewModel: INotifyPropertyChanged
    {
        private FileHandler fileHandler;

        public string Path
        {
            get => path;

            set
            {
                path = value;
                OnPropertyChanged("Path");
            }
        }
        private string path;

        public Command Apply
        {
            get => apply;
        }
        private Command apply;

        public Action<string> OnFileLoaded { get; set; }
        public Func<string> OnSavingFile { get; set; }

        private void OpenFile(string path, FileHandlerWindow fileHandlerWindow)
        {
            if (!fileHandler.OpenFile(path, out string content))
                return;

            OnFileLoaded(content);
            fileHandlerWindow.Close();
        }

        private void SaveFile(string path, FileHandlerWindow fileHandlerWindow)
        {
            if(fileHandler.SaveFile(path, OnSavingFile()))
                fileHandlerWindow.Close();
        }

        public FileHandlerViewModel()
        {
            fileHandler = new FileHandler();

            apply = new Command((obj) =>
            {
                FileHandlerWindow fileHandlerWindow = obj as FileHandlerWindow;

                if (fileHandlerWindow.OperationType == FileHandlerWindow.FileOperationType.Open)
                    OpenFile(Path, fileHandlerWindow);
                else
                    SaveFile(Path, fileHandlerWindow);

            }, (obj) => true);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
