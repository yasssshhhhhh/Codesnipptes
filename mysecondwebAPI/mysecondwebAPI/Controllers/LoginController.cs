using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNetCore;
using mysecondwebAPI.Controllers;
using Newtonsoft.Json;
namespace mysecondwebAPI.Models
{
    public class LoginController : ApiController
    {
        [Route("api/login")]
        [HttpPost]
        //passing values through Query string

        /* public Boolean POST(string Username, string pass)
         {
             if (Username == "yash" && pass == "passed")
                 return true;
             else
                 return false;

         }*/

        /*public String Post([FromBody] String Username)
         {
            if (Username == "yash")
             {
                return Username;    // returns null
             }
                 else
                    return "false";
         }*/


       /* public Boolean Post(Login loginn)
        {
            if (loginn.Username == "yash" && loginn.pass == "passed")
            {
                return true;        //API works
            }
            else
            {
                return false ;
            }
        }*/

        public HttpResponseMessage Post(Login loginn)
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
    }
}


