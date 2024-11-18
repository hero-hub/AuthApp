using System.IO;
using System.Windows;

namespace AuthApp
{
    class User {
        public string username = "";
        public string password = "";
        public string mail = "";

        public bool IsUserRegistered()
        {
            if (File.Exists("users.txt"))
            {
                string[] readFile = File.ReadAllLines("users.txt");
                for (int i = 0; i < readFile.Length; i++)
                {
                    string[] data = readFile[i].Split(';');
                    if (data.Length == 3 && data[0] == username && data[1] == password && data[2] == mail)
                    {
                        return true;
                    }
                }
            }
            return false;
        } 
    }
}