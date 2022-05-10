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
    /// Логика взаимодействия для User_menu.xaml
    /// </summary>
    public partial class User_menu : Page
    {
        public User_menu()
        {
            InitializeComponent();
        }
        private void Tour_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Content = new Page1();
        }
        private void Sales_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Content = new Sales_user();
        }
        private void InfHot_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Content = new Hotels_Users();
        }
       
        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Content = new Authorization();
        }
    }
}
