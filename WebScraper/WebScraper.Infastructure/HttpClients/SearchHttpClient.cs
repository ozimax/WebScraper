using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScraper.Domain.Interfaces;

namespace WebScraper.Infastructure.HttpClients
{
    public class SearchHttpClient : ISearchHttpClient
    {
        private readonly HttpClient _httpClient;

        public SearchHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetSearchResultHtmlAsync(string searchUrl, string referer = null)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, searchUrl);

            request.Headers.Add("User-Agent",
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/124.0.0.0 Safari/537.36");
            request.Headers.Add("Accept",
                "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");
            request.Headers.Add("Accept-Language", "en-GB,en;q=0.9");
            request.Headers.Add("Upgrade-Insecure-Requests", "1");
            request.Headers.Add("Cache-Control", "max-age=0");

            if (!string.IsNullOrEmpty(referer))
            {
                request.Headers.Add("Referer", referer);
            }

            var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
                throw new Exception($"Failed to fetch HTML from: {searchUrl}");

            return await response.Content.ReadAsStringAsync();
        }
    }
}
