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
    /// Логика взаимодействия для Sales_user.xaml
    /// </summary>
    public partial class Sales_user : Page
    {
        public Sales_user()
        {
            InitializeComponent();

            int _SearchCode = Authorization.index;
            var sum = 0;
            Sales SearchGood = null;
            SearchGood = TourfirmEntities.GetContext().Sales.Where(b => b.Number_client == _SearchCode).FirstOrDefault();
            if (SearchGood == null) DGridSales.ItemsSource = "Вы ещё не делали заказов";
            else
            {
                DGridSales.ItemsSource = TourfirmEntities.GetContext().Sales.Where(b => b.Number_client == _SearchCode).ToList();
                List<Sales> sales = TourfirmEntities.GetContext().Sales.Where(b => b.Number_client == _SearchCode).ToList();
                DGridSales.ItemsSource = sales;
                sum = Convert.ToInt32(sales.Sum(x => x.Price));
                SumTXT.Text = sum.ToString() + "РУБ";
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnBack_click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Content = new User_menu();
        }

        private void DGridSales_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            int _SearchCode = Authorization.index;
            Sales SearchGood = null;
            SearchGood = TourfirmEntities.GetContext().Sales.Where(b => b.Number_client == _SearchCode).FirstOrDefault();
            var SalesForRemoving = DGridSales.SelectedItems.Cast<Sales>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {SalesForRemoving.Count()} элементов?", "Внимание!",
            MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    TourfirmEntities.GetContext().Sales.RemoveRange(SalesForRemoving);
                    TourfirmEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    DGridSales.ItemsSource = TourfirmEntities.GetContext().Sales.Where(b => b.Number_client == _SearchCode).ToList();
                    List<Sales> sales = TourfirmEntities.GetContext().Sales.Where(b => b.Number_client == _SearchCode).ToList();
                    DGridSales.ItemsSource = sales;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
    
}
