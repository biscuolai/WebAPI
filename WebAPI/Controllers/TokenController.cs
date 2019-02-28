using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
//using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class TokenController : ApiController
    {
        // GET api/Token
        [HttpGet]
        public Guid Get()
        {
            return new Guid("f025758f-5f7c-445d-90fb-52bc44fc36f9");
        }

        // GET api/Token
        //public HttpResponseMessage Get(int id)
        //{
        //    try
        //    {
        //        Guid guidToken = new Guid("f025758f-5f7c-445d-90fb-52bc44fc36f9");

        //        KnockKnock model = new KnockKnock();
        //        model.ApplicantId = guidToken;

        //        var jsonToken = JsonConvert.SerializeObject(model);

        //        IContentNegotiator negotiator = this.Configuration.Services.GetContentNegotiator();
        //        ContentNegotiationResult result = negotiator.Negotiate(typeof(KnockKnock), this.Request, this.Configuration.Formatters);

        //        if (result == null)
        //        {
        //            var response = new HttpResponseMessage(HttpStatusCode.NotAcceptable);
        //            throw new HttpResponseException(response);
        //        }

        //        return new HttpResponseMessage()
        //        {
        //            Content = new ObjectContent<KnockKnock>(
        //                model,                      // type of object to be serialized
        //                result.Formatter,           // The media formatter
        //                result.MediaType.MediaType  // The MIME type
        //            )
        //        };
        //    }
        //    catch (Exception)
        //    {
        //        return new HttpResponseMessage(HttpStatusCode.InternalServerError);
        //    }
        //}
    }
}
