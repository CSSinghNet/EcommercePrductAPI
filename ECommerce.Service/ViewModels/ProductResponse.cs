using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Service.ViewModels
{
    public class ProductResponse
    {
        public long ProductId { get; set; }
        public int ProdCatId { get; set; }
        public string ProdName { get; set; }
        public string ProdDescription { get; set; }
        public string ProdCategoryName { get; set; }
    }

    public class ProductViewModel
    {
        public long ProductId { get; set; }
        public int ProdCatId { get; set; }
        public string ProdName { get; set; }
        public string ProdDescription { get; set; }
    }
}
