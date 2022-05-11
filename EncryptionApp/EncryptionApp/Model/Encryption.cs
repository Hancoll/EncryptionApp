using System;
using System.Collections.Generic;
using System.Text;

namespace EncryptionApp.Model
{
    public class Encryption
    {
        public string Encrypt(string source)
        {
            if (source == null)
                return null;

            return Add(source, 1);
        }

        public string Decrypt(string source)
        {
            if (source == null)
                return null;

            return Add(source, -1);
        }

        private string Add(string source, int value)
        {
            char[] array = source.ToCharArray();

            for (int i = 0; i < array.Length; i++)
            {
                int temp = (int)array[i];
                temp += value;
                array[i] = (char)temp;
            }

            return string.Concat(array);
        }
    }
}
