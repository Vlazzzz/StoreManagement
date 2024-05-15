using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tema3
{
    internal class ReceiptProducts
    {
        public string ReceiptId { get; set; }
        public string ProductId { get; set; }
        public string Quantity { get; set; }
        public string Unit { get; set; }
        public string SubTotal { get; set; }
        public bool IsActive { get; set; }
    }
}
