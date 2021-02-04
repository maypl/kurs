using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LP
{
    /// <summary>
    /// Interaction logic for RegistrationForm.xaml
    /// </summary>
    public partial class RegistrationForm : Page
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Login.Text != "" && Password.Text != "" && UserNam.Text != "" &&
                UserTwoNam.Text != "" && UserThreeName.Text != "")
            {
                var connectionString = @"Data Source=DESKTOP-N6Q3M0Q;Initial Catalog=FurnituraMebel;Integrated Security=True";
                var secondName = UserTwoNam.Text;
                var firstName = UserNam.Text;
                var lastName = UserThreeName.Text;
                var login = Login.Text;
                var password = Password.Text;
                if (!CheckPswd(password))
                {
                    MessageBox.Show("В пароле должны быть цифры\nа также хотя юы один из следующих\nсимволов" +
                        " *, &, {, }, |, +.");
                    return;
                }

                string sqlExpression = $"INSERT INTO [User] (Фамилия, Имя, Отчество, login, password, role) VALUES ('{secondName}', '{firstName}', '{lastName}', '{login}', '{password}', 'Заказчик')";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.ExecuteNonQuery();
                }
                MessageBox.Show("Well Done!");
            }
            else
            {
                MessageBox.Show("Введите данные!");
            }
        }

        //Проверка пароля
        public static bool CheckPswd(string password)
        {
            var check = false;
            if (password.Length < 6 || password.Length > 18)
            {
                return false;
            }

            for (var i = 0; i < password.Length - 2; i++)
            {
                if (password[i] == password[i + 1] ||
                    password[i + 1] == password[i + 2])
                {
                    return false;
                }
            }

            foreach (var item in password)
            {
                if (item >= 48 && item <= 57)
                {
                    check = true;
                    break;
                }
            }
            if (check == false) return false;

            var needChars = new char[] { '*', '&', '{', '}', '|', '+' };
            foreach (var item in password)
            {
                if (needChars.Contains(item))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
