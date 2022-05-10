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
    /// Логика взаимодействия для Hotels_Users.xaml
    /// </summary>
    public partial class Hotels_Users : Page
    {
        public Hotels_Users()
        {
            InitializeComponent();
            LViewHotels.ItemsSource = TourfirmEntities.GetContext().Hotels.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void BtnHome_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Content = new User_menu();
        }
        string _SearchName;
        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {

            
                _SearchName = Search.Text;
                Hotels SearchHotels = null;
            SearchHotels = TourfirmEntities.GetContext().Hotels.Where(b => b.Name_of_hotel == _SearchName).FirstOrDefault();

                if (SearchHotels == null) MessageBox.Show("Не найдено");
                else
                {
                LViewHotels.ItemsSource = TourfirmEntities.GetContext().Hotels.Where(b => b.Name_of_hotel == _SearchName).ToList();
                }
            
        }
    }
}
