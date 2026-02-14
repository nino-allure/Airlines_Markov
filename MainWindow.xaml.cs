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
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow init;
        public List<TicketClass> TicketContext = new List<TicketClass>(); // Изменено с Context на TicketClass

        public MainWindow()
        {
            InitializeComponent();
            init = this;
            OpenPage(new Pages.Main());
        }

        public void OpenPage(Page Page)
        {
            frame.Navigate(Page);
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public List<TicketClass> ticketClasses = new List<TicketClass>();

        public void LoadTickets()
        {
            ticketClasses.Clear();
            string connection = "server=localhost;port=3306;database=airlines;uid=root;pwd=;";
            MySqlConnection mySqlConnection = new MySqlConnection(connection);

            try
            {
                mySqlConnection.Open();

                MySqlCommand command = new MySqlCommand("SELECT * FROM airlines.tickets;", mySqlConnection);
                MySqlDataReader ticket_query = command.ExecuteReader();

                while (ticket_query.Read())
                {
                    // Индексы:
                    // 0 - ID (пропускаем)
                    // 1 - price (цена)
                    // 2 - from (откуда)
                    // 3 - to (куда)
                    // 4 - timestart (время вылета)
                    // 5 - timeway (время прибытия)

                    string price = ticket_query.GetValue(2).ToString();  // цена
                    string from = ticket_query.GetValue(3).ToString();   // откуда
                    string to = ticket_query.GetValue(1).ToString();     // куда
                    string timestart = ticket_query.GetValue(4).ToString(); // время вылета
                    string timeway = ticket_query.GetValue(5).ToString();   // время прибытия

                    ticketClasses.Add(new TicketClass(
                        from,
                        to,
                        price,    
                        timestart,
                        timeway
                    ));

                    // Для отладки - проверим что читаем
                    System.Diagnostics.Debug.WriteLine($"Price: {price}, From: {from}, To: {to}, Departure: {timestart}, Arrival: {timeway}");
                }

                TicketContext = ticketClasses.Cast<TicketClass>().ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке билетов: {ex.Message}");
            }
            finally
            {
                mySqlConnection.Close();
            }
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            OpenPage(new Pages.Main());
        }
    }
}