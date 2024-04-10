using _22_NguyenThaiThinh_Ass1.DataAccess;
using _22_NguyenThaiThinh_Ass1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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
    /// Interaction logic for AdminMember.xaml
    /// </summary>
    public partial class AdminMember : Window
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IProductRepository _productRepository;
        public AdminMember(IMemberRepository memberRepository, IProductRepository productRepository)
        {
            InitializeComponent();
            _memberRepository = memberRepository;
            _productRepository = productRepository;
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
        private Member GetMemberObjectToAdd()
        {
            Member c = null;
            try
            {
                c = new Member
                {
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
        public void LoadMemberList()
        {
            lvMembers.ItemsSource = _memberRepository.GetMembers();
        }
        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadMemberList();
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
                Member member = GetMemberObjectToAdd();
                _memberRepository.Insert(member);
                LoadMemberList();
                MessageBox.Show($"{member.Email} insert Successfully ", "Insert Member");
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
                Member member = GetMemberObject();
                _memberRepository.Update(member);
                LoadMemberList();
                MessageBox.Show($"{member.Email} Update Successfully ", "Update Member");
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
                Member member = GetMemberObject();
                _memberRepository.Delete(member);
                LoadMemberList();
                MessageBox.Show($"{member.Email} Delete Successfully ", "Delete Member");
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
    }
}
