using System;
using System.Linq;
using Caliburn.Micro;
using SEOResultChecker.Core.Models;
using SEOResultChecker.Service;

namespace SEOResultChecker.UI.ViewModels
{
    public class ShellViewModel : Conductor<IScreen>
    {
        private ISearchService _googleSearchService;

        private string _keyword;
        private string _target;
        private int _recordsCount;
        private string _seoResult;

        private BindableCollection<SEOResult> _seoResults;

        public string Keyword
        {
            get { return _keyword; }
            set
            {
                _keyword = value;
                NotifyOfPropertyChange(() => Keyword);
                NotifyOfPropertyChange(() => CanSearch);
            }
        }

        public string Target
        {
            get { return _target; }
            set
            {
                _target = value;
                NotifyOfPropertyChange(() => Target);
                NotifyOfPropertyChange(() => CanSearch);
            }
        }

        public int RecordsCount
        {
            get { return _recordsCount; }
            set
            {
                _recordsCount = value;
                NotifyOfPropertyChange(() => RecordsCount);
            }
        }

        public string SEOResult
        {
            get { return _seoResult; }
            set
            {
                if (value == _seoResult)
                    return;
                _seoResult = value;

                NotifyOfPropertyChange(() => SEOResult);
            }
        }

        public BindableCollection<SEOResult> SeoResults
        {
            get { return _seoResults; }
            set
            {
                _seoResults = value;

                NotifyOfPropertyChange(() => SeoResults);
            }
        }

        public ShellViewModel(ISearchService googleSearchService)
        {
            _googleSearchService = googleSearchService;

            DisplayName = "SEO Result Checker";
            SeoResults = new BindableCollection<SEOResult>();

            SetDefaults();
        }

        public bool CanSearch
        {
            get { return !string.IsNullOrWhiteSpace(Keyword); }
        }

        public void Search()
        {
            var result = _googleSearchService.GetResults(Keyword, Target, RecordsCount);

            SEOResult = string.Join(",", result.Select(r => r.Rank));

            SeoResults.Clear();
            SeoResults.AddRange(result);

            NotifyOfPropertyChange(() => SeoResults);
        }

        public void Reset()
        {
            SetDefaults();
        }

        private void SetDefaults()
        {
            Keyword = "conveyancing software";
            Target = "www.smokeball.com.au";
            RecordsCount = 100;
            SEOResult = string.Empty;
        }

        private void ClearResults()
        {
            SEOResult = String.Empty;
            SeoResults.Clear();
        }
    }
}