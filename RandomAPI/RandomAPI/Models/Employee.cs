using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
namespace RandomAPI.Models
{
    public class Employee
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Gender { get; set; }
        public string Salary { get; set; } 
    }
   // public class CreateEmployee : Employee
    //{
        
    //}
    public class Readstudent: Employee
    {
        public Readstudent(DataRow row)
        {
            Firstname = row["Firstname"].ToString();
            Lastname = row["Lastname"].ToString();

            Gender = row["Gender"].ToString();

            Salary = row["Salary"].ToString();
        }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Gender { get; set; }
        public string Salary { get; set; }
    }

}

    