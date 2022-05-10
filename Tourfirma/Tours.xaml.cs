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
    /// Логика взаимодействия для Page1.xaml
    /// </summary>

    public partial class Page1 : Page
    {
        public static int index = 0;
        private Tours _curretTours = new Tours();
        private Sales _curreSales = new Sales();
        int maxid = TourfirmEntities.GetContext().Sales.Max(u => u.Number_sale);
        public Page1()
        {
            InitializeComponent();
            LViewTours.ItemsSource = TourfirmEntities.GetContext().Tours.ToList();
            DataContext = _curreSales;
            DataContext = _curretTours;
            _curreSales.Price = 0;
            _curreSales.Number_tour = 0;
            _curreSales.Number_sale = maxid + 1;
            _curreSales.Number_client = Authorization.index;
            _curreSales.Date_sale = DateTime.Now.Date;
        }

        private void BtnPrev_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnHome_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Content = new User_menu();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            _curretTours = LViewTours.SelectedItems.Cast<Tours>().FirstOrDefault();
            if (_curretTours.Left > 0)
            {
                var Trs = TourfirmEntities.GetContext().Tours.Where(b => b.Number_tour == _curretTours.Number_tour).FirstOrDefault();
                Trs.Left = _curretTours.Left - 1;
                TourfirmEntities.GetContext().SaveChanges();
                _curreSales.Number_tour = _curretTours.Number_tour;
                _curreSales.Price += Convert.ToInt32(_curretTours.Price_tour);
                TourfirmEntities.GetContext().Sales.Add(_curreSales);

                try
                {
                    TourfirmEntities.GetContext().SaveChanges();
                    MessageBox.Show("Okey!");
                    _curreSales = new Sales();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
        string _SearchName;
        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            _SearchName = Search.Text;
            Tours SearchTours = null;
            SearchTours = TourfirmEntities.GetContext().Tours.Where(b => b.Name_tour == _SearchName).FirstOrDefault();

            if (SearchTours == null) MessageBox.Show("Не найдено");
            else
            {
                LViewTours.ItemsSource = TourfirmEntities.GetContext().Tours.Where(b => b.Name_tour == _SearchName).ToList();
            }
        }
    }
}
