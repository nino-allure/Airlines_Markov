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
using Airlines_Markov.Classes;
using Airlines_Markov.Classes2;
using Airlines_Markov.Pages;
using MySql.Data.MySqlClient;

namespace Airlines_Markov
{
    public partial class MainWindow : Window
    {
        public static MainWindow init;
        public List<TicketClass> ticketClasses = new List<TicketClass>();

        public MainWindow()
        {
            InitializeComponent();
            init = this;
            OpenPage(new Pages.Main());
        }

        public void OpenPage(Page page)
        {
            frame.Navigate(page);
        }

        public void LoadTickets()
        {
            ticketClasses.Clear();
            string conn = "server=localhost;database=airlines;uid=root;pwd=;";

            using (MySqlConnection connection = new MySqlConnection(conn))
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM tickets", connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ticketClasses.Add(new TicketClass(
                        reader["price"].ToString(),
                        reader["from"].ToString(),
                        reader["to"].ToString(),
                        reader["time_start"].ToString(),
                        reader["time_way"].ToString()
                    ));
                }
            }
        }

        private void Exit(object sender, RoutedEventArgs e) => Close();
        private void Back(object sender, RoutedEventArgs e) => OpenPage(new Main());
    }
}