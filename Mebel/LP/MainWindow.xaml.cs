using System;
using System.Configuration;
using System.Data.SqlClient;
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
using System.Windows.Shapes;

namespace LP
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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

        private void Frame_Navigated(object sender, NavigationEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Uri("RegistrationForm.xaml", UriKind.Relative));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
                frame.Navigate(new Uri("Login.xaml", UriKind.Relative));
        }
    }
}