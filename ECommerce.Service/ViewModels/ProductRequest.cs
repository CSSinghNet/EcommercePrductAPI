using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ECommerce.Service.ViewModels
{
    public class ProductRequest
    {
        [Required]
        public int Take { get; set; }
        [Required]
        public int Skip { get; set; }
        public string SearchString { get; set; }
        [Required]
        public string OrderByField { get; set; }
        [Required]
        public string OrderByDirection { get; set; }
    }
}
