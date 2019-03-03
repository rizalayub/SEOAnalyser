using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeoAnalyser.Models
{
    public interface IUrlFilter
    {
        IEnumerable<string> GetResponseLink(string response);
    }
}
