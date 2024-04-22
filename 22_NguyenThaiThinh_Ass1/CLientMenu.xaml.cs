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
    /// Interaction logic for CLientMenu.xaml
    /// </summary>
    public partial class CLientMenu : Window
    {
        private Member member;
        private readonly Ass1_Prn221_Bl5Context _context;
        private IConfiguration _configuration;
        private readonly IMemberRepository _memberRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;
        public CLientMenu(Member m, IMemberRepository memberRepository,  IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _context = new Ass1_Prn221_Bl5Context();
            InitializeComponent();
            member = m;
            DataContext = member;
            _memberRepository = memberRepository;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Client client = new Client(member, _memberRepository, _orderRepository, _productRepository);
            client.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Client client = new Client(member, _memberRepository, _orderRepository, _productRepository);
            client.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Client client = new Client(member, _memberRepository, _orderRepository, _productRepository);
            client.Show();
            this.Close();
        }
    }
}
