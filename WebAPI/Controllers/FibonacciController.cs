using System;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class FibonacciController : ApiController
    {
        // GET: api/Fibonacci?n=number
        [HttpGet]
        public long Get(long n)
        {
            try
            {
                long a = 0;
                long b = 1;

                if (n > 92 || n < -92)
                {
                    throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new StringContent("no content"),
                    });
                }

                long absValue = Math.Abs(n);

                // no need to calculate 
                if ((absValue == 0) || (absValue == 1))
                {
                    return absValue;
                }
                else
                {
                    // Calculate Fibonacci sequence iteratively n number of times
                    // next number is the sum of previous 2
                    for (int i = 0; i < absValue; i++)
                    {
                        long tempValue = a;
                        a = b;
                        b = tempValue + b;
                    }
                }

                if (n > 0)
                {
                    return a;
                }
                else
                {
                    return a * -1;
                }
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("no content"),
                });
            }
        }
    }
}