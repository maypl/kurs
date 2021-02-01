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

namespace localMovieViewingHistory
{
    public class Raiting
    {
        public int id { get; set; }
        public string name { get; set; }
        public string nameR { get; set; }
        public double raiting { get; set; }
    }
    public class tours
    {
        public int id_tours { get; set; }
        public string title_tours { get; set; }
        public string start_tours { get; set; }
        public int duration { get; set; }
        public string actors { get; set; }
        public string dateStart { get; set; }
    }
    public class genre
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class view
    {
        public int id { get; set; }
        public int idTours { get; set; }
        public int stars { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        public string nameFilmOriginal { get; set; }
        public string nameFilmRussian { get; set; }
        public string description { get; set; }

    }

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool checkQuery(string query)
        {
            if(query.Contains('`'))
            {
                return false;
            }
            return true;
        }

        SqlConnection connect = new SqlConnection("Data Source=localhost\\sqlexpress;Initial Catalog=TA;User ID=sa;Pwd=123;");

        List<tours> tourss = new List<tours>();
        List<genre> genres = new List<genre>();
        List<view> views = new List<view>();
        List<Raiting> raitings = new List<Raiting>();
        public void getTours()
        {
            tourss = new List<tours>();
            try
            {
                connect.Open();
                SqlCommand getTours = connect.CreateCommand();
                int minReturnDateActual = 0;
                
                
                    try
                    {
                        minReturnDateActual = Convert.ToInt32(TextBox2.Text);
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка формата!!");
                        connect.Close();
                        TextBox2.Text = "";
                        return;
                    }
                

                    getTours.CommandText = string.Format("SELECT title_tours,start_tours, quantity FROM dbo.films WHERE(start_tours LIKE '{0}%') AND(title_tours LIKE '{1}%')", TextBox1.Text, Date1.SelectedDate, TextBox2.Text);
                SqlDataReader toursReader = getTours.ExecuteReader();
                while (toursReader.Read())
                {
                    tours.Add(new tourss
                    {
                        start_tours = (string)toursReader[1],
                        title_tours = (string)toursReader[2],
                       
                        actors = (string)toursReader[4],
                        dateStart = (string)toursReader[5]
                    });

                }
                tourTour.Items.Clear();
                foreach (tours film in tourss)
                {
                    tourTour.Items.Add(film);
                }



            }
            finally
            {
                connect.Close();
            }
        }

        public void getGenres()
        {
            genres = new List<genre>();
            try
            {
                connect.Open();
                SqlCommand getGenres = connect.CreateCommand();
                getGenres.CommandText = string.Format("SELECT id, genre_name FROM genres");
                SqlDataReader genresReader = getGenres.ExecuteReader();
                while (genresReader.Read())
                {
                    genres.Add(new genre
                    {
                        id = (int)genresReader[0],
                        name = (string)genresReader[1]
                    });
                }
               

            } finally
            {
                connect.Close();
            }
        }



        public MainWindow()
        {
            InitializeComponent();
            filmsPanel.Visibility = Visibility.Hidden;
        }
       

        private void filmsGetterEvent(object sender, RoutedEventArgs e)
        {
            getTours();
        }
        

 

        public int getIdGenreFromName(string name)
        {
            foreach (genre genre in genres)
            {
                if (genre.name == name)
                {
                    return genre.id;
                }
            }
            return -1;
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (TextBox1.Text != "")
            {
                if (TextBox2.Text != "")
                {
                   
                            if (Date1.SelectedDate != null)
                            {

                                {
                                   
                                        int idTours = 0;
                                        try
                                        {
                                            connect.Open();
                                            SqlCommand setFilm = connect.CreateCommand();
                                            setFilm.CommandText = string.Format("INSERT INTO Tours(title_tours, quantity, start_tours) VALUES (N'{0}', N'{1}', {2}, N'{3}')", TextBox1.Text, TextBox2.Text, Date1.SelectedDate);
                                            if (checkQuery(setFilm.CommandText))
                                            {
                                                setFilm.ExecuteNonQuery();
                                            }
                                            else
                                            {
                                                MessageBox.Show("Обноружена отака!");
                                            }
                                        }
                                        catch
                                        {
                                            MessageBox.Show("Запись должна быть уникальна!");
                                        }
                                        finally
                                        {
                                            connect.Close();
                                        }

                                        try
                                        {
                                            connect.Open();
                                            SqlCommand getNewTours = connect.CreateCommand();
                                            getNewTours.CommandText = string.Format("SELECT id FROM Tours WHERE (title_tours = N'{0}')", TextBox1.Text);
                                            SqlDataReader readerNewTours = getNewTours.ExecuteReader();
                                            readerNewTours.Read();
                                            idTours = (int)readerNewTours[0];
                                        }
                                        catch
                                        {
                                            MessageBox.Show("");
                                        }
                                        finally
                                        {


                                            connect.Close();
                                            TextBox1.Text = "";
                                            TextBox2.Text = "";
                                            Date1.Text = "";
                                        }



                                    
                                }

                            }
                            else
                            {
                                int idTours = 0;
                                try
                                {
                                    connect.Open();
                                    SqlCommand setFilm = connect.CreateCommand();
                                    setFilm.CommandText = string.Format("INSERT INTO films(name_film_original, name_film_russian, duration, actors, premiere_date) VALUES (N'{0}', N'{1}', {2}, N'{3}', N'{4}')", TextBox1.Text, TextBox2.Text, Date1.SelectedDate);
                                    setFilm.ExecuteNonQuery();
                                }
                                catch
                                {
                                    MessageBox.Show("Запись должна быть уникальна!");
                                }
                                finally
                                {
                                    connect.Close();
                                }

                                try
                                {
                                    connect.Open();
                                    SqlCommand getNewTours = connect.CreateCommand();
                                    getNewTours.CommandText = string.Format("SELECT id FROM Tours WHERE (title_tours = N'{0}')", TextBox1.Text);
                                    SqlDataReader readerNewTours = getNewTours.ExecuteReader();
                                    readerNewTours.Read();
                                    idTours = (int)readerNewTours[0];
                                }
                                catch
                                {
                                    MessageBox.Show("");
                                }
                                finally
                                {


                                    connect.Close();
                                    TextBox1.Text = "";
                                    TextBox2.Text = "";
                                    Date1.Text = "";
                                }


                               
                            }
                        
                }
                else
                {
                    MessageBox.Show("Введите количество");
                }
            }
            else
            {
                MessageBox.Show("Введите оригинальное название тура");
            }

        }



        private void TextBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

    

        int selectedMenu;
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(selectedMenu!=menu.SelectedIndex)
            {
                selectedMenu = menu.SelectedIndex;
                getTours();
                getGenres();
                
            }
            
        }

        
    } 
}
