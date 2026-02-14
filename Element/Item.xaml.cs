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
    public partial class Item : UserControl
    {
        public Item()
        {
            InitializeComponent();
        }

        public void SetTicketData(TicketClass ticket)
        {
            PriceLabel.Content = $"{ticket.price} Р";
            FromCityLabel.Content = ticket.from;
            ToCityLabel.Content = ticket.to;
            FromTimeLabel.Content = ticket.timestart;
            ToTimeLabel.Content = ticket.timeway;
            AirlineLabel.Content = "Аэрофлот";
        }
    }
}