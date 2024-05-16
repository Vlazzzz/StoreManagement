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
        public string ReceiptId { get; set; }
        public string UserId { get; set; }
        public string IssueDate { get; set; }
        public string AmountReceived { get; set; }
        public bool IsActive { get; set; }
        public virtual User User { get; set; }
        public virtual List<ReceiptProducts> ReceiptProducts { get; set; }
    }
}
