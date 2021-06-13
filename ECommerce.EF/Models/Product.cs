using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ECommerce.EF.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public long ProductId { get; set; }
        [ForeignKey("ProdCatId")]
        public int ProdCatId { get; set; }
        public string ProdName { get; set; }
        public string ProdDescription { get; set; }
    }

}
