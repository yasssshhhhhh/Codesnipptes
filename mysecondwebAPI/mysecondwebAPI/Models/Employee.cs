using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mysecondwebAPI.Models
{
    public class Employee
    {
        public string Name { get; set; }
        public DateTime JoiningDate { get; set; }
        public int Age { get; set; }
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public int Salary { get; set; }
    }
}