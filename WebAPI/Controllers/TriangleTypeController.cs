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

            try
            {
                // get parameters from querystring
                var paramA = HttpContext.Current.Request.QueryString["a"];
                var paramB = HttpContext.Current.Request.QueryString["b"];
                var paramC = HttpContext.Current.Request.QueryString["c"];

                int a;
                int b;
                int c;
                if (!int.TryParse(paramA, out a) ||
                    !int.TryParse(paramB, out b) ||
                    !int.TryParse(paramC, out c) || 
                    paramA == null ||
                    paramB == null ||
                    paramC == null
                    )
                {
                    throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound)
                    {
                        Content = new StringContent("No HTTP resource was found that matches the request URI: " + HttpContext.Current.Request.Url.AbsoluteUri),
                        ReasonPhrase = "Critical Exception"
                    });
                }

                //int a = Convert.ToInt32(paramA);
                //int b = Convert.ToInt32(paramB);
                //int c = Convert.ToInt32(paramC);

                int[] values = new int[3] { a, b, c };

                var distinctCount = values.Distinct().Count();

                if ((a >= b + c) || (b >= a + c) || (c >= a + b) || (a <= 0) || (b <= 0) || (c <= 0))
                {
                    return "Error";
                }
                if (distinctCount == 1) //There is only one distinct value in the set, therefore all sides are of equal length
                {
                    return "Equilateral";
                }
                if (distinctCount == 2) //There are only two distinct values in the set, therefore two sides are equal and one is not
                {
                    return "Isosceles";
                }
                if (distinctCount == 3) // There are three distinct values in the set, therefore no sides are equal
                {
                    return "Scalene";
                }
                else
                {
                    return "Error";
                }

                //if (a == b && b == c)
                //{
                //    return "Equilateral";
                //}
                //else if ((a == b) || (b == c) || (a == c))
                //{
                //    return "Isosceles";
                //}
                //else if ((a >= b + c) || (b >= a + c) || (c >= a + b) || (a <= 0) || (b <= 0) || (c <= 0))
                //{
                //    return "Error";
                //}
                //else
                //{
                //    return "Scalene";
                //}
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
