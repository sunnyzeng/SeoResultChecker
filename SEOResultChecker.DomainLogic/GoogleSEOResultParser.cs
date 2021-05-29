using SEOResultChecker.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SEOResultChecker.DomainLogic
{
    /// <summary>
    /// Google search result parser
    /// </summary>
    public class GoogleSEOResultParser : IResultParser
    {
        private const string RegexExpressionForGoogleResults = "<div class=\"([a-zA-Z]*?)\"><a href=\"/url?(.*?)</div></a></div>";
        private const string RegexExpressionForUrl = "(^[^?]*$|(?<=\\?).*)&amp;sa=U&amp;";
        private const string RegexExpressionForTitle = "<h3 class(.*?)</h3>";
        private Regex _regex, _titleRegex, _urlRegex;

        private Regex SearchResultsRegex
        {
            get { return _regex ?? (_regex = new Regex(RegexExpressionForGoogleResults)); }
        }

        private Regex TitleRegex
        {
            get { return _titleRegex ?? (_titleRegex = new Regex(RegexExpressionForTitle)); }
        }

        private Regex UrlRegex
        {
            get { return _urlRegex ?? (_regex = new Regex(RegexExpressionForUrl)); }
        }

        public SEOResult Parse(string html)
        {
            return GetSEOResult(html, -1);
        }

        /// <summary>
        /// Parse the html result and convert into <see cref="SEOResult"/>s
        /// <remarks>null/empty keyword means no filtering applied</remarks>
        /// </summary>
        public IEnumerable<SEOResult> ParseAll(string html, string keyword)
        {
            var matches = SearchResultsRegex.Matches(html).Cast<Match>().ToList();

            var seoResults = matches.Select((match, i) => new { i, x = match })
                .Where(x => string.IsNullOrEmpty(keyword) || x.ToString().Contains(keyword))
                .Select(x => GetSEOResult(x.x.Value, x.i + 1))
                .ToList();

            return seoResults;
        }

        /// <summary>
        /// parse the single Google search result html into one <see cref="SEOResult"/>
        /// </summary>
        private SEOResult GetSEOResult(string singleResultDiv, int rank)
        {
            var title = TitleRegex.Match(singleResultDiv).Value;

            title = title.Substring(title.LastIndexOf("\">") + 2, title.IndexOf("</div") - title.LastIndexOf("\">") - 2);
            var url = UrlRegex.Match(singleResultDiv).Value;

            url = url.Substring(url.IndexOf("http"), url.IndexOf("&amp;") - url.IndexOf("http"));

            return new SEOResult()
            {
                Rank = rank,
                Name = title,
                Url = url,
            };
        }
    }
}