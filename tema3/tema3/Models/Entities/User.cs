using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tema3.Models.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool UserType{ get; set; }
        public bool IsActive { get; set; }
        public virtual List<Receipt> Receipts { get; set; }
    }
}
