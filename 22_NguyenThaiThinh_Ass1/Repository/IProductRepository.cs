using _22_NguyenThaiThinh_Ass1.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22_NguyenThaiThinh_Ass1.Repository
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetProducts();
        public Product GetProductById(int ProductId);
        public Product GetProductByName(string ProductName);
        public void Insert(Product p);
        public void Update(Product p);
        public void Delete(Product p);
        public IEnumerable<Category> GetCategories();
    }
}
