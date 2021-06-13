using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ECommerce.EF.Models
{
    [Table("ProductAttributeLookup")]
    public class ProductAttributeLookup
    {
        [Key]
        public int AttributeId { get; set; }
        [ForeignKey("ProdCatId")]
        public int ProdCatId { get; set; }
        public string AttributeName { get; set; }
    }

}
