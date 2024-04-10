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
    /// Interaction logic for AdminOrder.xaml
    /// </summary>
    public partial class AdminOrder : Window
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IProductRepository _productRepository;
        private IOrderRepository _orderRepository = new OrderRepository();
        public AdminOrder(IMemberRepository memberRepository, IProductRepository productRepository)
        {
            InitializeComponent();
            _memberRepository = memberRepository;
            _productRepository = productRepository;
            lvMembers.ItemsSource = _memberRepository.GetMembers();
            lvProducts.ItemsSource = _productRepository.GetProducts();
        }

        private Order GetOrderObject()
        {
            Order c = null;
            try
            {
                c = new Order
                {
                    OrderId = int.Parse(txtOrderId.Text),
                    MemberId = int.Parse(txtMemberId.Text),
                    OrderDate = DateTime.Parse(txtOrderDate.Text),
                    RequiredDate = (txtRequiredDate.Text == "" ? null : DateTime.Parse(txtRequiredDate.Text)),
                    ShippedDate = (txtShippedDate.Text == "" ? null : DateTime.Parse(txtShippedDate.Text)),
                    Freight = (txtFreight.Text == ""? null : Decimal.Parse(txtFreight.Text)),
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "GetOrder");
            }
            return c;
        }
        private Order GetOrderObjectToAdd()
        {
            Order c = null;
            try
            {
                c = new Order
                {
                    MemberId = int.Parse(txtMemberId2.Text),
                    OrderDate = DateTime.Now,
                    RequiredDate = (txtRequiredDate.Text == "" ? null : DateTime.Parse(txtRequiredDate.Text)),
                    ShippedDate = (txtShippedDate.Text == "" ? null : DateTime.Parse(txtShippedDate.Text)),
                    Freight = (txtFreight.Text == "" ? null : Decimal.Parse(txtFreight.Text)),
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "GetOrder");
            }
            return c;
        }
        public void LoadOrderList()
        {
            lvOrders.ItemsSource = _orderRepository.GetOrders();
        }
        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadOrderList();
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
                Order order = GetOrderObject();
                _orderRepository.Update(order);
                LoadOrderList();
                MessageBox.Show($"{order.OrderId} Update Successfully ", "Update Member");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            AdminMenu adminMenu = new AdminMenu(_memberRepository, _productRepository);
            adminMenu.Show();
            this.Close();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Order o = GetOrderObjectToAdd();
                _orderRepository.Insert(o);
                Product temp = lvProducts.SelectedItem as Product;
                temp.UnitInStock = -int.Parse(txtQuantity.Text);
                _productRepository.Insert(temp);
                OrderDetail od = new OrderDetail {
                    OrderId = o.OrderId,
                    ProductId = int.Parse(txtProductId2.Text),
                    UnitPrice = ((Product)lvProducts.SelectedItem).UnitPrice,
                    Quantity = int.Parse(txtQuantity.Text),
                    Discount = float.Parse(txtDiscount.Text)
                };
                var dbcontext = new Ass1_Prn221_Bl5Context();
                dbcontext.OrderDetails.Add(od);
                dbcontext.SaveChanges();
                MessageBox.Show("Order create Successfully!");
                lvProducts.ItemsSource = _productRepository.GetProducts();
                lvOrders.ItemsSource = _orderRepository.GetOrders();
            }
            catch (Exception ex)
            {
                MessageBox.Show (ex.Message);
            }
        }

        private void lvMemberChange(object sender, SelectionChangedEventArgs e)
        {
            txtMemberId2.DataContext = lvMembers.SelectedItem;
        }

        private async void lvOrdersChange(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var dbcontext = new Ass1_Prn221_Bl5Context();
                Order temp = lvOrders.SelectedItem as Order;
                OrderDetail orderTemp = dbcontext.OrderDetails.FirstOrDefault(od => od.OrderId == temp.OrderId);
                if(orderTemp != null)
                {
                    txtMemberId2.DataContext = lvOrders.SelectedItem;
                    txtProductId2.DataContext = orderTemp;
                    txtQuantity.Text = orderTemp.Quantity.ToString();
                    txtDiscount.Text = orderTemp.Discount.ToString();
                    txtUnitPrice.Text = orderTemp.UnitPrice.ToString();
                }
            }catch (Exception ex) { 
                MessageBox.Show (ex.Message);
            }
        }

        private void lvProductsChange(object sender, SelectionChangedEventArgs e)
        {
            txtProductId2.DataContext = lvProducts.SelectedItem;
        }
    }
}
