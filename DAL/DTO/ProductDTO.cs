using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO
{
    public class ProductDTO
    {
        public int ProductId { get; set; }

        [Required]
        [DisplayName("Name")]
        public string ProductName { get; set; }

        [Required]
        [DisplayName("Description")]
        public string ProductDescription { get; set; }

        [Required]
        [DisplayName("Price")]
        public int Productprice { get; set; }
    }
}
