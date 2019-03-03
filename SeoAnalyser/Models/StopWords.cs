using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeoAnalyser.Models
{
    public class StopWords
    {
        public string Word { get; set; }
        public int Count { get; set; }

        public IEnumerable<StopWords> Body { get; set; }
        public IEnumerable<StopWords> Link { get; set; }

        public IEnumerable<StopWords> PopulateStopWords(Dictionary<string, int> stopWords)
        {
            List<StopWords> stop = new List<StopWords>();

            foreach(var data in stopWords)
            {
                stop.Add(new StopWords
                {
                    Word = data.Key,
                    Count = data.Value
                });
            }

            return stop;

        }
    }
}