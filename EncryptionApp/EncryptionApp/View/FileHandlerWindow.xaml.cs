using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EncryptionApp.View
{
    /// <summary>
    /// Логика взаимодействия для FileHandlerWindow.xaml
    /// </summary>
    public partial class FileHandlerWindow : Window
    {
        public enum FileOperationType { Open, Save }

        public FileOperationType OperationType { get; set; }
        public static bool IsOpen { get; set; }//Открыто ли окно

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            IsOpen = false;
        }

        public FileHandlerWindow(FileOperationType operationType)
        {
            InitializeComponent();

            this.OperationType = operationType;
            applyButton.Content = operationType == FileOperationType.Open ?
                "Открыть" : "Сохранить";
        }
    }
}
