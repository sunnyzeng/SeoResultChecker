using System.Collections.Generic;
using SEOResultChecker.Core.Models;

namespace SEOResultChecker.Service
{
    public interface ISearchService
    {
        public IEnumerable<SEOResult> GetResults(string query, string keyword, int numberOfRecords);
    }
}