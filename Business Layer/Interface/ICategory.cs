using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Interface
{
    public interface ICategory
    {
        Task<List<Category>> GetAllCategory(Category cat);
        Task<bool> CreateCategory(Category cat);
        Task<bool> EditCategory(Category cat);
        Task<Category> GetCategoryByID(int id);
        Task<bool> DeleteCategory(int id);

    }
}
