using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Interface
{
    public interface ICategoryAdv
    {
        bool Active(int id);
        bool DeActive(int id);

        List<Product> ShowAddProducts();

        bool AddProduts(int Pid, int Cid);
        List<Product> ShowProductInCategory(int id);
        
    }
}
