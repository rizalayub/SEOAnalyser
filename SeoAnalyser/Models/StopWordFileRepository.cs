using SeoAnalyser.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace SeoAnalyser.Models
{
    public class StopWordFileRepository : IStopWordRepository
    {
        public IEnumerable<string> GetFromSource()
        {
            var path = HttpContext.Current.Request.MapPath("~/stopword.txt");
            return File.ReadAllLines(path);
        }
    }
}