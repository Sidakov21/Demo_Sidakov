using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Логика взаимодействия для AddEditProductPage.xaml
    /// </summary>
    public partial class AddEditProductPage : Page
    {
        public Product CurrentProduct { get; set; }

        public AddEditProductPage()
        {
            InitializeComponent();
            ProductTypeComboBox.ItemsSource = Core.Context.ProductType.ToList();
            DataContext = CurrentProduct;
        }

        public AddEditProductPage(Product product)
        {
            InitializeComponent();
            CurrentProduct = product;
            ProductTypeComboBox.ItemsSource = Core.Context.ProductType.ToList();
            DataContext = CurrentProduct;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameTextBox.Text)
                || string.IsNullOrWhiteSpace(ArticleTextBox.Text)
                || string.IsNullOrWhiteSpace(MinCostTextBox.Text)
                || string.IsNullOrWhiteSpace(HumanTextBox.Text)
                || string.IsNullOrWhiteSpace(ProductPlaseTextBox.Text)
                || ProductTypeComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Укажите все данные!");
                return;
            }

            if (CurrentProduct == null)
            {
                CurrentProduct = new Product
                {
                    ProductName = NameTextBox.Text,
                    Article = ArticleTextBox.Text,
                    MinCost = Convert.ToInt32(MinCostTextBox.Text, CultureInfo.InvariantCulture),
                    Image = ImageTextBox.Text,
                    ProductType = ProductTypeComboBox.SelectedItem as ProductType,
                    HumanResourses = Convert.ToInt32(HumanTextBox.Text),
                    ProductPlaseId = Convert.ToInt32(ProductPlaseTextBox.Text)
                };
                Core.Context.Product.Add(CurrentProduct);
                Core.Context.SaveChanges();
            }
            else
            {
                CurrentProduct.ProductName = NameTextBox.Text;
                CurrentProduct.Article = ArticleTextBox.Text;
                CurrentProduct.MinCost = Convert.ToInt32(MinCostTextBox.Text, CultureInfo.InvariantCulture);
                CurrentProduct.Image = ImageTextBox.Text;
                CurrentProduct.ProductType = ProductTypeComboBox.SelectedItem as ProductType;
                CurrentProduct.HumanResourses = Convert.ToInt32(HumanTextBox.Text);
                CurrentProduct.ProductPlaseId = Convert.ToInt32(ProductPlaseTextBox.Text);

                Core.Context.SaveChanges();
            }

            NavigationService.GoBack();
        }

    }
}
