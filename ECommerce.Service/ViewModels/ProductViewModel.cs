using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Service.ViewModels
{
    public class AddUpdateProductViewModel
    {

        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string AttributeName { get; set; }
        public int AttributeId { get; set; }

    }
}
