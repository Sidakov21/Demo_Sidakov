using KruzhokDemkaV2.Pages.Material;
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

namespace KruzhokDemkaV2.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : Page
    {
        public ProductsPage()
        {
            InitializeComponent();
            ProductsListBox.ItemsSource = Core.Context.Product.ToList();

            var productsTypes = Core.Context.ProductType.ToList();
            productsTypes.Insert(0, new ProductType { Name = "Все типы продукции" });
            ProductTypeComboBox.ItemsSource = productsTypes;

            if (Core.AuthUser == null)
            {
                SearchPanel.Visibility = Visibility.Collapsed;
                MaterialsPanel.Visibility = Visibility.Collapsed;
                return;
            }

            switch (Core.AuthUser.RoleID)
            {
                case 1:
                    MaterialsPanel.Visibility = Visibility.Collapsed;
                    break;
                case 3:
                    EditButtonsPanel.Visibility = Visibility.Collapsed;
                    break;
            }
        }

        private void Filter()
        {
            var filteredProducts = Core.Context.Product.ToList();

            if (!string.IsNullOrWhiteSpace(SearchTextBox.Text))
            {
                filteredProducts = filteredProducts
                    .Where(p => p.Name.ToLower().Contains(SearchTextBox.Text.ToLower()))
                    .ToList();
            }

            if (PriceSortComboBox.SelectedIndex == 1)
            {
                filteredProducts = filteredProducts.OrderBy(p => p.MinCost).ToList();
            }
            else if (PriceSortComboBox.SelectedIndex == 2)
            {
                filteredProducts = filteredProducts.OrderByDescending(p => p.MinCost).ToList();
            }

            if (ProductTypeComboBox != null && ProductTypeComboBox.SelectedIndex != 0)
            {
                filteredProducts = filteredProducts
                    .Where(p => p.ProductType == ProductTypeComboBox.SelectedItem as ProductType)
                    .ToList();
            }

            if (ProductsListBox != null)
            {
                ProductsListBox.ItemsSource = filteredProducts;
            }
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SearchTextBox.Text))
            {
                PlaceholderTextBlock.Visibility = Visibility.Visible;
            }
            else
            {
                PlaceholderTextBlock.Visibility = Visibility.Collapsed;
            }
            Filter();
        }

        private void PriceSortComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void ProductTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void MaterialsButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MaterialPage());
        }

        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditProductPage());
        }

        private void EditProductButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProductsListBox.SelectedItem is Product selectedProduct)
            {
                NavigationService.Navigate(new AddEditProductPage(selectedProduct));
            }
        }

        private void DeleteProductButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProductsListBox.SelectedItem is Product selectedProduct)
            {
                var messageBoxResult = MessageBox.Show("Вы точно хотите удалить товар?", "Удалить", 
                    MessageBoxButton.YesNo);

                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    foreach (var pm in selectedProduct.ProductMaterial.ToList())
                    {
                        Core.Context.ProductMaterial.Remove(pm);
                    }

                    Core.Context.Product.Remove(selectedProduct);
                    Core.Context.SaveChanges();

                    Filter();
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
