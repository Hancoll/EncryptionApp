using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using EncryptionApp.Model;

namespace EncryptionApp.ViewModel
{
    public class MainViewModel: INotifyPropertyChanged
    {
        private Encryption encryption;

        /// <summary>
        /// Результат шифрования/расшифровывания
        /// </summary>
        public string Result
        {
            get => result;

            set
            {
                result = value;
                OnPropertyChanged("Result");
            }
        }
        private string result;

        /// <summary>
        /// Исходный текст
        /// </summary>
        public string Source
        {
            get => source;

            set
            {
                source = value;
                OnPropertyChanged("Source");
            }
        }
        private string source;

        public Command Encrypt
        {
            get => encrypt;
        }
        private Command encrypt;

        public Command Decrypt
        {
            get => decrypt;
        }
        private Command decrypt;

        public MainViewModel()
        {
            encryption = new Encryption();

            encrypt = new Command((obj) =>
            {
                Result = encryption.Encrypt(Source);
            }, (obj) => true);

            decrypt = new Command((obj) =>
            {
                Result = encryption.Decrypt(Source);
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
