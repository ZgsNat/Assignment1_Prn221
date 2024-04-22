using _22_NguyenThaiThinh_Ass1.Repository;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _22_NguyenThaiThinh_Ass1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IConfiguration _configuration;
        private readonly IMemberRepository _memberRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;
        public MainWindow(IProductRepository productRepository, IMemberRepository memberRepository )
        {
            InitializeComponent();
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            _configuration = builder.Build();
            _productRepository = productRepository;
            _memberRepository = memberRepository;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string enteredEmail = txtUsername.Text;
            string enteredPassword = txtPassword.Password;
            string adminEmail = _configuration["AdminCredentials:Email"];
            string adminPassword = _configuration["AdminCredentials:Password"];
            try
            {
                if (enteredEmail == adminEmail && enteredPassword == adminPassword)
                {
                    //MessageBox.Show("Admin");
                    AdminMenu adminmenu = new AdminMenu(_memberRepository, _productRepository);
                    adminmenu.Show();
                    this.Close();
                }
                else
                {
                    if(_memberRepository.DetectMember(enteredEmail,enteredPassword)!= null)
                    {
                        CLientMenu client = new CLientMenu(_memberRepository.DetectMember(enteredEmail, enteredPassword), _memberRepository, _orderRepository, _productRepository);
                        client.Show();
                        this.Close();
                    }
                    else
                    {
                        throw new Exception("Wrong account!");
                    }
                    //MessageBox.Show("Client");
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            SignUp signUp = new SignUp(_memberRepository);
            signUp.Show();
        }
    }
}