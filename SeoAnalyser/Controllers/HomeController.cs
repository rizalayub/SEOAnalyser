using HtmlAgilityPack;
using SeoAnalyser.Models;
using SeoAnalyser.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SeoAnalyser.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FilterStopWord(FormCollection form)
        {
            string source = "";
            string url = "";
            StopWords sw = new StopWords();
            ISeoFilter seoFilter = null;
            IUrlFilter urlFilter = new StopWordUrlFilterService();
            IEnumerable<StopWords> resultLink = new List<StopWords>();

            if (form["url"]==null)
            {
                source = form["anytext"].ToString();
                seoFilter = new StopWordTextFilterService();
            }
            else
            {
                source = form["url"].ToString();
                url = source;
                seoFilter = new StopWordUrlFilterService();
            }
           
            string response = seoFilter.GetDataFromSource(source);
            var res= seoFilter.GetResponseBody(response);
            var result = seoFilter.CalculateStopCount(res);
            var resultBody = sw.PopulateStopWords(result);
            if (seoFilter is StopWordUrlFilterService)
            {
                var link = urlFilter.GetResponseLink(response);
                var str = string.Join(",", link);
                var result1 = seoFilter.CalculateStopCount(str);
                resultLink = sw.PopulateStopWords(result1);
            }
            ViewBag.Url = url;

            sw.Body = resultBody;
            sw.Link = resultLink;

            return View(sw);
        }

        [HttpPost]
        public ActionResult StopWordOption(FormCollection form)
        {
            string option=form["optradio"].ToString();
            ViewBag.Option = option;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}