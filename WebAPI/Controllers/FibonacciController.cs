using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace WebAPI.Controllers
{
    public class FibonacciController : ApiController
    {
        // GET: api/Fibonacci?n=number
        public long Get()
        {
            var param = HttpContext.Current.Request.QueryString["n"];

            // querystring parameter n is required
            if (param == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent("No HTTP resource was found that matches the request URI: " + HttpContext.Current.Request.Url.AbsoluteUri),
                    ReasonPhrase = "Critical Exception"
                });
            }

            long n = Convert.ToInt64(param);
            long a = 0;
            long b = 1;

            // no need to calculate 
            if ((n == 0) || (n == 1))
            {
                return n;
            }
            else
            {
                // Calculate Fibonacci sequence iteratively n number of times
                // next number is the sum of previous 2
                for (int i = 0; i < n; i++)
                {
                    long tempValue = a;
                    a = b;
                    b = tempValue + b;
                }
            }

            return a;
        }
    }
}