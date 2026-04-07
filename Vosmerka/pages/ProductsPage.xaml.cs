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
    /// Логика взаимодействия для ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : Page
    {
        public ProductsPage()
        {
            InitializeComponent();
            //ProductsListBox.ItemsSource = Core.Context.Product.ToList(); //Здесь у нас должны быть прописаны продукты в БД
            ProductsListBox.ItemsSource = Core.Context.Role.ToList(); //Используем на время

            var productTypes = Core.Context.Role.ToList(); // Вместо Role ProductType
            productTypes.Insert(0, new Role { RoleName = "Все типы продукции" }); //Здесь тоже самое ProductType
            ProductTypeComboBox.ItemsSource = productTypes;

            if (Core.AuthUser == null)
            {
                SearchPanel.Visibility = Visibility.Collapsed;
                MaterialsPanel.Visibility = Visibility.Collapsed;
                return;
            }

            switch (Core.AuthUser.RoleId)
            {
                case 1:
                    MaterialsPanel.Visibility = Visibility.Collapsed;
                    break;
                case 3:
                    EditButtonsPanel.Visibility = Visibility.Collapsed;
                    break;
            }
        }

        private void PriceSortComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ProductTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MaterialsButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteProductButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditProductButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
