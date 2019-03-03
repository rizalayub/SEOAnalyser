using SeoAnalyser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeoAnalyser.Services
{
    public class BaseFilterService
    {
        public IEnumerable<string> GetFilter()
        {
            IStopWordRepository file = new StopWordFileRepository();
            return file.GetFromSource();
        }
        public Dictionary<string, int> CalculateStopCount(string source)
        {
            List<string> s = GetFilter().ToList();
            Dictionary<string, int> stopWordsCount = new Dictionary<string, int>();

            foreach (var stop in s)
            {
                bool loop = true;
                int i = 0;
                int count = 0;
                while (loop)
                {

                    i = source.IndexOf(stop, i );
                    if (i != -1)
                    {
                        if (count == 0)
                        {
                            stopWordsCount.Add(stop, ++count);
                        }
                        else
                        {
                            stopWordsCount[stop] = ++count;
                        }
                        ++i;

                    }
                    else
                    {
                        loop = false;
                    }

                }

            }

            return stopWordsCount;
        }
    }
}