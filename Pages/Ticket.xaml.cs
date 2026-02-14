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
    /// <summary>
    /// Логика взаимодействия для Ticket.xaml
    /// </summary>
    public partial class Ticket : Page
    {
        private string searchFrom;
        private string searchTo;

        public Ticket(string From, string To)
        {
            InitializeComponent();

            searchFrom = From;
            searchTo = To;

            // Обновляем заголовок с информацией о поиске
            SearchInfoLabel.Content = $"Результаты поиска: {From}  {To}";

            // Загружаем и отображаем билеты
            LoadAndDisplayTickets();
        }

        private void LoadAndDisplayTickets()
        {
            try
            {
                // Загружаем билеты из БД
                MainWindow.init.LoadTickets();

                // Фильтруем билеты по направлениям (без учета регистра)
                var filteredTickets = MainWindow.init.ticketClasses
                    .Where(t => t.from.IndexOf(searchFrom, StringComparison.OrdinalIgnoreCase) >= 0 &&
                                t.to.IndexOf(searchTo, StringComparison.OrdinalIgnoreCase) >= 0)
                    .ToList();

                // Очищаем StackPanel перед добавлением новых элементов
                TicketsStackPanel.Children.Clear();

                if (filteredTickets.Any())
                {
                    // Скрываем сообщение "Билеты не найдены"
                    NoTicketsMessage.Visibility = Visibility.Collapsed;

                    // Добавляем каждый билет в StackPanel
                    foreach (var ticket in filteredTickets)
                    {
                        // Создаем новый элемент билета
                        var ticketItem = new Item();

                        // Здесь нужно передать данные билета в элемент Item
                        // Для этого нужно добавить метод или свойство в Item.xaml.cs
                        ticketItem.SetTicketData(ticket);

                        TicketsStackPanel.Children.Add(ticketItem);
                    }
                }
                else
                {
                    // Показываем сообщение, если билеты не найдены
                    NoTicketsMessage.Visibility = Visibility.Visible;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке билетов: {ex.Message}", "Ошибка",
                              MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            // Возврат на главную страницу
            MainWindow.init.OpenPage(new Main());
        }
    }
}
