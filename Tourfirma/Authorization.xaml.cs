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
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        public static int index = 0;
        string _login, _password;
        public Authorization()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Clients Clients = null;

            _login = LoginText.Text;
            _password = PasswordText.Password;
            Clients = TourfirmEntities.GetContext().Clients.Where(b => b.Client_password == _password && b.Client_login == _login).FirstOrDefault();

            if (Clients == null) MessageBox.Show("Не найдено");
            else
            {
                MessageBox.Show("Вход выполнен");
                index = Clients.Number_client;
                Manager.MainFrame.Content = new User_menu();
            }

        }
        private void Admin_Click(object sender, RoutedEventArgs e)
        {
            Admins User = null;

            _login = LoginText.Text;
            _password = PasswordText.Password;
            User = TourfirmEntities.GetContext().Admins.Where(b => b.Admin_Password == _password && b.Admin_Login == _login).FirstOrDefault();

            if (User == null) MessageBox.Show("Не найдено");
            else
            {
                MessageBox.Show("Вход выполнен");
                index = -1;
                Manager.MainFrame.Content = new Admin_menu();
            }
        }
        private void Registr_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Content = new Reg(null);
        }
        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }
        private void Home_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Content = null;
        }
    }
}
