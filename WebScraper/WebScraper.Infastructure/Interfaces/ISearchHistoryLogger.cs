using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScraper.Domain.Models;

namespace WebScraper.Infastructure.Interfaces
{
    public interface ISearchHistoryLogger
    {
        Task LogAsync(SearchHistory history);
        Task<List<SearchHistory>> GetPreviousSearchesAsync(string keywords, string targetUrl, string engineType);
    }

}
