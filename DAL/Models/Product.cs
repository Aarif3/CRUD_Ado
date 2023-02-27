using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        
        public string ProductName { get; set; }

        
        public string ProductDescription { get; set; }

        
        public int Productprice { get; set; }

    }
}
