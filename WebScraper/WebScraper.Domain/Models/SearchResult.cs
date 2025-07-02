using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScraper.Domain.Models
{
    public class SearchResult
    {
        public bool IsSuccess { get; set; }
        public List<int> Positions { get; set; } = new();
        public string ErrorMessage { get; set; }
    }
}
