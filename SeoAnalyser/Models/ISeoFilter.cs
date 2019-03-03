using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeoAnalyser.Models
{
    public interface ISeoFilter
    {
        string GetDataFromSource(string source);
        string GetResponseBody(string response);
        Dictionary<string, int> CalculateStopCount(string source);
    }
}
