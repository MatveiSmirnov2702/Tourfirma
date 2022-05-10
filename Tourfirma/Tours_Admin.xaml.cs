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
    /// Логика взаимодействия для Tours_Admin.xaml
    /// </summary>
    public partial class Tours_Admin : Page
    {
        public Tours_Admin()
        {
            InitializeComponent();
            DGridTours.ItemsSource = TourfirmEntities.GetContext().Tours.ToList();
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var toursForRemoving = DGridTours.SelectedItems.Cast<Tours>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {toursForRemoving.Count()} элементов?", "Внимание!",
            MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    TourfirmEntities.GetContext().Tours.RemoveRange(toursForRemoving);
                    TourfirmEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    DGridTours.ItemsSource = TourfirmEntities.GetContext().Tours.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Content = new AddPage();
            
        }
        private void BtnBack_click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Content = new Admin_menu();

        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }
    }
}
