using System.Collections.Generic;
using SEOResultChecker.Core.Models;

namespace SEOResultChecker.DomainLogic
{
    /// <summary>
    /// helper class to parse string into <see cref="SEOResult"/>s
    /// </summary>
    public class ParseEngine
    {
        private IResultParser _googleSeoResultParser;

        public ParseEngine(IResultParser parser)
        {
            _googleSeoResultParser = parser;
        }

        public IEnumerable<SEOResult> ParseResults(string html, string keyword)
        {
            return _googleSeoResultParser.ParseAll(html, keyword);
        }

        public SEOResult ParseResult(string html)
        {
            return _googleSeoResultParser.Parse(html);
        }
    }
}