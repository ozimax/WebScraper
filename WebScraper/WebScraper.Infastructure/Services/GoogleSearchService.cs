using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using WebScraper.Domain.Interfaces;
using WebScraper.Domain.Models;
using WebScraper.Infastructure.Interfaces;

namespace WebScraper.Infastructure.Services
{
    public class GoogleSearchService : ISearchEngineService
    {
        private readonly ISearchHttpClient _searchHttpClient;

        public GoogleSearchService(ISearchHttpClient searchHttpClient)
        {
            _searchHttpClient = searchHttpClient;
        }

        public async Task<SearchResult> GetSearchResultPositionsAsync(string keywords, string url, int numOfResults)
        {
            var searchUrl = $"https://www.google.co.uk/search?num={numOfResults}&q={Uri.EscapeDataString(keywords)}";

            try
            {
                var html = await _searchHttpClient.GetSearchResultHtmlAsync(searchUrl, "https://www.google.co.uk/");
                File.WriteAllText("google_result.html", html);

                if (html.Contains("If you're having trouble accessing Google Search"))
                    return new SearchResult { IsSuccess = false, ErrorMessage = "Google is blocking this request." };

                var results = new List<int>();
                var matches = Regex.Matches(html, @"<a href=""/url\?q=(.*?)&");

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
                    ErrorMessage = $"[Google ERROR] {ex.Message}"
                };
            }
        }

    }
}
