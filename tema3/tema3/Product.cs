using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tema3
{
    internal class Product
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string CategoryId { get; set; }
        public string ProducerId { get; set; }
        public string Barcode { get; set; }
        public bool IsActive { get; set; }
    }
}
