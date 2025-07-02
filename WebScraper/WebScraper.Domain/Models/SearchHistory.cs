using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScraper.Domain.Models
{
    public class SearchHistory
    {
        public string Keywords { get; set; }
        public string TargetUrl { get; set; }
        public string EngineType { get; set; }
        public List<int> Positions { get; set; }
        public DateTime SearchedAt { get; set; }
    }
}
