using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScraper.Domain.Interfaces
{
    public interface ISearchHttpClient
    {
        Task<string> GetSearchResultHtmlAsync(string searchUrl, string referer = null);
    }
}
