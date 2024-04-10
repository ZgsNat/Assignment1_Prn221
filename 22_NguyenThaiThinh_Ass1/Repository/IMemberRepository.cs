using _22_NguyenThaiThinh_Ass1.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22_NguyenThaiThinh_Ass1.Repository
{
    public interface IMemberRepository
    {
        public IEnumerable<Member> GetMembers();
        public Member GetMemberById(int memberId);
        public void Insert(Member m);
        public void Update(Member m);
        public void Delete(Member m);
        public Member DetectMember(string Email, string Password);
    }
}
