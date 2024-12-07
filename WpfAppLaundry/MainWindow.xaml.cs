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
using WpfAppLaundry.Pages;

namespace WpfAppLaundry
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            BaseFrame.Navigate(new MainPage());
        }
        private void Button_Back(object sender, RoutedEventArgs e)
        {
            BaseFrame.GoBack();
        }
        private void Button_QR(object sender, RoutedEventArgs e)
        {
            BaseFrame.Navigate(new QRPage());
        }
    }
}
