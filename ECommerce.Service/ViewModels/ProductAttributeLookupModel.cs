using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ECommerce.Service.ViewModels
{
   public class ProductAttributeLookupModel
    {
        [Key]
        public int AttributeId { get; set; }
        public int ProdCatId { get; set; }
        public string AttributeName { get; set; }
    }
}
