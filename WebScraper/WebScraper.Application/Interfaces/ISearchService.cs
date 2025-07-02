using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScraper.Application.DTO;

namespace WebScraper.Application.Interfaces
{
    public interface ISearchService
    {
        Task<SearchResponse> PerformSearchAsync(SearchRequest request);
    }
}
