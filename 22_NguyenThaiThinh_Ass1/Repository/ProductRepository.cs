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
    public class ProductRepository : IProductRepository
    {
        public void Delete(Product m)
        {
            try
            {
                Product product = GetProductById(m.ProductId);
                if (product != null)
                {
                    var dbcontext = new Ass1_Prn221_Bl5Context();
                    //dbcontext.Entry<Car>(car).State = EntityState.Modified;
                    dbcontext.Products.Remove(product);
                    dbcontext.SaveChanges();
                }
                else
                {
                    throw new Exception("Product doesnt existed!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public IEnumerable<Category> GetCategories()
        {
            List<Category> categories = null;
            try
            {
                var dbcontext = new Ass1_Prn221_Bl5Context();
                categories = dbcontext.Categories.ToList();
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return categories;
        }

        public Product GetProductById(int productId)
        {
            Product product = null;
            try
            {
                var dbcontext = new Ass1_Prn221_Bl5Context();
                product = dbcontext.Products.FirstOrDefault(m => m.ProductId == productId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return product;
        }

        public Product GetProductByName(string ProductName)
        {
            Product product = null;
            try
            {
                var dbcontext = new Ass1_Prn221_Bl5Context();
                product = dbcontext.Products.FirstOrDefault(m => m.ProductName == ProductName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return product;
        }

        public IEnumerable<Product> GetProducts()
        {
            List<Product> products = null;
            try
            {
                var dbcontext = new Ass1_Prn221_Bl5Context();
                products = dbcontext.Products.ToList();
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return products;
        }

        public void Insert(Product m)
        {
            try
            {
                Product product = GetProductByName(m.ProductName);
                if (product == null)
                {
                    var dbcontext = new Ass1_Prn221_Bl5Context();
                    //dbcontext.Entry<Car>(car).State = EntityState.Modified;
                    dbcontext.Products.Add(m);
                    dbcontext.SaveChanges();
                }
                else
                {
                    product.UnitInStock += m.UnitInStock;
                    if (product.UnitInStock <= 0)
                    {
                        throw new Exception("Out of Stock!");
                    }
                    var dbcontext = new Ass1_Prn221_Bl5Context();
                    dbcontext.Entry(product).State = EntityState.Modified;
                    dbcontext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                if(ex.Message.Contains("Out of Stock!"))
                    throw new Exception(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        public void Update(Product m)
        {
            try
            {
                Product product = GetProductById(m.ProductId);
                if (product != null)
                {
                    var dbcontext = new Ass1_Prn221_Bl5Context();
                    dbcontext.Entry<Product>(m).State = EntityState.Modified;
                    //dbcontext.Products.Add(product);
                    dbcontext.SaveChanges();
                }
                else
                {
                    throw new Exception("Product doesnt existed!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
