using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.EF.CustomModels
{
    public sealed class ResponseModel<T>
    {
        public List<T> Data { get; set; }
        public long Count { get; set; }
    }
}
