using _22_NguyenThaiThinh_Ass1.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _22_NguyenThaiThinh_Ass1.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public void Delete(Order m)
        {
            try
            {
                Order order = GetOrderById(m.OrderId);
                if (order != null)
                {
                    var dbcontext = new Ass1_Prn221_Bl5Context();
                    //dbcontext.Entry<Car>(car).State = EntityState.Modified;
                    dbcontext.Orders.Remove(order);
                    dbcontext.SaveChanges();
                }
                else
                {
                    throw new Exception("Order doesnt existed!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public Order GetOrderById(int orderId)
        {
            Order order = null;
            try
            {
                var dbcontext = new Ass1_Prn221_Bl5Context();
                order = dbcontext.Orders.FirstOrDefault(m => m.OrderId == orderId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return order;
        }

        public IEnumerable<Order> GetOrders()
        {
            List<Order> orders = null;
            try
            {
                var dbcontext = new Ass1_Prn221_Bl5Context();
                orders = dbcontext.Orders.ToList();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return orders;
        }

        public void Insert(Order m)
        {
            try
            {
                if (m != null)
                {
                    var dbcontext = new Ass1_Prn221_Bl5Context();
                    //dbcontext.Entry<Car>(car).State = EntityState.Modified;
                    dbcontext.Orders.Add(m);
                    dbcontext.SaveChanges();
                }
                else
                {
                    throw new Exception("Cant add Order");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Update(Order m)
        {
            try
            {
                Order order = GetOrderById(m.OrderId);
                if (order != null)
                {
                    var dbcontext = new Ass1_Prn221_Bl5Context();
                    dbcontext.Entry<Order>(m).State = EntityState.Modified;
                    //dbcontext.Orders.Add(order);
                    dbcontext.SaveChanges();
                }
                else
                {
                    throw new Exception("Order doesnt existed!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
