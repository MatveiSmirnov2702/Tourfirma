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

namespace Tourfirma
{
    /// <summary>
    /// Логика взаимодействия для Admin_menu.xaml
    /// </summary>
    public partial class Admin_menu : Page
    {
        public Admin_menu()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Adtours_click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Content = new Tours_Admin();
        }

        private void AdSales_click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Content = new Sales_adm();
        }

        private void AdClients_click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Content = new Clients_adm();
        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void AdCities_click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Content = new Adm_cities();
        }
    }
}
