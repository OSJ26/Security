using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JsonWebToken.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string pwd { get; set; }

        public string mobNum { get; set; }

        public string role { get; set; }

        public string City { get; set; }
    }
}