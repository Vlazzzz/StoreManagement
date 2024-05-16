using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tema3.Models.Entities
{
    public class Producer
    {
        public int ProducerId { get; set; }
        public string Name { get; set; }
        public string OriginCountry { get; set; }
        public bool IsActive { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
