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
    /// Логика взаимодействия для Reg_Window.xaml
    /// </summary>
    public partial class Reg : Page
    {

        private Clients _currentClients = new Clients();
        int maxid = TourfirmEntities.GetContext().Clients.Max(u => u.Number_client);
        public Reg(Clients SelectClients)
        {
            InitializeComponent();
            if (SelectClients != null)
                _currentClients = SelectClients;
            DataContext = _currentClients;

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentClients.Client_login)) errors.AppendLine("Введите логин");
            if (string.IsNullOrWhiteSpace(_currentClients.Client_password)) errors.AppendLine("Введите пароль");
            if (string.IsNullOrWhiteSpace(_currentClients.Surname)) errors.AppendLine("Введите фамилию");
            if (string.IsNullOrWhiteSpace(_currentClients.Name)) errors.AppendLine("Введите имя");
            if (string.IsNullOrWhiteSpace(_currentClients.Patronymic)) errors.AppendLine("Введите отчество");
            if (string.IsNullOrWhiteSpace(_currentClients.Address)) errors.AppendLine("Введите адрес");
            if (string.IsNullOrWhiteSpace(_currentClients.Telephone_number)) errors.AppendLine("Введите телфон");
            if (_currentClients.Date_of_birth == null) errors.AppendLine("Введите дату");
            if (_currentClients.Passport_series == null) errors.AppendLine("Введите серию паспорта");
            if (_currentClients.Passport_number == null) errors.AppendLine("Введите номер паспорта");
            //проверка пороля:
            string str2; int i = 0; bool boo; int yes = 0;
            if (_currentClients.Client_password.Length < 6) errors.AppendLine("Пароль должен быть длиннее 6 символов");
            str2 = _currentClients.Client_password.ToLower();
            if (_currentClients.Client_password == str2) errors.AppendLine("В пароле должны быть большие буквы");
            char[] array = _currentClients.Client_password.ToCharArray();
            while (_currentClients.Client_password.Length > i)
            {
                boo = Char.IsDigit(array[i]);
                if (boo == true) yes = yes + 1;
                i = i + 1;
            }
            if (_currentClients.Client_password.Length <= yes) errors.AppendLine("Пароль должен включать буквы, большие и маленькие");
            if (yes == 0) errors.AppendLine("Пароль должен включать в себя цифры");
            if (errors.Length > 0) { MessageBox.Show(errors.ToString()); return; }


            _currentClients.Number_client = maxid + 1;
            TourfirmEntities.GetContext().Clients.Add(_currentClients);

            try
            {
                TourfirmEntities.GetContext().SaveChanges();
                MessageBox.Show("Okey!");
                Manager.MainFrame.Content = new User_menu();


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
