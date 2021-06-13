using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ECommerce.EF.Models
{
    [Table("ProductCategory")]
    public class ProductCategory
    {
        [Key]
        public int ProdCatId { get; set; }
        public string CategoryName { get; set; }
    }
}
