using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScraper.Domain.Models;

namespace WebScraper.Infastructure.Interfaces
{
    public interface ISearchEngineService
    {
        public Task<SearchResult> GetSearchResultPositionsAsync(string keywords, string url, int numOfResults);
    }
}
