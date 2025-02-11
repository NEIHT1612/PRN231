using BusinessObject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IProductRepository
    {
        void SaveProduct(Product Product);
        Product GetProductById(int id);
        List<Product> GetProducts();
        List<Product> Search(string keyword);
        void UpdateProduct(Product Product);
        void DeleteProduct(Product Product);
        List<OrderDetail> GetOrderDetails(int ProductId);
    }
}
