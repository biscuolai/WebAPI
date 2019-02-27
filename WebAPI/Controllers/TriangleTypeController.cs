using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class TriangleTypeController : ApiController
    {
        // It might be a bug - implement later.
        //public enum TriangleType
        //{
        //    Scalene = 1,        
        //    Isosceles = 2,      
        //    Equilateral = 3,    
        //    Error = 4           
        //}

        // GET: api/TriangleType?a=x&b=y&c=z
        public string Get()
        {
            //TODO - Might give it a go to implement [FromUri] - swagger not
            // showing parameter as required

            // Make parameters required same as Readify
            // Calling api without querystring parameters:
            //{"message":"No HTTP resource was found that matches the request URI 'https://knockknock.readify.net/api/TriangleType'."}

            // get parameters from querystring
            var paramA = HttpContext.Current.Request.QueryString["a"];
            var paramB = HttpContext.Current.Request.QueryString["b"];
            var paramC = HttpContext.Current.Request.QueryString["c"];

            if (paramA == null ||
                paramB == null || 
                paramC == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent("No HTTP resource was found that matches the request URI: " + HttpContext.Current.Request.Url.AbsoluteUri),
                    ReasonPhrase = "Critical Exception"
                });
            }

            int a = Convert.ToInt32(paramA);
            int b = Convert.ToInt32(paramB);
            int c = Convert.ToInt32(paramC);

            if (a == b && b == c)
            {
                return "Equilateral";
            }
            else if ((a == b) || (b == c) || (a == c))
            {
                return "Isosceles";
            }
            else if ((a >= b + c) || (b >= a + c) || (c >= a + b) || (a <= 0) || (b <= 0) || (c <= 0))
            {
                return "Error";
            }
            else
            {
                return "Scalene";
            }
        }
    }
}
