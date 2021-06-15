using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeeData;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;
using RandomAPI.Models;
using System.Configuration;

namespace RandomAPI.Controllers
{
    public class EmployeesController : ApiController
   {
        private SqlConnection con;
        private SqlDataAdapter da;

        public IEnumerable<Employee> Get()
        {
            con = new SqlConnection(@"data source=DESKTOP-8SOH1VH\SQLEXPRESS02;Initial catalog=EmployeeDB; Integrated Security=true;");
            DataTable dt = new DataTable();
            var query = " select * from employees";
            da = new SqlDataAdapter
            {
                SelectCommand = new SqlCommand(query, con)
            };
            da.Fill(dt);
            List<Employee> Eemployee = new List<Models.Employee>(dt.Rows.Count);
            if(dt.Rows.Count>0)
            {
                foreach (DataRow employees in dt.Rows)
                    Eemployee.Add(new Readstudent(employees));
            }
            return Eemployee;
        }

        public string Post([FromBody] Employee value)
        {
            con = new SqlConnection(@"data source=DESKTOP-8SOH1VH\SQLEXPRESS02;Initial catalog=EmployeeDB; Integrated Security=true;");
            var query = "insert into employees(Firstname,Lastname,Gender,Salary) values(@Firstname,@Lastname,@Gender,@Salary)";
            SqlCommand insertcommand = new SqlCommand(query, con);
            insertcommand.Parameters.AddWithValue("@Firstname",value.Firstname);
            insertcommand.Parameters.AddWithValue("@Lastname",value.Lastname);
            insertcommand.Parameters.AddWithValue("@Gender",value.Gender);
            insertcommand.Parameters.AddWithValue("@Salary",value.Salary);
            con.Open();
            int result = insertcommand.ExecuteNonQuery();
            if (result > 0)
            {
                return "inserted";
                
            }
            else
            {
                return "Failed ";
            }

        }

        public string Put(int id,[FromBody] Employee value)
        {
            con = new SqlConnection(@"data source=DESKTOP-8SOH1VH\SQLEXPRESS02;Initial catalog=EmployeeDB; Integrated Security=true;");
            var query = "update employees set Firstname=@Firstname,Lastname=@Lastname,Gender=@Gender,Salary=@Salary where id =" +id;
            SqlCommand insertcommand = new SqlCommand(query, con);
            insertcommand.Parameters.AddWithValue("@Firstname", value.Firstname);
            insertcommand.Parameters.AddWithValue("@Lastname", value.Lastname);
            insertcommand.Parameters.AddWithValue("@Gender", value.Gender);
            insertcommand.Parameters.AddWithValue("@Salary", value.Salary);
            con.Open();
            int result = insertcommand.ExecuteNonQuery();
            if (result > 0)
            {
                return "inserted";

            }
            else
            {
                return "Failed ";
            }

        }
        public string Delete(int id)
        {
            con = new SqlConnection(@"data source=DESKTOP-8SOH1VH\SQLEXPRESS02;Initial catalog=EmployeeDB; Integrated Security=true;");
            var query = "delete from employees where id="+id;
            SqlCommand insertcommand = new SqlCommand(query, con);
            con.Open();
            int result = insertcommand.ExecuteNonQuery();
            if (result > 0)
            {
                return "Deleted";

            }
            else
            {
                return "Failed ";
            }

        }

        /*public HttpResponseMessage Get()
        {
            DataTable table = new DataTable();
            string query = @"Select Firstname,Lastname,Gender,Salary FROM dbo.employees";
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);

        }
       
        }*/
    }
}
