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

namespace Vosmerka.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent(); //Comment
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LoginTextBox.Text))
            {
                MessageBox.Show("Введите логин!");
                return;
            }

            if (string.IsNullOrEmpty(LoginTextBox.Text))
            {
                MessageBox.Show("Введите пароль!");
                return;
            }

            var user = Core.Context.User.FirstOrDefault(u => 
                u.Login == LoginTextBox.Text && u.Password == PassBox.Password);

            if (user == null)
            {
                MessageBox.Show("Пользователь с такими данными не найден!");
                return;
            }

            Core.AuthUser = user;
            NavigationService.Navigate(new ProductsPage());
        }

        private void ProductsButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProductsPage());
        }
    }
}
