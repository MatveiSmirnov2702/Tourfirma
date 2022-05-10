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
    /// Логика взаимодействия для Adm_cities.xaml
    /// </summary>
    public partial class Adm_cities : Page
    {
        public Adm_cities()
        {
            InitializeComponent();
            DGridCities.ItemsSource = TourfirmEntities.GetContext().Cities.ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {

        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnBack_click(object sender, RoutedEventArgs e)
        {

        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }
    }
}
