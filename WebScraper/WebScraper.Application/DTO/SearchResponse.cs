using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScraper.Domain.Models;

namespace WebScraper.Application.DTO
{
    public class SearchResponse
    {
        public bool IsError { get; set; }
        public List<int> Positions { get; set; }
        public string ErrorMessage { get; set; }
        public List<SearchHistory> PreviousSearches { get; set; } = new();
    }
}
