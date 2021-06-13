using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.EF.CustomModels
{
    public class ProductModel
    {
        public long ProductId { get; set; }
        public int ProdCatId { get; set; }
        public string ProdName { get; set; }
        public string ProdDescription { get; set; }
        public string ProductCategoryName { get; set; }
    }
}
