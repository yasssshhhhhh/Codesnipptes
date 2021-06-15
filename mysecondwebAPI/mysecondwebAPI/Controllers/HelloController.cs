using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using mysecondwebAPI.Models;

namespace mysecondwebAPI.Controllers
{
    [Route("api/hello")]
    public class HelloController : ApiController
    {
        [HttpGet]
        public String Get()
        {
            return "Hello World";
        }

    }
}
