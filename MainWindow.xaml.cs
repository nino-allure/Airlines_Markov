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
using Airlines_Markov.Pages;

namespace Airlines_Markov
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow init;
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
        private void Exit (object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public List<TicketClass> ticketClasses = new List<TicketClass>();

        private void Back(object sender, RoutedEventArgs e)
        {
            OpenPage(new Pages.Main());
        }
    }
}
