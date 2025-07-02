using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScraper.Core.Models
{
    namespace InfoTrack.SEO.Core.Models
    {
        public class GoogleSearchResult
        {
            public string Title { get; set; }
            public string Link { get; set; }
            public string Snippet { get; set; }

            public GoogleSearchResult(string title, string link, string snippet)
            {
                Title = title;
                Link = link;
                Snippet = snippet;
            }

            // Checks if THIS result's link matches our target URL, handling different formats
            public bool IsTargetUrl(string normalizedTargetUrl)
            {
                if (string.IsNullOrWhiteSpace(normalizedTargetUrl) || string.IsNullOrWhiteSpace(Link)) return false;

                try
                {
                    string resultLink = Link;
                    if (!resultLink.StartsWith("http://", StringComparison.OrdinalIgnoreCase) && !resultLink.StartsWith("https://", StringComparison.OrdinalIgnoreCase)) resultLink = "http://" + resultLink;
                    var uri = new Uri(resultLink);
                    string host = uri.Host.ToLowerInvariant();
                    if (host.StartsWith("www.", StringComparison.OrdinalIgnoreCase)) host = host.Substring(4);
                    string path = uri.AbsolutePath.TrimEnd('/');
                    string normalizedResultLink = $"{host}{path}".ToLowerInvariant();

                    return normalizedResultLink.Contains(normalizedTargetUrl);
                }
                catch { return false; }
            }
        }
    }
}
