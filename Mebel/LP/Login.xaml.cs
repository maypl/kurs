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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var connectionString = @"Data Source=DESKTOP-N6Q3M0Q;Initial Catalog=FurnituraMebel;Integrated Security=True";

            string sqlExpression = "SELECT login,password,role FROM [User]";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        object login = reader.GetValue(0);
                        object password = reader.GetValue(1);
                        object role = reader.GetValue(2);

                        if (Loginn.Text == login.ToString() &&
                            Password.Text == password.ToString())
                        {
                            switch (role.ToString())
                            {
                                case "Заказчик":
                                    title.Text = "Заказчик";
                                    break;
                                case "Менеджер":
                                    title.Text = "Менеджер";
                                    break;
                                case "Мастер":
                                    title.Text = "Мастер";
                                    break;
                                case "Заместитель директора":
                                    title.Text = "Заместитель директора";
                                    break;
                                case "Директор":
                                    title.Text = "Директор";
                                    break;
                            }
                            MessageBox.Show("Регистрация успешна!");
                        }
                        else 
                        {
                            MessageBox.Show("Введите данные!");
                            break;
                        }
                    }
                }

                reader.Close();
            }
            l.Width = 0;
            n.Width = 0;
            Loginn.Width = 0;
            Password.Width = 0;
            b.Width = 0;
        }
    }
}
