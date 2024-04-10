using _22_NguyenThaiThinh_Ass1.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22_NguyenThaiThinh_Ass1.Repository
{
    public interface IOrderRepository
    {
        public IEnumerable<Order> GetOrders();
        public Order GetOrderById(int memberId);
        public void Insert(Order o);
        public void Update(Order o);
        public void Delete(Order o);
    }
}
