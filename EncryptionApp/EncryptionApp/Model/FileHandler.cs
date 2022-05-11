using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace EncryptionApp.Model
{
    public class FileHandler
    {
        public bool OpenFile(string path, out string content)
        {
            content = null;

            if (!File.Exists(path))
                return false;

            using(StreamReader reader = File.OpenText(path))
                content = reader.ReadToEnd();

            return true;
        }

        public bool SaveFile(string path, string content)
        {
            try
            {
                using (StreamWriter writer = File.CreateText(path))
                    writer.Write(content);
            }

            catch
            {
                return false;
            }

            return true;
        }
    }
}
