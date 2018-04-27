using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace Web_API_Demo_Dev_Day.Controllers
{
    [RoutePrefix("api/Calculations")]
    public class CalculationsController : ApiController
    {
        /* This implementation uses routing to resolve multiple GET methods in the Calculations endpoint */

        /// <summary>
        /// Adds two numbers together
        /// </summary>
        /// <param name="number1">First number</param>
        /// <param name="number2">Second number</param>
        /// <returns>Total</returns>
        // GET: api/Calculations/Add/2?number1={number1}&number2={number2}
        [HttpGet, Route("Add/2")]
        public int AddTwoNumbers(int number1, int number2)
        {
            return number1 + number2;
        }

        /// <summary>
        /// Adds three numbers together
        /// </summary>
        /// <param name="number1">First number</param>
        /// <param name="number2">Second number</param>
        /// <param name="number3">Third number</param>
        /// <returns>Total</returns>
        // GET: api/Calculations/Add/3?number1={number1}&number2={number2}&number3={number3}
        [HttpGet, Route("Add/3")]
        public int AddThreeNumbers(int number1, int number2, int number3)
        {
            return number1 + number2 + number3;
        }

        /* The above example is used for demo purposes only. The correct implementation below should 
         * allow any number of ints to be added together */
        
        /// <summary>
        /// Adds numbers together
        /// </summary>
        /// <param name="numbers">Array of numbers</param>
        /// <returns>Total</returns>
        // GET: api/Calculations/Add?numbers={number1}&numbers={number2}&etc..
        [HttpGet, Route("Add")]
        public int AddNumbers([FromUri] int[] numbers)
        {
            int result = 0;

            foreach(int n in numbers)
            {
                result += n;
            }

            return result;
        }

        /* Routes for Subtract, Multiple and Divide could be added here */
    }
}