using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScraper.Application.DTO;
using WebScraper.Application.Interfaces;
using WebScraper.Domain.Models;
using WebScraper.Infastructure.Interfaces;

namespace WebScraper.Application.Services
{

    public class SearchService : ISearchService
    {
        private readonly ISearchEngineServiceFactory _searchEngineFactory;
        private readonly ISearchHistoryLogger _searchHistoryLogger;

        public SearchService(ISearchEngineServiceFactory searchEngineFactory, ISearchHistoryLogger searchHistoryLogger)
        {
            _searchEngineFactory = searchEngineFactory;
            _searchHistoryLogger = searchHistoryLogger;
        }

        public async Task<SearchResponse> PerformSearchAsync(SearchRequest request)
        {
            var engine = _searchEngineFactory.GetSearchEngine(request.Engine);

            var result = await engine.GetSearchResultPositionsAsync(
                request.Keywords, request.TargetUrl, request.NumberOfResults);

            if(result.IsSuccess)
            {
                var history = new SearchHistory
                {
                    Keywords = request.Keywords,
                    TargetUrl = request.TargetUrl,
                    EngineType = request.Engine.ToString(),
                    Positions = result.Positions,
                    SearchedAt = DateTime.UtcNow
                };

                await _searchHistoryLogger.LogAsync(history);
            }

            var previousSearches = await _searchHistoryLogger.GetPreviousSearchesAsync(
            request.Keywords, request.TargetUrl, request.Engine.ToString());

            return new SearchResponse
            {
                Positions = result.Positions,
                IsError = !result.IsSuccess,
                ErrorMessage = result.ErrorMessage,
                PreviousSearches = previousSearches
            };
        }
    }

}
