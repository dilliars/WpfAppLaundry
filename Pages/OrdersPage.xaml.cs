using System.Windows;
using System.Linq;
using System.Windows.Controls;

namespace LaundryApp
{
    public partial class OrdersPage : Page
    {
        public OrdersPage()
        {
            InitializeComponent();
            LoadOrders();
        }

        private void LoadOrders()
        {
            // Загрузка списка заказов из базы данных
            using (var context = new LaundryDbContext())
            {
                var orders = context.Orders
                    .Select(o => new
                    {
                        o.OrderID,
                        ClientName = o.Client.FullName,
                        o.ItemType,
                        o.Quantity,
                        o.Weight,
                        o.ItemCondition,
                        o.Wishes,
                        o.OrderDate,
                        Status = o.Status.Name
                    })
                    .ToList();

                OrdersDataGrid.ItemsSource = orders;
            }
        }

        private void AddOrderButton_Click(object sender, RoutedEventArgs e)
        {
            var addOrderWindow = new AddOrderWindow();
            if (addOrderWindow.ShowDialog() == true)
            {
                LoadOrders(); // Обновляем список заказов после добавления
            }
        }
    }
}