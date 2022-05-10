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
    /// Логика взаимодействия для AddPage.xaml
    /// </summary>
    public partial class AddPage : Page
    {
        private Tours _curretTours = new Tours();

        int maxid = TourfirmEntities.GetContext().Tours.Max(u => u.Number_tour);
        int maxHotelid = TourfirmEntities.GetContext().Hotels.Max(u => u.Number_hotel);
        public AddPage()
        {
            InitializeComponent();
            DataContext = _curretTours;

            ComboTypeFood.ItemsSource = TourfirmEntities.GetContext().Type_food.ToList();
            ComboNameHotel.ItemsSource = TourfirmEntities.GetContext().Hotels.ToList();
            ComboTypeTour.ItemsSource = TourfirmEntities.GetContext().Type_tours.ToList();
        }

        private void BtnSave(object sender, RoutedEventArgs e)
        {
            string _SearchName;
            _SearchName = ComboNameHotel.Text;
            Hotels SearchType = null;
            SearchType = TourfirmEntities.GetContext().Hotels.Where(b => b.Name_of_hotel == _SearchName).FirstOrDefault();
            _curretTours.Number_hotel = SearchType.Number_hotel;
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_curretTours.Name_tour)) errors.AppendLine("Введите название");
            if (_curretTours.Start_date == null) errors.AppendLine("Введите дату начала");
            if (_curretTours.End_date == null) errors.AppendLine("Введите дату конца");
            _curretTours.Number_tour = maxid + 1;
            TourfirmEntities.GetContext().Tours.Add(_curretTours);
            if (errors.Length > 0) { MessageBox.Show(errors.ToString()); 
                return; 
            }
        
            try
            {
                TourfirmEntities.GetContext().SaveChanges();
                MessageBox.Show("Okey!");
                _curretTours = new Tours();
                Manager.MainFrame.Content = new Tours_Admin();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
            

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }
    }
}
