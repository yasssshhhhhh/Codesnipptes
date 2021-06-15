using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;
using RandomAPI.Models;
using System.Configuration;
namespace RandomAPI.Controllers
{
    public class ValuesController : ApiController
    {
        SqlConnection con = new SqlConnection(@"server=DESKTOP-8SOH1VH\SQLEXPRESS02; database = EmployeeDB; Integrated Security=true;");
        // GET api/values
        static List<string> strings = new List<string>()
        { "value1","value2","value3"
        };
        public DataTable Get()
        {
            //return strings;
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM employees", con);
            DataTable dt = new DataTable();

            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {               
                    return dt;   
            }
            else
            {
                return null;
            }

        }
        public string Post([FromBody] Employee value)
        {
            con = new SqlConnection(@"data source=DESKTOP-8SOH1VH\SQLEXPRESS02;Initial catalog=EmployeeDB; Integrated Security=true;");
            var query = "insert into employees(Firstname,Lastname,Gender,Salary) values(@Firstname,@Lastname,@Gender,@Salary)";
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
        public string Put(int id, [FromBody] Employee value)
        {
            con = new SqlConnection(@"data source=DESKTOP-8SOH1VH\SQLEXPRESS02;Initial catalog=EmployeeDB; Integrated Security=true;");
            var query = "update employees set Firstname=@Firstname,Lastname=@Lastname,Gender=@Gender,Salary=@Salary where id =" + id;
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
            var query = "delete from employees where id=" + id;
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

        // GET api/values/5
        public string Get(int id)
        {
            return strings[id];
        }
            /* public HttpResponseMessage Post(Login loginn)
             {

                 if (loginn.Username == "yash" && loginn.pass == "passed")
                 {

                     Result res = new Result();

                     res.status = "Ok";
                     res.message = "login succesful";
                     String Result = "Status: " + HttpStatusCode.OK + " Login Succesful";
                     return Request.CreateResponse(HttpStatusCode.OK, res);        // returns  value of username and password 
                 }
                 else
                 {
                     Result res = new Result();

                     res.status = "NotFound";
                     res.message = "Login Failed";
                     String Badresult = "Status:  " + HttpStatusCode.NotFound + "  Login failed ";
                     return Request.CreateResponse(HttpStatusCode.NotFound, res); ;
                 }
             }

         // PUT api/values/5
         public void Put(int id, [FromBody] string value)
         {
             strings[id] = value;
         }

         // DELETE api/values/5
         public void Delete(int id)
         {
             strings.RemoveAt(id);
         }*/
        }
    }

