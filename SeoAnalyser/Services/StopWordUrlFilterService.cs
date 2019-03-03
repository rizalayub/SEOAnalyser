using HtmlAgilityPack;
using SeoAnalyser.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace SeoAnalyser.Services
{
    public class StopWordUrlFilterService : BaseFilterService, ISeoFilter, IUrlFilter
    {
       
        public string GetDataFromSource(string source)
        {
            // Create a request for the URL.   
            WebRequest request = WebRequest.Create(source);
            // If required by the server, set the credentials.  
            request.Credentials = CredentialCache.DefaultCredentials;
            // Get the response.  
            WebResponse response = request.GetResponse();
            // Get the stream containing content returned by the server.  
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.  
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.  
            string responseFromServer = reader.ReadToEnd();
            // Clean up the streams and the response.  
            reader.Close();
            response.Close();

            return responseFromServer;

        }

        public string GetResponseBody(string response)
        {
            HtmlDocument htmlDoc = new HtmlDocument();

            //Convert the Raw HTML into an HTML Object
            htmlDoc.LoadHtml(response);

            var body = htmlDoc.DocumentNode.SelectNodes("//body");

            return body.First().InnerText;

            //Console.WriteLine("The title of the page is:");
            //Console.WriteLine(titleNodes.FirstOrDefault().InnerText);
           
        }



        public IEnumerable<string> GetResponseLink(string response)
        {
            List<string> link = new List<string>();
            HtmlDocument htmlDoc = new HtmlDocument();

            //Convert the Raw HTML into an HTML Object
            htmlDoc.LoadHtml(response);

            var anchorNodes = htmlDoc.DocumentNode.SelectNodes("//a");

            if (anchorNodes != null)
            {


                foreach (var anchorNode in anchorNodes)
                {
                    link.Add(anchorNode.InnerText);
                }
            }

            return link;

        }
    }
}