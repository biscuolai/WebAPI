using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class TriangleTypeController : ApiController
    {
        //[JsonConverter(typeof(StringEnumConverter))]
        //public enum TriangleType
        //{
        //    Scalene = 1,
        //    Isosceles = 2,
        //    Equilateral = 3,
        //    Error = 4
        //}

        // GET: api/TriangleType?a=2&b=2&c=2
        [HttpGet]
        public int Get(int a, int b, int c)
        {
            int[] values = new int[3] { a, b, c };

            var distinctCount = values.Distinct().Count();

            if ((a >= b + c) || (b >= a + c) || (c >= a + b) || (a <= 0) || (b <= 0) || (c <= 0))
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent("\"Error\""),
                });

                //return TriangleType.Error;
            }
            // There is one distinct value, so all sides are equal length
            if (distinctCount == 1)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent("\"Equilateral\""),
                });
                //return TriangleType.Equilateral;
            }
            // There are two distinct values, so two sides are equal
            if (distinctCount == 2)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent("\"Isosceles\""),
                });
                //return TriangleType.Isosceles;
            }
            // There are three distinct values, so no equal sides
            if (distinctCount == 3)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent("\"Scalene\""),
                });
                //return TriangleType.Scalene;
            }
            else
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent("\"Error\""),
                });
                //return TriangleType.Error;
            }
        }
    }
}
