using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FisherInsuranceApi.Models
{
    public class Quote
    {
        public int Id { get; set; }
        public string Product { get; set; }
        public DateTime ExpireDate { get; set; }
        public decimal Price { get; set; }
    }
}
