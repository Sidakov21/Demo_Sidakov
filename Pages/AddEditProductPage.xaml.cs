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

namespace KruzhokDemkaV2.Pages
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
                || string.IsNullOrWhiteSpace(PriceTextBox.Text)
                || string.IsNullOrWhiteSpace(WorkersTextBox.Text)
                || string.IsNullOrWhiteSpace(WorkshopTextBox.Text)
                || ProductTypeComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Укажите все данные!");
                return;
            }

            if (CurrentProduct == null)
            {
                CurrentProduct = new Product
                {
                    Name = NameTextBox.Text,
                    Article = ArticleTextBox.Text,
                    MinCost = decimal.Parse(PriceTextBox.Text, CultureInfo.InvariantCulture),
                    ImagePath = ImageTextBox.Text,
                    ProductType = ProductTypeComboBox.SelectedItem as ProductType,
                    WorkersRequired = Convert.ToInt32(WorkersTextBox.Text),
                    WorkshopID = Convert.ToInt32(WorkshopTextBox.Text)
                };
                Core.Context.Product.Add(CurrentProduct);
                Core.Context.SaveChanges();
            }
            else
            {
                CurrentProduct.Name = NameTextBox.Text;
                CurrentProduct.Article = ArticleTextBox.Text;
                CurrentProduct.MinCost = decimal.Parse(PriceTextBox.Text, CultureInfo.InvariantCulture);
                CurrentProduct.ImagePath = ImageTextBox.Text;
                CurrentProduct.ProductType = ProductTypeComboBox.SelectedItem as ProductType;
                CurrentProduct.WorkersRequired = Convert.ToInt32(WorkersTextBox.Text);
                CurrentProduct.WorkshopID = Convert.ToInt32(WorkshopTextBox.Text);

                Core.Context.SaveChanges();
            }

            NavigationService.GoBack();
        }
    }
}
