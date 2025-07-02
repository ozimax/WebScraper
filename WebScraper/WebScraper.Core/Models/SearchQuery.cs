using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScraper.Core.Models
{
    public class SearchQuery
    {
        public string Keywords { get; set; }
        public string TargetUrl { get; set; }

        public SearchQuery(string keywords, string targetUrl)
        {
            if (string.IsNullOrWhiteSpace(keywords))
            {
                throw new ArgumentException("Keywords cannot be empty.", nameof(keywords));
            }
            if (string.IsNullOrWhiteSpace(targetUrl))
            {
                throw new ArgumentException("Target URL cannot be empty.", nameof(targetUrl));
            }
            if (!Uri.IsWellFormedUriString(targetUrl, UriKind.Absolute) && !Uri.IsWellFormedUriString($"http://{targetUrl}", UriKind.Absolute))
            {
                throw new ArgumentException("Invalid target URL format.", nameof(targetUrl));
            }

            Keywords = keywords.Trim();
            TargetUrl = NormalizeUrl(targetUrl);
        }

        private string NormalizeUrl(string url)
        {
            try
            {
                if (!url.StartsWith("http://", StringComparison.OrdinalIgnoreCase) && !url.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
                {
                    url = "http://" + url;
                }
                var uri = new Uri(url);
                string host = uri.Host.ToLowerInvariant();
                if (host.StartsWith("www.", StringComparison.OrdinalIgnoreCase))
                {
                    host = host.Substring(4);
                }
                string path = uri.AbsolutePath.TrimEnd('/');
                return $"{host}{path}".ToLowerInvariant();
            }
            catch (UriFormatException)
            {
                return url.ToLowerInvariant();
            }
        }
    }
}
