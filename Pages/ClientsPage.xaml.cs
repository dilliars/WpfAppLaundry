using System.Windows.Controls;

namespace LaundryApp
{
    public partial class ClientsPage : Page
    {
        public ClientsPage()
        {
            InitializeComponent();
            LoadClients();
        }

        private void LoadClients()
        {
            // Заглушка для загрузки данных о клиентах
            ClientsDataGrid.ItemsSource = new[]
            {
                new { FullName = "Иван Иванов", Phone = "+79111111111", Email = "ivanov@example.com" },
                new { FullName = "Петр Петров", Phone = "+79222222222", Email = "petrov@example.com" }
            };
        }

        private void OnAddClient_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // Открытие окна добавления клиента
            var addClientWindow = new AddClientWindow();
            addClientWindow.ShowDialog();
        }
    }
}
