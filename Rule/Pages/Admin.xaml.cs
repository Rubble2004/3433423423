using Rule.Classes;
using Rule.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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

namespace Rule
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Page
    {
        public Admin()
        {
            InitializeComponent();
            connect.modelbd = new model.turagentsEntities();
        }

        private void Vxod(object sender, RoutedEventArgs e)
        {
            var userObj = connect.modelbd.users.FirstOrDefault(x =>x.login == login.Text && x.password == passwordBox.Password);
            ///if(userObj == null)
            ///if (login.Text == "root" && password.Text == "12345")
            if (userObj == null)
            {
                MessageBox.Show("Такого пользователя нет!", "Ошибка при авторизации",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("Здравствуйте " + userObj.login, "Уведомление",
                   MessageBoxButton.OK, MessageBoxImage.Information);
                switch (userObj.id_type)
                {
                    case 1:
                        Manager.MainFrame.Navigate(new adminik());
                        break;
                    
                    case 3:
                        Manager.MainFrame.Navigate(new Katalog());
                        break;
                    default:
                        MessageBox.Show("Данные не обнаружены!", "Уведомление",
                MessageBoxButton.OK, MessageBoxImage.Warning);
                        break;


                }
            }
        }
        private void Checked(object sender, RoutedEventArgs e)
        {
            passwordBox.Visibility = Visibility.Collapsed;
            password.Visibility = Visibility.Visible;
            password.Text = passwordBox.Password;
        }

        private void Unchecked(object sender, RoutedEventArgs e)
        {
            passwordBox.Visibility = Visibility.Visible;
            password.Visibility = Visibility.Collapsed;
        }
    }
}
