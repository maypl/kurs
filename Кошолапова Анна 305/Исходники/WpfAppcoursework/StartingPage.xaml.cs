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
using System.Windows.Shapes;

namespace WpfAppcoursework
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class StartingPage : Window
    {
        public StartingPage()
        {
            InitializeComponent();
        }
        Authorization authorization = new Authorization();
        ViewingTours viewingTours = new ViewingTours();

        private void Войти_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            authorization.ShowDialog();
            this.Show();
            Close();
        }
        private void Просмотр_туров_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            viewingTours.ShowDialog();
            this.Show();
            Close();

        }
    }
}
