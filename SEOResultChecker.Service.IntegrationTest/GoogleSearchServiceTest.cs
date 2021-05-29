using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SEOResultChecker.Service.IntegrationTest
{
    [TestClass]
    public class GoogleSearchServiceTest
    {
        private GoogleSearchService _googleSearchService;

        [TestInitialize]
        public void GoogleSearchServiceTestInitialize()
        {
            _googleSearchService = new GoogleSearchService();
        }

        [TestMethod]
        public void GoogleSearchService_SearchConveyancingSoftware_Smokeball()
        {
            var results = _googleSearchService.GetResults("conveyancing software", "www.smokeball.com.au");

            Assert.AreEqual(1, results.Count());

            var smokeBallResult = results.First();
            Assert.AreEqual("Conveyancing Software - Smokeball", smokeBallResult.Name);
            Assert.AreEqual("https://www.smokeball.com.au/conveyancing.html", smokeBallResult.Url);
        }

        [TestMethod]
        public void GoogleSearchService_SearchTop20()
        {
            var results = _googleSearchService.GetResults("conveyancing software", null, 20);

            Assert.AreEqual(20, results.Count());
        }

        [TestMethod]
        public void GoogleSearchService_SearchTop47()
        {
            var results = _googleSearchService.GetResults("conveyancing software", string.Empty, 47);

            Assert.AreEqual(47, results.Count());
        }

        [TestMethod]
        public void GoogleSearchService_SearchQantas_Check_Filters()
        {
            var resultsWithoutFilter = _googleSearchService.GetResults("qantas airlines", null);
            var filteredResults = resultsWithoutFilter.Where(result => result.Url.Contains("www.qantas.com"));

            var results = _googleSearchService.GetResults("qantas airlines", "www.qantas.com");

            Assert.AreEqual(filteredResults.Count(), results.Count());
        }
    }
}
