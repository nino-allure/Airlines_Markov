using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airlines_Markov.Classes
{
    public class TicketClass
    {
        public string price {  get; set; } 
        public string from { get; set; }   
        public string to { get; set; } 
        public string timestart { get; set; }
        public string timeway { get; set; }

        public TicketClass(string price, string from, string to, string timestart, string timeway)
        {
            this.price = price;
            this.from = from;
            this.to = to;
            this.timestart = timestart;
            this.timeway = timeway;
        }
    }
}
