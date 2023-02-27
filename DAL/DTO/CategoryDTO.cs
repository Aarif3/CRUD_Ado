using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Name is Required ")]
        [DisplayName("Name")]
        public string CategoryName { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}
