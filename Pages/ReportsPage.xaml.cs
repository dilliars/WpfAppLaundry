using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using WpfAppLaundry.ModelDB;

namespace LaundryApp
{
    public partial class ReportsPage : Page
    {
        public ReportsPage()
        {
            InitializeComponent();
        }

        private void GenerateReportButton_Click(object sender, RoutedEventArgs e)
        {
            if (ReportTypeComboBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите тип отчета!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string selectedReportType = (ReportTypeComboBox.SelectedItem as ComboBoxItem).Content.ToString();

          
                if (selectedReportType == "По клиентам")
                {
                    var clientReport = App.db.Clients
                        .Select(c => new
                        {
                            c.ClientID,
                            c.FullName,
                            c.Phone,
                            c.Email,
                            TotalOrders = App.db.Orders.Count(o => o.ClientID == c.ClientID)
                        })
                        .ToList();

                    ReportDataGrid.ItemsSource = clientReport;
                }
                else if (selectedReportType == "По заказам")
                {
                    var orderReport = App.db.Orders
                        .Select(o => new
                        {
                            o.OrderID,
                            ClientName = App.db.Clients.FirstOrDefault(c => c.ClientID == o.ClientID).FullName,
                            o.ItemType,
                            o.Quantity,
                            o.Weight,
                            o.OrderDate,
                            Status = App.db.Statuses.FirstOrDefault(s => s.StatusID == o.StatusID).Name
                        })
                        .ToList();

                    ReportDataGrid.ItemsSource = orderReport;
                }
            
        }

        private void ExportToCsvButton_Click(object sender, RoutedEventArgs e)
        {
            if (ReportDataGrid.ItemsSource == null)
            {
                MessageBox.Show("Отчет не сформирован!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "CSV файлы (*.csv)|*.csv",
                Title = "Сохранить отчет"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                try
                {
                    var data = ReportDataGrid.ItemsSource;
                    StringBuilder csvContent = new StringBuilder();

                    // Заголовки
                    var headers = ReportDataGrid.Columns.Select(col => col.Header.ToString());
                    csvContent.AppendLine(string.Join(";", headers));

                    // Данные
                    foreach (var item in data)
                    {
                        var properties = item.GetType().GetProperties();
                        var row = properties.Select(prop => prop.GetValue(item)?.ToString());
                        csvContent.AppendLine(string.Join(";", row));
                    }

                    File.WriteAllText(saveFileDialog.FileName, csvContent.ToString(), Encoding.UTF8);
                    MessageBox.Show("Отчет успешно экспортирован!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при экспорте отчета: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
