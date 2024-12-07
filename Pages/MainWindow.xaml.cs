using System.Windows;

namespace LaundryApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnClientsMenu_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ClientsPage());
        }

        private void OnOrdersMenu_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new OrdersPage());
        }

        private void OnStatusesMenu_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new StatusesPage());
        }

        private void OnReportsMenu_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ReportsPage());
        }
    }
}
