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

namespace Airlines_Markov.Element
{
    /// <summary>
    /// Логика взаимодействия для Item.xaml
    /// </summary>
    public partial class Item : UserControl
    {
        public Item()
        {
            InitializeComponent();
        }

        public void SetTicketData(TicketClass ticket)
        {
            // Для отладки
            System.Diagnostics.Debug.WriteLine($"SetTicketData - Price: {ticket.price}, From: {ticket.from}, To: {ticket.to}, Start: {ticket.timestart}, Way: {ticket.timeway}");

            // Цена - из индекса 1
            PriceLabel.Content = $"{ticket.price} Р";

            // Откуда (город) - из индекса 2
            FromCityLabel.Content = ticket.from;

            // Куда (город) - из индекса 3
            ToCityLabel.Content = ticket.to;

            // Время вылета - из индекса 4
            FromTimeLabel.Content = ticket.timestart;

            // Время прибытия - из индекса 5
            ToTimeLabel.Content = ticket.timeway;

            // Если время вылета содержит дату и время (например "2025-09-29 05:50")
            if (ticket.timestart.Contains(" "))
            {
                var parts = ticket.timestart.Split(' ');
                if (parts.Length >= 2)
                {
                    FromDateLabel.Content = parts[0]; // Дата
                    FromTimeLabel.Content = parts[1]; // Время
                }
            }

            // Если время прибытия содержит дату и время
            if (ticket.timeway.Contains(" "))
            {
                var parts = ticket.timeway.Split(' ');
                if (parts.Length >= 2)
                {
                    ToDateLabel.Content = parts[0]; // Дата
                    ToTimeLabel.Content = parts[1]; // Время
                }
            }

            // Название авиакомпании (пока заглушка)
            AirlineLabel.Content = "Аэрофлот";

            // Расчет времени в пути (можно добавить позже)
            TravelTimeLabel.Content = "В пути: 2ч 15м";
        }
    }
}