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
using System.Windows.Navigation;
using System.Data.SqlClient;
using System.Windows.Shapes;

namespace Pavilions
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        

        private void gb4_Click(object sender, RoutedEventArgs e)
        {
            
            string connectionString = @"Data Source=DESKTOP-N6Q3M0Q;Initial Catalog=Pavilions;Integrated Security=True";

            string sqlExpression = "SELECT login, password FROM Staff";
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

                        if (Login.Text == login.ToString() &&
                            Password.Text == password.ToString()) {
                            Login.Width = 0;
                            Password.Width = 0;
                            gb1.Width = 0;
                            gb2.Width = 0;
                            gb3.Width = 0;
                            gb4.Width = 0;
                        }
                    }
                    ShowBoxes();
                    FillList();
                }

                reader.Close();
            }
        }
        List<object> Centers = new List<object>();
        public void ShowBoxes() {
            ShopList.Width = 626;
            AddBox.Width = 626;
            btn.Height = 23;
            FindBtn.Height = 23;
        }
        int n = 0;
        public void FillList()
        {
            string connectionString = @"Data Source=DESKTOP-N6Q3M0Q;Initial Catalog=Pavilions;Integrated Security=True";

            string sqlExpression = "SELECT * FROM ShoppingCenter";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        var str = $"{n+1}. ";
                        for (var i = 0; i < 7; i++)
                        {
                            var s = reader.GetValue(i);

                            if(i<6) str = str + $"{s.ToString().PadRight(20)};";
                            else str = str + $"{s}";
                        }
                        reader.GetValue(7);
                        Centers.Add("");
                        Centers[n++] = str;
                    }
                }

                var d = new string[7] { "Название ТЦ", "Стадия","Кол-во павильонов",
                    "Город","Цена","Цен-й К-т","Этажи" };
                var l = "";
                foreach (var item in d)
                {
                    if (item == "Этажи") {
                        l = l + item;
                        break;
                    }
                    l = l + item.PadRight(20) + " ";
                }
                ShopList.Items.Add($"   {l}");

                foreach (var item in Centers)
                {
                    ShopList.Items.Add(item);
                }
                reader.Close();
            }
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            ShopList.Items.Add($"{n+1}. {AddBox.Text}");
            n++;
        }

        private void FindBtn_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in ShopList.Items)
            {
                var i = item.ToString().Split(';');
                for (var ii = 0; ii < i.Length; ii++)
                {
                    if (ii == 0)
                    {
                        i[ii] = i[ii].Substring(3, i[ii].Length - 5);
                        i[ii] = i[ii].Trim();// 
                    }
                    else
                    {
                        try
                        {
                            i[ii] = i[ii].Substring(0, i[ii].Length - 2);
                            i[ii] = i[ii].Trim();
                        }
                        catch { }
                    }
                }
                foreach (var n in i)
                {
                    if (n == AddBox.Text)
                    {
                        if (SeS.Text != item.ToString().Substring(0, 2))
                        {
                            AddBox.Text = item.ToString();
                        }
                    }
                }
            }
            try
            {
                SeS.Text = AddBox.Text.Substring(0, 2);
            }
            catch
            {
                SeS.Text = "0";
            }
        }
    }
}
