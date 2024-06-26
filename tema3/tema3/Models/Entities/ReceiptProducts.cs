﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace tema3.Models.Entities
{
    [PrimaryKey("ReceiptId", "ProductId")]
    public class ReceiptProduct
    {
        public int ReceiptId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }
        public Decimal Subtotal { get; set; }
        public bool IsActive { get; set; }
        public virtual Product Product { get; set; }
        public virtual Receipt Receipt { get; set; }

        //to bind directly the name of the Product in Cashier mode receipt visualisation
        public string ProductName { get; set; }
    }
}
