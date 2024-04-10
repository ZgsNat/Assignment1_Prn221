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
    /// Interaction logic for AdminMenu.xaml
    /// </summary>
    public partial class AdminMenu : Window
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IProductRepository _productRepository;
        public AdminMenu(IMemberRepository memberRepository, IProductRepository productRepository)
        {
            InitializeComponent();
            _memberRepository = memberRepository;
            _productRepository = productRepository;
        }

        private void Product_Click(object sender, RoutedEventArgs e)
        {
            AdminProduct adminProduct = new AdminProduct(_memberRepository, _productRepository);
            adminProduct.Show();
            this.Close();
        }

        private void Member_Click(object sender, RoutedEventArgs e)
        {
            AdminMember adminMember = new AdminMember(_memberRepository, _productRepository);
            adminMember.Show();
            this.Close();
        }

        private void Order_Click(object sender, RoutedEventArgs e)
        {
            AdminOrder adminOrder = new AdminOrder(_memberRepository, _productRepository);
            adminOrder.Show();
            this.Close();
        }

        private void Report_Click(object sender, RoutedEventArgs e)
        {
            AdminReport adminReport = new AdminReport();
            adminReport.Show();
        }
    }
}
