using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeoAnalyser;
using SeoAnalyser.Controllers;
using SeoAnalyser.Models;
using SeoAnalyser.Services;

namespace SeoAnalyser.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

      
        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;
            
            // Assert
            Assert.IsNotNull(result);
        }

        [DataTestMethod]
        [DataRow("http://www.google.com")]
        public void FilterStopWord_URL(string value)
        {
            StopWords model = new StopWords();
            ISeoFilter seoFilter = new StopWordUrlFilterService();
            IEnumerable<StopWords> resultLink = new List<StopWords>();

            string response = seoFilter.GetDataFromSource(value);
            var res = seoFilter.GetResponseBody(response);
            var result = seoFilter.CalculateStopCount(res);
            var resultBody = model.PopulateStopWords(result);

            Assert.IsNotNull(resultBody,"Stop Words is available");
        }

        [DataTestMethod]
        [DataRow("and and my name is rizal ayub or muhamad rizal, I like to work as software developer")]
        public void FilterStopWord_Text(string value)
        {
            StopWords model = new StopWords();
            ISeoFilter seoFilter = new StopWordTextFilterService();
            IEnumerable<StopWords> resultLink = new List<StopWords>();

            string response = seoFilter.GetDataFromSource(value);
            var res = seoFilter.GetResponseBody(response);
            var result = seoFilter.CalculateStopCount(res);
            var resultBody = model.PopulateStopWords(result);

            var body = resultBody.FirstOrDefault().Body;

            Assert.IsTrue(resultBody.Any( c => c.Word == "and" && c.Count==2) , "Word 'and' is 2 count");
        }


        private static FormCollection CreateFormCollection(string data)
        {

            FormCollection form = new FormCollection();

            form.Add("url", data);

            return form;
        }
    }
}
