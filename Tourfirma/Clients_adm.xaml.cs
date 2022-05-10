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
    /// Логика взаимодействия для Clients_adm.xaml
    /// </summary>
    public partial class Clients_adm : Page
    {
        public Clients_adm()
        {
            InitializeComponent();
            DGridClients.ItemsSource = TourfirmEntities.GetContext().Clients.ToList();
        }

        private void BtnBack_click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Content = new Admin_menu();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Content = new Reg(null);
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }
    }
}
