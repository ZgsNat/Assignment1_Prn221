using _22_NguyenThaiThinh_Ass1.DataAccess;
using _22_NguyenThaiThinh_Ass1.Repository;
using Microsoft.Extensions.Configuration;
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
    /// Interaction logic for Client.xaml
    /// </summary>
    public partial class Client : Window
    {
        private Member member;
        private readonly Ass1_Prn221_Bl5Context _context;
        private IConfiguration _configuration;
        private readonly IMemberRepository _memberRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;
        public Client(Member m, IMemberRepository memberRepository, IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _context = new Ass1_Prn221_Bl5Context();
            InitializeComponent();
            member = m;
            DataContext = member;
            _memberRepository = memberRepository;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            lvOrders.ItemsSource = _context.Orders.Where(O => O.MemberId == m.MemberId).ToList();
            ProductItems.ItemsSource = _context.Products.ToList();
        }
        private Member GetMemberObject()
        {
            Member c = null;
            try
            {
                c = new Member
                {
                    MemberId = int.Parse(txtMemberId.Text),
                    Email = txtEmail.Text,
                    CompanyName = txtCompanyName.Text,
                    City = txtCity.Text,
                    Country = txtCountry.Text,
                    Password = txtPassword.Text,
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "GetMember");
            }
            return c;
        }
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Member member = GetMemberObject();
                _memberRepository.Update(member);
                MessageBox.Show($"{member.Email} Update Successfully ", "Update Member");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lvOrdersChange(object sender, SelectionChangedEventArgs e)
        {
            try
            {
               
                Order temp = lvOrders.SelectedItem as Order;
                OrderDetail orderTemp = _context.OrderDetails.FirstOrDefault(od => od.OrderId == temp.OrderId);
                if (orderTemp != null)
                {
                    txtMemberId2.DataContext = lvOrders.SelectedItem;
                    txtProductId2.DataContext = orderTemp;
                    txtQuantity.DataContext = orderTemp;
                    txtDiscount.DataContext = orderTemp;
                    txtUnitPrice.DataContext = orderTemp;
                }
                foreach (Product p in ProductItems.ItemsSource)
                {
                    if (p.ProductId == int.Parse(txtProductId2.Text))
                    {
                        ProductItems.DataContext = p;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ProductItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(_productRepository, _memberRepository);
            mainWindow.Show();
            this.Close();
        }
    }
}
