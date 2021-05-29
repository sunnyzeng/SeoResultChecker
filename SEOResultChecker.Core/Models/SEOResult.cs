namespace SEOResultChecker.Core.Models
{
    /// <summary>
    /// simple DTO model for the SEO result
    /// </summary>
    public class SEOResult
    {
        /// <summary>
        /// name or tile of the search result
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// url attached to the result
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// rank of current record in the list
        /// </summary>
        public int Rank { get; set; }
    }
}