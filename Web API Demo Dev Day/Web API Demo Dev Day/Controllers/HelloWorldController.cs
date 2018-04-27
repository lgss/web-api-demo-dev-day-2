using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Web_API_Demo_Dev_Day.Controllers
{
    public class HelloWorldController : ApiController
    {
        /// <summary>
        /// Basic Hello World method
        /// </summary>
        /// <returns>Hello, world!</returns>
        // GET: api/HelloWorld
        public string Get()
        {
            return "Hello, world!";
        }
    }
}