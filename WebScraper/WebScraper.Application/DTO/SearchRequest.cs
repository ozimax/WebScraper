using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScraper.Application.Models;

namespace WebScraper.Application.DTO
{
    public class SearchRequest
    {
        public string Keywords { get; set; }
        public string TargetUrl { get; set; }
        public int NumberOfResults { get; set; }
        public SearchEngineType Engine { get; set; }
    }
}
