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
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        private readonly IMemberRepository _memberRepository;
        public SignUp(IMemberRepository memberRepository)
        {
            InitializeComponent();
            _memberRepository = memberRepository;
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

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Member member = GetMemberObjectToAdd();
                _memberRepository.Insert(member);
                MessageBox.Show($"{member.Email} insert Successfully ", "Insert Member");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
