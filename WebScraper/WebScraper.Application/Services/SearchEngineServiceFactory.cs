using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScraper.Application.Interfaces;
using WebScraper.Application.Models;
using WebScraper.Infastructure.Interfaces;
using WebScraper.Infastructure.Services;

namespace WebScraper.Application.Services
{
    public class SearchEngineServiceFactory : ISearchEngineServiceFactory
    {
        private readonly GoogleSearchService _googleSearch;
        private readonly BingSearchService _bingSearch;

        public SearchEngineServiceFactory(GoogleSearchService googleSearch, BingSearchService bingSearch)
        {
            _googleSearch = googleSearch;
            _bingSearch = bingSearch;
        }

        public ISearchEngineService GetSearchEngine(SearchEngineType engine)
        {
            return engine switch
            {
                SearchEngineType.Google => _googleSearch,
                SearchEngineType.Bing => _bingSearch,
                _ => throw new NotSupportedException("Unsupported search engine.")
            };
        }
    }
}
