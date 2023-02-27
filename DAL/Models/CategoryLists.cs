using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class CategoryLists
    {
        [Key, Column(Order = 0)]
        [ForeignKey("Products")]
        public int Productid { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("Categories")]
        public int CategoryId { get; set; }

        public bool IsActive { get; set; }

        public Product Products { get; set; }
        public Category Categories { get; set; }
    }
}
