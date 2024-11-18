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
            person.mail = MailTextBox.Text;

            if (!Correct(person.username, person.password, person.mail))
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
            person.mail = MailTextBox.Text;

            if (!Correct(person.username, person.password, person.mail))
            {
                MessageBox.Show("Ошибка! Введите корректные данные.");
            }
            else if (person.IsUserRegistered())
            {
                MessageBox.Show("Пользователь уже зарегистрирован");
            }
            else
            {
                SaveUser(person.username, person.password, person.mail);
                MessageBox.Show($"Регистрация прошла успешно: {person.username}");
            }
        }

        // проверяем корректность данных
        private bool Correct(string username, string password, string mail){
            string[] data = mail.Split('@');
            string[] domain = data[1].Split('.');

            // проверка на повторный символ '@', на вторую точку и на наличие запретного символа ';'  
            if (username == "" || password == "" || mail == "" || domain[0] == "" ||
                mail.Split('@').Length - 1 > 1 || domain[1].Split('.').Length - 1 > 1 || 
                username.Split(';').Length - 1 > 0 || password.Split(';').Length - 1 > 0 ||
                mail.Split(';').Length - 1 > 0)
            {
                return false;
            }
            else if (domain[1] != "ru" && domain[1] != "com")
            {
                return false;
            }

            return true;       
        }

        // сохраняем пользователя
        private void SaveUser(string username, string password, string mail)
        {
            string info = username + ";" + password + ";" + mail + "\n";
            File.AppendAllText("users.txt", info);
        }
    }
}
