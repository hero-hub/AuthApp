using System.IO;
using System.Windows;

namespace AuthApp
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
            User person = new User();
            person.username = LoginTextBox.Text;
            person.password = PasswordBox.Password;

            if (person.username == "" || person.password == "")
            {
                MessageBox.Show("Ошибка! Введите корректные данные.");
            }
            else
            {
                if (person.IsUserRegistered())
                {
                    MessageBox.Show($"Успешный вход: {person.username}");
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
            User person = new User();
            person.username = LoginTextBox.Text;
            person.password = PasswordBox.Password;

            if (person.username == "" || person.password == "")
            {
                MessageBox.Show("Ошибка! Введите корректные данные.");
            }
            else if (person.IsUserRegistered())
            {
                MessageBox.Show("Пользователь уже зарегистрирован");
            }
            else
            {
                SaveUser(person.username, person.password);
                MessageBox.Show($"Регистрация прошла успешно: {person.username}");
            }
        }

        // проверяем, есть ли пользователь в базе, теперь это в классе
        
        // сохраняем пользователя
        private void SaveUser(string username, string password)
        {
            string info = username + ";" + password + "\n";
            File.AppendAllText("users.txt", info);
        }
    }
}
