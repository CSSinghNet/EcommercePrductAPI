using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ECommerce.EF.Models
{
    [Table("ProductAttribute")]
    public class ProductAttribute
    {
        [ForeignKey("ProductId")]
        public long ProductId { get; set; }
        [ForeignKey("AttributeId")]
        public int AttributeId { get; set; }
        public string AttributeValue { get; set; }
    }
}
