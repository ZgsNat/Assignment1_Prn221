using _22_NguyenThaiThinh_Ass1.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _22_NguyenThaiThinh_Ass1.Repository
{
    public class MemberRepository : IMemberRepository
    {
        public void Delete(Member m)
        {
            try
            {
                Member member = GetMemberById(m.MemberId);
                if (member != null)
                {
                    var dbcontext = new Ass1_Prn221_Bl5Context();
                    //dbcontext.Entry<Car>(car).State = EntityState.Modified;
                    dbcontext.Members.Remove(member);
                    dbcontext.SaveChanges();
                }
                else
                {
                    throw new Exception("Member doesnt existed!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public Member DetectMember(string Email, string Password)
        {
            try
            {
                Member m = null;
                var db = new Ass1_Prn221_Bl5Context();
                m = db.Members.FirstOrDefault(m => m.Email == Email && m.Password == Password);
                if (m != null)
                    return m;
                else
                    return null;
            }catch (Exception ex)
            {
                return null;
            }
        }

        public Member GetMemberById(int memberId)
        {
           Member member = null;
            try
            {
                var dbcontext = new Ass1_Prn221_Bl5Context();
                member = dbcontext.Members.FirstOrDefault(m => m.MemberId == memberId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return member;
        }

        public IEnumerable<Member> GetMembers()
        {
            List<Member> members = null;
            try
            {
                var dbcontext = new Ass1_Prn221_Bl5Context();
                members = dbcontext.Members.ToList();

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return members;
        }

        public void Insert(Member m)
        {
            try
            {
                Member member = GetMemberById(m.MemberId);
                if(member == null)
                {
                    var dbcontext = new Ass1_Prn221_Bl5Context();
                    //dbcontext.Entry<Car>(car).State = EntityState.Modified;
                    if (m.Email.Equals(dbcontext.Members.FirstOrDefault(me => me.Email == m.Email)))
                        throw new Exception("Member is already existed!");
                    dbcontext.Members.Add(m);
                    dbcontext.SaveChanges();
                }
                else
                {
                    throw new Exception("Member is already existed!");
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Update(Member m)
        {
            try
            {
                Member member = GetMemberById(m.MemberId);
                if (member != null)
                {
                    var dbcontext = new Ass1_Prn221_Bl5Context();
                    dbcontext.Entry<Member>(m).State = EntityState.Modified;
                    //dbcontext.Members.Add(member);
                    dbcontext.SaveChanges();
                }
                else
                {
                    throw new Exception("Member doesnt existed!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
