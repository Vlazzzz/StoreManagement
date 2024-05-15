using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tema3
{
    internal class Receipt
    {
        public string ReceiptId { get; set; }
        public string UserId { get; set; }
        public string IssueDate { get; set; }
        public string AmountReceived { get; set; }
        public bool IsActive { get; set; }
    }
}
