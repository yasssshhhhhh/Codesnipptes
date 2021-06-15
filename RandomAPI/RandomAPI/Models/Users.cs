using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace RandomAPI.Models
{
    public class Users
    { 
        public string User_id { get; set; }
        public string Password { get; set; }
        public Address[] Addresses { get; set; }
    }
}