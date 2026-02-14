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
using Airlines_Markov.Element;

namespace Airlines_Markov.Pages
{
    public partial class Ticket : Page
    {
        public Ticket(string from, string to, string depTime, string arrTime)
        {
            InitializeComponent();

            SearchInfoLabel.Content = $"{from} → {to}";

            try
            {
                MainWindow.init.LoadTickets();

                var tickets = MainWindow.init.ticketClasses
                    .Where(t => t.from.Contains(from) && t.to.Contains(to))
                    .ToList();

                TicketsStackPanel.Children.Clear();

                foreach (var ticket in tickets)
                {
                    // Проверяем время вылета
                    if (ticket.timestart.Contains(depTime))
                    {
                        var item = new Item();
                        item.SetTicketData(ticket);
                        TicketsStackPanel.Children.Add(item);
                    }
                    // Проверяем время прилета
                    else if (ticket.timeway.Contains(arrTime))
                    {
                        var item = new Item();
                        item.SetTicketData(ticket);
                        TicketsStackPanel.Children.Add(item);
                    }
                }

                if (TicketsStackPanel.Children.Count == 0)
                {
                    NoTicketsMessage.Visibility = Visibility.Visible;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }
    }
}
