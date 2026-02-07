using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airlines_Markov.Pages;
using MySql.Data.MySqlClient;
using Airlines_Markov.Classes;

namespace Airlines_Markov.Classes2
{
    public class Context : TicketClass
    {
        public Context(string price, string from, string to, string timestart, string timeway) : base(price, from, to, timestart, timeway) { }


        public static List<Context> AllTickets()
        {
            List<Context> allTickets = new List<Context>();

            MySqlConnection connection = new MySqlConnection("server=127.0.0.1;database=Airlines;uid=root;pwd=;");
            connection.Open();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `tickets`;", connection);
            MySqlDataReader ticketQuery = command.ExecuteReader();
            while (ticketQuery.Read())
            {
                allTickets.Add(new Context(
                    ticketQuery.GetInt32(0).ToString(),
                    ticketQuery.GetValue(1).ToString(),
                    ticketQuery.GetValue(2).ToString(),
                    ticketQuery.GetValue(3).ToString(),
                    ticketQuery.GetValue(4).ToString()
                    ));
            }

            connection.Close();
            MySqlConnection.ClearPool(connection);
            return allTickets;  
        }
    }
}
