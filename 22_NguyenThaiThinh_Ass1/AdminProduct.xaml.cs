using _22_NguyenThaiThinh_Ass1.DataAccess;
using _22_NguyenThaiThinh_Ass1.Repository;
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
using System.Windows.Shapes;

namespace _22_NguyenThaiThinh_Ass1
{
    /// <summary>
    /// Interaction logic for AdminProduct.xaml
    /// </summary>
    public partial class AdminProduct : Window
    {

        private readonly IMemberRepository _memberRepository;
        private readonly IProductRepository _productRepository;
        public AdminProduct(IMemberRepository memberRepository, IProductRepository productRepository)
        {
            InitializeComponent();
            _memberRepository = memberRepository;
            _productRepository = productRepository;
            CateItems.ItemsSource = _productRepository.GetCategories();
            CateItems.SelectedIndex = 0;
        }
        private void ComboBox_Change(object sender, SelectionChangedEventArgs e)
        {
            txtCategoryId.DataContext = CateItems.SelectedItem;
        }
        private void Selection_Change(object sender, SelectionChangedEventArgs e)
        {
            txtCategoryId.DataContext = lvProducts.SelectedItem;
            if (txtCategoryId.Text == "")
                return;
            foreach (Category c in CateItems.ItemsSource)
            {
                if(c.CategoryId == int.Parse(txtCategoryId.Text))
                {
                    CateItems.SelectedItem = c;
                }
            }
        }
        private Product GetProductObject()
        {
            Product product = null;
            try
            {
                product = new Product
                {
                    ProductId = int.Parse(txtProductId.Text),
                    ProductName = txtProductName.Text,
                    CategoryId = int.Parse(txtCategoryId.Text),
                    Weight = txtWeight.Text,
                    UnitPrice = Decimal.Parse(txtUnitPrice.Text),
                    UnitInStock = int.Parse(txtUnitInStock.Text),

                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "GetProduct");
            }
            return product;
        }
        private Product GetProductObjectToAdd()
        {
            Product product = null;
            try
            {
                product = new Product
                {
                    ProductName = txtProductName.Text,
                    CategoryId = int.Parse(txtCategoryId.Text),
                    Weight = txtWeight.Text,
                    UnitPrice = Decimal.Parse(txtUnitPrice.Text),
                    UnitInStock = int.Parse(txtUnitInStock.Text),

                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "GetProduct");
            }
            return product;
        }
        public void LoadProductList()
        {
            lvProducts.ItemsSource = _productRepository.GetProducts();
        }
        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadProductList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Product product = GetProductObjectToAdd();

                // Show a confirmation dialog
                MessageBoxResult result = MessageBox.Show($"Are you sure you want to insert product {product.ProductName}?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    _productRepository.Insert(product);
                    LoadProductList();
                    MessageBox.Show($"{product.ProductName} insert Successfully ", "Insert Product");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Product product = GetProductObject();

                // Show a confirmation dialog
                MessageBoxResult result = MessageBox.Show($"Are you sure you want to update product {product.ProductName}?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    _productRepository.Update(product);
                    LoadProductList();
                    MessageBox.Show($"{product.ProductName} Update Successfully ", "Update Product");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Product product = GetProductObject();

                // Show a confirmation dialog
                MessageBoxResult result = MessageBox.Show($"Are you sure you want to delete product {product.ProductName}?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    _productRepository.Delete(product);
                    LoadProductList();
                    MessageBox.Show($"{product.ProductName} Delete Successfully ", "Delete Product");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void Back_Click(object sender, RoutedEventArgs e)
        {
            AdminMenu adminMenu = new AdminMenu(_memberRepository, _productRepository);
            adminMenu.Show();
            this.Close();
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                var dbcontext = new Ass1_Prn221_Bl5Context();
                var query = dbcontext.Products.Where(p => p.ProductName.Contains(SearchName.Text)).ToList();

                if (!string.IsNullOrEmpty(SearchPrice.Text))
                {
                    // Convert input to decimal
                    decimal minPrice = decimal.TryParse(MinPrice.Text, out minPrice) ? minPrice : decimal.MinValue;
                    decimal maxPrice = decimal.TryParse(MaxPrice.Text, out maxPrice) ? maxPrice : decimal.MaxValue;

                    // Filter products within the specified price range
                    query = query.Where(p => p.UnitPrice >= minPrice && p.UnitPrice <= maxPrice).ToList();
                }

                if (SearchId.Text != "")
                    query = query.Where(p => p.ProductId == int.Parse(SearchId.Text)).ToList();
                if (SearchUnitInStock.Text != "")
                    query = query.Where(p => p.UnitInStock == int.Parse(SearchUnitInStock.Text)).ToList();

                lvProducts.ItemsSource = query;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
