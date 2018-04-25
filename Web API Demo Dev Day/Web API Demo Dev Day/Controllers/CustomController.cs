using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Web_API_Demo_Dev_Day.Controllers
{
    public class CustomController : ApiController
    {
        // GET: Custom
        public string GetHelloWorld()
        {
            return "Hello, World!";
        }

        [HttpGet]
        public int AddTwoNumbers(int number1, int number2)
        {
            return number1 + number2;
        }
    }
}