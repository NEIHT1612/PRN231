using BusinessObject.DataAccess;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.ImplRepo
{
    public class ProductRepository : IProductRepository
    {
        public void DeleteProduct(Product Product) => ProductDAO.DeleteProduct(Product);

        public List<OrderDetail> GetOrderDetails(int ProductId) => OrderDetailDAO.FindAllOrderDetailsByProductID(ProductId);

        public Product GetProductById(int id) => ProductDAO.FindProductById(id);

        public List<Product> GetProducts() => ProductDAO.GetProducts();

        public void SaveProduct(Product Product) => ProductDAO.SaveProduct(Product);

        public List<Product> Search(string keyword) => ProductDAO.Search(keyword);

        public void UpdateProduct(Product Product) => ProductDAO.UpdateProduct(Product);
    }
}
