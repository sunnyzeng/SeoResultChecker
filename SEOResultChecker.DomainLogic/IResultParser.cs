using System.Collections.Generic;
using SEOResultChecker.Core.Models;

namespace SEOResultChecker.DomainLogic
{
    public interface IResultParser
    {
        public SEOResult Parse(string html);

        public IEnumerable<SEOResult> ParseAll(string html, string keyword);
    }
}