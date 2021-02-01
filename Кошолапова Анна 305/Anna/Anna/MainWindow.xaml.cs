using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Anna
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string connectionString = @"Data Source=DESKTOP-N6Q3M0Q;Initial Catalog=TA;Integrated Security=True";
        public MainWindow()
        {
            InitializeComponent();
            
            


            // Создание подключения
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                // Открываем подключение
                connection.Open();
            }
            catch (SqlException ex)
            {
            }
            finally
            {
                // закрываем подключение
                connection.Close();
                //tb.Text = "Подключение закрыто...";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainData.Text = "";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sqlExpression = "Select title FROM Countries";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read()) // построчно считываем данные
                        {
                            MainData.Text += reader.GetValue(0) + "\n";
                        }
                    }
                }
            }
        }

        private void st_Click(object sender, RoutedEventArgs e)
        {
            MainData.Text = "";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sqlExpression = "Select start_tours FROM Tours";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read()) // построчно считываем данные
                        {
                            MainData.Text += reader.GetValue(0) + "\n";
                        }
                    }
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainData.Text = "";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sqlExpression = "Select price FROM Tours";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read()) // построчно считываем данные
                        {
                            MainData.Text += reader.GetValue(0) + "\n";
                        }
                    }
                }
            }
        }

        private void delcust_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sqlExpression = $"DELETE FROM Customer WHERE id_customers = {delcustnum.Text}";
                using (SqlCommand command = new SqlCommand(sqlExpression, connection))
                {
                    command.ExecuteReader();
                }
            }
        }

        private void delcount_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sqlExpression = $"DELETE FROM Countries WHERE id_countries = {delcountnum.Text}";
                using (SqlCommand command = new SqlCommand(sqlExpression, connection))
                {
                    command.ExecuteReader();
                }
            }
        }

        private void deltour_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sqlExpression = $"DELETE FROM Tours WHERE id_tours = {deltournum.Text}";
                using (SqlCommand command = new SqlCommand(sqlExpression, connection))
                {
                    command.ExecuteReader();
                }
            }
        }
    }
}
