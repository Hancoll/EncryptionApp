using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using EncryptionApp.ViewModel;

namespace EncryptionApp.View
{
    public partial class MainWindow : Window
    {
        public Action OnOpenFileButtonClick { get; set; }
        public Action OnSaveFileButtonClick { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        public void SaveFileButtonClick(object sender, RoutedEventArgs e) => OnSaveFileButtonClick?.Invoke();

        public void OpenFileButtonClick(object sender, RoutedEventArgs e) => OnOpenFileButtonClick?.Invoke();
    }
}
