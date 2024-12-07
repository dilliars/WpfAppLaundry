using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace LaundryApp
{
    public partial class StatusesPage : Page
    {
        public StatusesPage()
        {
            InitializeComponent();
            LoadStatuses();
        }

        private void LoadStatuses()
        {
            
                // Загрузка списка статусов из базы данных
                var statuses = context.Statuses
                    .Select(s => new
                    {
                        s.StatusID,
                        s.Name
                    })
                    .ToList();

                StatusesDataGrid.ItemsSource = statuses;
            
        }

        private void AddStatusButton_Click(object sender, RoutedEventArgs e)
        {
            var addStatusWindow = new AddStatusWindow();
            if (addStatusWindow.ShowDialog() == true)
            {
                LoadStatuses(); // Обновляем список статусов после добавления
            }
        }
    }
}