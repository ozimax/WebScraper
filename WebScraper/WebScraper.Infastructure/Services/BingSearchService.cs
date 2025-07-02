using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WebScraper.Domain.Interfaces;
using WebScraper.Domain.Models;
using WebScraper.Infastructure.Interfaces;

namespace WebScraper.Infastructure.Services
{
    public class BingSearchService : ISearchEngineService
    {
        private readonly ISearchHttpClient _searchHttpClient;

        public BingSearchService(ISearchHttpClient searchHttpClient)
        {
            _searchHttpClient = searchHttpClient;
        }

        public async Task<SearchResult> GetSearchResultPositionsAsync(string keywords, string url, int numOfResults)
        {
            var searchUrl = $"https://www.bing.com/search?q={Uri.EscapeDataString(keywords)}&count={numOfResults}&cc=GB";

            try
            {
                var html = await _searchHttpClient.GetSearchResultHtmlAsync(searchUrl, "https://www.bing.com/");
                File.WriteAllText("bing_result.html", html);

                var results = new List<int>();
                var matches = Regex.Matches(html, @"<li class=""b_algo"".*?<a href=""(http.*?)""", RegexOptions.Singleline);

                int position = 1;
                foreach (Match match in matches)
                {
                    var foundUrl = match.Groups[1].Value;
                    if (foundUrl.Contains(url, StringComparison.OrdinalIgnoreCase))
                        results.Add(position);

                    position++;
                }

                return new SearchResult
                {
                    IsSuccess = true,
                    Positions = results.Count > 0 ? results : new List<int> { 0 }
                };
            }
            catch (Exception ex)
            {
                return new SearchResult
                {
                    IsSuccess = false,
                    ErrorMessage = $"[Bing ERROR] {ex.Message}"
                };
            }
        }
    }
}
