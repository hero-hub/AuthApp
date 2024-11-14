using System.IO;
using System.Windows;

namespace MyAuthApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // авторизация
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = LoginTextBox.Text;
            string password = PasswordBox.Password;

            if (username == "" || password == "")
            {
                MessageBox.Show("Ошибка! Введите корректные данные.");
            }
            else
            {
                if (IsUserRegistered(username, password))
                {
                    MessageBox.Show($"Успешный вход: {username}");
                }
                else
                {
                    MessageBox.Show("Пожалуйста, для начала зарегистрируйтесь.");
                }
            }
        }

        // регистрация
        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string username = LoginTextBox.Text;
            string password = PasswordBox.Password;

            if (username == "" || password == "")
            {
                MessageBox.Show("Ошибка! Введите корректные данные.");
            }
            else if (IsUserRegistered(username, password))
            {
                MessageBox.Show("Пользователь уже зарегистрирован");
            }
            else
            {
                SaveUser(username, password);
                MessageBox.Show($"Регистрация прошла успешно: {username}");
            }
        }

        // проверяем, есть ли пользователь в базе
        private bool IsUserRegistered(string username, string password)
        {
            if (File.Exists("users.txt"))
            {
                string[] readFile = File.ReadAllLines("users.txt");
                for (int i = 0; i < readFile.Length; i++)
                {
                    string[] data = readFile[i].Split(';');
                    if (data.Length == 2 && data[0] == username && data[1] == password)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void SaveUser(string username, string password)
        {
            string info = username + ";" + password + "\n";
            File.AppendAllText("users.txt", info);
        }
    }
}