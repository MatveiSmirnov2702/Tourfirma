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
    /// Логика взаимодействия для Sales_adm.xaml
    /// </summary>
    public partial class Sales_adm : Page
    {
        public Sales_adm()
        {
            InitializeComponent();
            DGridSales.ItemsSource = TourfirmEntities.GetContext().Sales.ToList();
        }
                

        

    private void BtnAdd_Click(object sender, RoutedEventArgs e)
    {

    }

    private void BtnDelete_Click(object sender, RoutedEventArgs e)
    {
            var SalesForRemoving = DGridSales.SelectedItems.Cast<Sales>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {SalesForRemoving.Count()} элементов?", "Внимание!",
            MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    TourfirmEntities.GetContext().Sales.RemoveRange(SalesForRemoving);
                    TourfirmEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    DGridSales.ItemsSource = TourfirmEntities.GetContext().Sales.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

    private void BtnBack_click(object sender, RoutedEventArgs e)
    {
            Manager.MainFrame.Content = new Admin_menu();
    }
    private void BtnEdit_Click(object sender, RoutedEventArgs e)
    {

    }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }
    }
}
