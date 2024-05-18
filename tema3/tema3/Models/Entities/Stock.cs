using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tema3.Models.Entities
{
    public class Stock
    {
        public int StockId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }
        public DateTime SupplyDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public Decimal PurchasePrice { get; set; }
        public bool IsActive { get; set; }
        public virtual Product Product { get; set; }

        //to bind directly the name of the category and producer to the datagrid in the UI
        public string ProductName { get; set; }
    }
}
