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
using System.Windows.Shapes;

namespace WpfAppcoursework
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void Отмена_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            this.Close();
            mainMenu.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)

        {
            MainMenu MainMenu = new mainMenu();
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-N6Q3M0Q;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            connection.Open();
            string loginStaff = Логин.Text;
            string passwordStaff = Пароль.Password;
            string cmd = "SELECT * FROM  travel agent WHERE Login='" + loginStaff + "' AND Password='" + passwordStaff + "' ";
            SqlCommand createCommand = new SqlCommand(cmd, connection);
            _ = createCommand.ExecuteNonQuery();
            SqlDataReader dr = createCommand.ExecuteReader();
            int count = 0;
            int trysign = 0;
            while (dr.Read())
            {
                trysign++;
                count++;
            }

            // Проверки ввода логина и пароля


            var ps = Пароль.Password.Trim();
            var lg = Логин.Text.Trim();

            if (string.IsNullOrEmpty(lg))
            {
                MessageBox.Show("Введите логин");
                return;
            }
            if (string.IsNullOrEmpty(ps))
            {
                MessageBox.Show("Введите пароль");
                return;
            }

            if (count == 1)
            {
                MessageBox.Show($"Добро Пожаловать!");
                Authorization authorization = new Authorization();
                //Object.Visibility = Visibility.Visible;
                this.Close();
                mwt.Show();
            }
            if (count < 1)
            {
                MessageBox.Show("Ошибка ввода! Неправильный логин или пароль.");

            }
            if (count > 1)
            {

                MessageBox.Show("Ошибка ввода! Неправильный логин или пароль.");

            }


        }




    }
}
