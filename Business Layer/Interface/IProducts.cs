using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Interface
{
    public interface IProducts
    {
        Task<List<Product>> GetProduct(Product pro);
        Task<bool> CreateProduct(Product pro);
        Task<bool> DeleteProduct(int id);

        Task<Product> GetProductById(int id);
        Task<bool> EditProduct(Product pro);

    }
}
