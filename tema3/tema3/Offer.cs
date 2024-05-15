using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tema3
{
    internal class Offer
    {
        public string OfferId { get; set; }
        public string ProductId { get; set; }
        public string DiscountPercentage { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public bool IsActive { get; set; }
    }
}
