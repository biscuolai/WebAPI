using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class ReverseWordsController : ApiController
    {
        // GET: api/ReverseWords?sentence=xxx
        [HttpGet]
        public string Get(string sentence)
        {
            try
            {
                // if missing from querystring parameter
                // return empty string
                if (string.IsNullOrEmpty(sentence))
                {
                    return string.Empty;
                }

                // Reverses the letters of each word in a sentence. 
                // If there is white space between words, keep it and reverse only characters between the words
                if (sentence.Trim().Contains(" "))
                {
                    string[] words = sentence.Split(' ');
                    StringBuilder reverseSentence = new StringBuilder();
                    foreach (string word in words)
                    {
                        // reverse characters for every single word
                        reverseSentence.Append(ReverseWord(word) + " ");
                    }
                    return reverseSentence.ToString().Trim();
                }
                else
                {
                    // reverse characters in the whole sentence - no white spaces.
                    return ReverseWord(sentence);
                }
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(ex.Message),
                });
            }
        }

        private string ReverseWord(string word)
        {
            // copies the characters in a portion of a string to a character array
            char[] wordCharArray = word.ToCharArray();
            // reverse all characters in the array
            Array.Reverse(wordCharArray);
            // return array of char as string
            return new string(wordCharArray);
        }
    }
}
