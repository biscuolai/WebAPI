using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class ReverseWordsController : ApiController
    {
        // GET: api/ReverseWords?sentence=xxx
        public string Get()
        {
            //TODO - Might give it a go to implement [FromUri] - swagger not
            // showing parameter as required
            // get sentence from querystring
            string sentence = HttpContext.Current.Request.QueryString["sentence"];

            // if querystring is empty or missing querystring parameter
            // return empty string
            if (string.IsNullOrEmpty(sentence))
            {
                return string.Empty;
            }

            // copies the characters in a portion of a string to a character array
            char[] sentenceCharArray = sentence.ToCharArray();
            // reverse all characters in the array
            Array.Reverse(sentenceCharArray);
            // return array of char as string
            return new string(sentenceCharArray);
        }
    }
}
