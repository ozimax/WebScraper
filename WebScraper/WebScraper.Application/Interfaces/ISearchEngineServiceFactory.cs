using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScraper.Application.Models;
using WebScraper.Infastructure.Interfaces;

namespace WebScraper.Application.Interfaces
{
    public interface ISearchEngineServiceFactory
    {
        ISearchEngineService GetSearchEngine(SearchEngineType engine);
    }
}
