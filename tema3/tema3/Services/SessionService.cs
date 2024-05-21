using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tema3.Models.Entities;

namespace tema3.Services
{
    public class SessionService
    {
        private static SessionService _instance;
        public static SessionService Instance => _instance ?? (_instance = new SessionService());

        public User CurrentUser { get; set; }

        private SessionService() { }
    }
}
