using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tema3.Models.Entities
{
    public class Stock
    {
        public string StockId { get; set; }
        public string ProductId { get; set; }
        public string Quantity { get; set; }
        public string Unit { get; set; }
        public string SupplyDate { get; set; }
        public string ExpiryDate { get; set; }
        public string PurchasePrice { get; set; }
        public bool IsActive { get; set; }
        public virtual Product Product { get; set; }
    }
}
