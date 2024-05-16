using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tema3.Models.Entities
{
    public class Product
    {
        public string ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CategoryId { get; set; }
        public string ProducerId { get; set; }
        public string Barcode { get; set; }
        public bool IsActive { get; set; }
        public virtual Producer Producer { get; set; }
        public virtual Category Category { get; set; }
        public virtual List<Stock> Stocks { get; set; }
    }
}
