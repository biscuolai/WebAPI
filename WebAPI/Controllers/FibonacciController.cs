using System;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace WebAPI.Controllers
{
    //[RoutePrefix("api/fibonacci")]
    public class FibonacciController : ApiController
    {
        // GET: api/Fibonacci?n=number
        //[Route("")]
        //[Route("{n:int}")]
        //[HttpGet]
        public long Get()
        {
            try
            {
                var param = HttpContext.Current.Request.QueryString["n"];

                // querystring parameter n is required
                int value;
                if (!int.TryParse(param, out value) || param == null)
                {
                    throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound)
                    {
                        Content = new StringContent("No HTTP resource was found that matches the request URI: " + HttpContext.Current.Request.Url.AbsoluteUri),
                        ReasonPhrase = "Critical Exception"
                    });
                }

                long n = Convert.ToInt32(param);
                long a = 0;
                long b = 1;

                if (n > 100)
                {
                    return 0;
                }

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
            catch (Exception ex)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(ex.Message),
                    ReasonPhrase = "Critical Exception"
                });
            }
        }
    }
}