using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tema3.Models.Entities
{
    public class Receipt
    {
        public int ReceiptId { get; set; }
        public int UserId { get; set; }
        public DateTime IssueDate { get; set; }
        public Decimal AmountReceived { get; set; }
        public bool IsActive { get; set; }
        public virtual User User { get; set; }
        public virtual List<ReceiptProduct> ReceiptProducts { get; set; }
    }
}
