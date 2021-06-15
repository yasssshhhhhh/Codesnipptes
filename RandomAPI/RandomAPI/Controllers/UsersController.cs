using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using RandomAPI.Models;
using System.Text;
namespace RandomAPI.Controllers
{
    public  class UsersController : ApiController
    { 
        

       /* public HttpResponseMessage Post([FromBody] Users value)
        {
            using (SqlConnection con = new SqlConnection(@"data source=DESKTOP-8SOH1VH\SQLEXPRESS02;Initial catalog=EmployeeDB; Integrated Security=true;"))
            {
                var query = String.Format(" SELECT * FROM (select User_id,convert(varchar(50),DECRYPTBYPASSPHRASE('anything',Password)) as Password from Users) AS UID where User_id = '{0}' and Password = '{1}'", value.User_id, value.Password);
                // Creating the command object SELECT * FROM (select User_id,convert(varchar(50),DECRYPTBYPASSPHRASE('anything',Password)) as Password from Users)AS UID where User_id = 'varun' and Password = 'Pass789'
                SqlCommand cmd = new SqlCommand(query, con);

                // Opening Connection  
                con.Open();

                // Executing the SQL query  
                SqlDataReader sdr = cmd.ExecuteReader();

                //Looping through each record
                var count = 0;
                while (sdr.Read())
                {
                    count++;
                }
                if (count == 0)
                {

                    Result res = new Result();

                    res.status = "NotFound";
                    res.message = "Login Failed";
                    String Badresult = "Status:  " + HttpStatusCode.NotFound + "  Login failed ";
                    return Request.CreateResponse(HttpStatusCode.NotFound, res);

                }
                else
                {
                    Result res = new Result();

                    res.status = "Ok";
                    res.message = "login succesful";
                    String Result = "Status: " + HttpStatusCode.OK + " Login Succesful";
                    return Request.CreateResponse(HttpStatusCode.OK, res);
                }

            }*/

            /*public HttpResponseMessage Post([FromBody] Users value)
            {
                SqlConnection con = new SqlConnection(@"data source=DESKTOP-8SOH1VH\SQLEXPRESS02;Initial catalog=EmployeeDB; Integrated Security=true;");
                //var query = "select User_id,Password from users where User_id=@User_id and Password=@Password";
                var query1 = String.Format("select * from Users where User_id = '{0}' and Password = '{1}'", value.User_id, value.Password);
                var query2 = "select User_id,Password from users where User_id=" + value.User_id + "and Password=" + value.Password;
                SqlCommand insertcommand = new SqlCommand(query1, con);
                con.Open();
                int result = insertcommand.ExecuteNonQuery();
                if (result == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);

                }
                else
                {
                    Result res = new Result();

                    res.status = "Ok";
                    res.message = "login succesful";
                    String Result = "Status: " + HttpStatusCode.OK + " Login Succesful";
                    return Request.CreateResponse(HttpStatusCode.OK,res);
                }


            }*/
       /* public string Post( Users value)
        {
            SqlConnection con = new SqlConnection(@"data source=DESKTOP-8SOH1VH\SQLEXPRESS02;Initial catalog=EmployeeDB; Integrated Security=true;");
            var query = String.Format("insert into Users values('{0}','{1}'", value.User_id, value.Password);
            var query2 = String.Format("insert into Address values('{0}','{1}','{2}','{3}','{4}','{5}'", value.address_line1, value.statee, value.city, value.country, value.typee, value.User_id);
            SqlCommand insertcommand = new SqlCommand(query, con);
            SqlCommand insert = new SqlCommand(query2, con);
            con.Open();
            int result1 = insertcommand.ExecuteNonQuery();
            int result2 = insert.ExecuteNonQuery();

            if (result2  > 0)
            {
                return "inserted";

            }
            else
            {
                return "Failed ";
            }

        }*/
        public HttpResponseMessage Post([FromBody] Users value)
        {
           SqlConnection con = new SqlConnection(@"data source=DESKTOP-8SOH1VH\SQLEXPRESS02;Initial catalog=EmployeeDB; Integrated Security=true;");
            var query1 = "insert into Users(User_id,Password) values(@User_id,@Password)";
            //var query2 = String.Format("insert into Address values('{0}','{1}','{2}','{3}','{4}','{5}'", value.address_line1, value.statee, value.city, value.country, value.typee, value.User_id);
            ///var query2 = "insert into Address(address_line1,statee,city,country,typee,User_id) values(@address_line1,@statee,@city,@country,@typee,@User_id)";
            SqlCommand insertcommand = new SqlCommand(query1, con);
            insertcommand.Parameters.AddWithValue("@User_id", value.User_id);
            insertcommand.Parameters.AddWithValue("@Password", value.Password);

            int[] res = new int[5];

            con.Open();
            int result1 = insertcommand.ExecuteNonQuery();
            res.Append(result1);
            con.Close();

            Address[] Addresses = new Address[3];
            Addresses = value.Addresses;
            foreach (Address element in Addresses)
            {
                var query2 = String.Format("insert into Address values('{0}','{1}','{2}','{3}','{4}','{5}')", element.address_line1, element.statee, element.city, element.country, element.typee, value.User_id);
                SqlCommand insert = new SqlCommand(query2, con);
                con.Open();
                int result = insert.ExecuteNonQuery();
                res.Append(result);
                con.Close();
            }

           foreach (int res_value in res)
            {
                if (res_value == 1)
                    return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
    }

