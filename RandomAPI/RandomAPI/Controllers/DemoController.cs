using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RandomAPI.Controllers
{
    public class DemoController : ApiController
    {
        [Route("api/demo")]
        public string Get()
        {
            return "hello world!!!";
        }
    }
}
