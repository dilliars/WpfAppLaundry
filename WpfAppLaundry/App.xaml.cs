using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfAppLaundry.ModelDB;

namespace WpfAppLaundry
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static LaundryEntities db = new LaundryEntities();
        public static Clients client;
    }
}
