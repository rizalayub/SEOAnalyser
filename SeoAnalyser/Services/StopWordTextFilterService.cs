using HtmlAgilityPack;
using SeoAnalyser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeoAnalyser.Services
{
    public class StopWordTextFilterService : BaseFilterService, ISeoFilter
    {
        

        public string GetDataFromSource(string source)
        {
            return source;
        }

        public string GetResponseBody(string response)
        {
            return response;
        }
    }
}