using SEOResultChecker.Core.Models;
using SEOResultChecker.DomainLogic;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace SEOResultChecker.Service
{
    /// <summary>
    /// simple service/helper class to call the google url and use <see cref="ParseEngine"/> to prcess the results
    /// </summary>
    public class GoogleSearchService : ISearchService
    {
        private const string BaseSearchUrl = "https://www.google.com.au/search?q={0}&num={1}";
        private const int DefaultNumberOfRecords = 100;

        private ParseEngine _parseEngine;

        public IEnumerable<SEOResult> GetResults(string query, string keyword, int numberOfRecords = DefaultNumberOfRecords)
        {
            var htmlResult = GetHtmlFromUrl(string.Format(BaseSearchUrl, query, numberOfRecords));

            return _parseEngine.ParseResults(htmlResult, keyword);
        }

        public GoogleSearchService()
        {
            _parseEngine = new ParseEngine(new GoogleSEOResultParser());
        }

        private string GetHtmlFromUrl(string url)
        {
            HttpClient client = new HttpClient();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls13;
            client.DefaultRequestHeaders.Accept.Clear();
            var response = Convert.ToString(client.GetStringAsync(url).Result);
            return response;
        }
    }
}
