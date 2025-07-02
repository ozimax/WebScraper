using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using WebScraper.Domain.Models;
using WebScraper.Infastructure.Interfaces;

namespace WebScraper.Infastructure.Services
{
    public class JsonSearchHistoryLogger : ISearchHistoryLogger
    {
        private readonly string _logFilePath = "search_history.json";

        public async Task LogAsync(SearchHistory history)
        {
            var histories = await LoadAllAsync();
            histories.Add(history);

            var json = JsonConvert.SerializeObject(histories, Newtonsoft.Json.Formatting.Indented);
            await File.WriteAllTextAsync(_logFilePath, json);
        }

    

        public async Task<List<SearchHistory>> GetPreviousSearchesAsync(string keywords, string targetUrl, string engineType)
        {
            var histories = await LoadAllAsync();

            return histories
                .Where(h =>
                    string.Equals(h.Keywords, keywords, StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(h.TargetUrl, targetUrl, StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(h.EngineType, engineType, StringComparison.OrdinalIgnoreCase))
                .OrderByDescending(h => h.SearchedAt)
                .ToList();
        }

        private async Task<List<SearchHistory>> LoadAllAsync()
        {
            if (!File.Exists(_logFilePath))
                return new List<SearchHistory>();

            var json = await File.ReadAllTextAsync(_logFilePath);
            return JsonConvert.DeserializeObject<List<SearchHistory>>(json) ?? new List<SearchHistory>();
        }
    }

}
