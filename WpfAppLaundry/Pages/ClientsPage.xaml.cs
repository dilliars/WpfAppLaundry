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
using WpfAppLaundry.ModelDB;

namespace WpfAppLaundry.Pages
{
    /// <summary>
    /// Логика взаимодействия для ClientsPage.xaml
    /// </summary>
    public partial class ClientsPage : Page
    {
        private List<Clients> clientsList;

        public ClientsPage()
        {
            InitializeComponent();
            clientsList = App.db.Clients.ToList();
            ClientsDG.ItemsSource = clientsList;
        }
        //private void TextBox_SurnameSearch(object sender, TextChangedEventArgs e)
        //{
        //    var text = ((TextBox)sender).Text;
        //    ClientsDG.ItemsSource = null;

        //    if (string.IsNullOrWhiteSpace(text))
        //        ClientsDG.ItemsSource = clientsList;
        //    else
        //        ClientsDG.ItemsSource = clientsList.Where(i => i.FullName.ToLower().Contains(text));

        //}
        private void ComboBox_Sorting(object sender, SelectionChangedEventArgs e)
        {
            if (ClientsDG == null) return;
            var comboBox = sender as ComboBox;
            if (comboBox.SelectedIndex == -1)
                return;
            ClientsDG.ItemsSource = null;
            switch (comboBox.SelectedIndex)
            {
                case 0:
                    ClientsDG.ItemsSource = clientsList;
                    break;
                case 1:
                    ClientsDG.ItemsSource = clientsList.OrderBy(i => i.FullName);
                    break;
                case 2:
                    ClientsDG.ItemsSource = clientsList.OrderBy(i => i.Address);
                    break;
            }
        }
        private void TextBox_FullName(object sender, TextChangedEventArgs e)
        {
            var text = ((TextBox)sender).Text;
            var tb = ((Clients)((TextBox)sender).DataContext);

            tb.FullName = text;
            App.db.SaveChanges();

        }
        private void TextBox_Phone(object sender, TextChangedEventArgs e)
        {
            var text = ((TextBox)sender).Text;
            var tb = ((Clients)((TextBox)sender).DataContext);

            tb.Phone = text;
            App.db.SaveChanges();
        }
        private void TextBox_Email(object sender, TextChangedEventArgs e)
        {
            var text = ((TextBox)sender).Text;
            var tb = ((Clients)((TextBox)sender).DataContext);

            tb.Email = text;
            App.db.SaveChanges();
        }
        private void TextBox_Address(object sender, TextChangedEventArgs e)
        {
            var text = ((TextBox)sender).Text;
            var tb = ((Clients)((TextBox)sender).DataContext);

            tb.Address = text;
            App.db.SaveChanges();
        }
        private void TextBox_Preferences(object sender, TextChangedEventArgs e)
        {
            var text = ((TextBox)sender).Text;
            var tb = ((Clients)((TextBox)sender).DataContext);

            tb.Preferences = text;
            App.db.SaveChanges();
        }
        private void Button_Add(object sender, System.Windows.RoutedEventArgs e)
        {
            var user = new Clients();
            //user.ClientID = App.client.ClientID;

            App.db.SaveChanges();
            App.db.Clients.Add(user);

            ClientsDG.ItemsSource = null;
            ClientsDG.ItemsSource = clientsList;

            MessageBox.Show("Клиент добавлен!");
            ClientsDG.ItemsSource = App.db.Clients.ToList();
        }
        private void Button_Remove(object sender, System.Windows.RoutedEventArgs e)
        {
            var selected = (ClientsDG.SelectedItem as Clients);

            if (selected != null)
            {
                App.db.Clients.Remove(selected);
                App.db.SaveChanges();

                ClientsDG.ItemsSource = null;
                clientsList = App.db.Clients.ToList();

                ClientsDG.ItemsSource = clientsList;
                MessageBox.Show("Клиент удален!");
            }
        }
    }
}
