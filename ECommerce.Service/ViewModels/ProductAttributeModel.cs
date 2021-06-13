using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Service.ViewModels
{
   public class ProductAttributeModel
    {
        public long ProductId { get; set; }
        public int AttributeId { get; set; }
        public string AttributeValue { get; set; }
    }

}
