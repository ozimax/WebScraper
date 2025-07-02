using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebScraper.Application.DTO;
using WebScraper.Application.Interfaces;
using WebScraper.Application.Services;
using WebScraper.Domain.Interfaces;
using WebScraper.Domain.Models;

namespace WebScraper.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeoController : ControllerBase
    {
        private readonly ISearchService _searchService;

        public SeoController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        [HttpPost("search")]
        public async Task<IActionResult> Search([FromBody] SearchRequest request)
        {           
            var response = await _searchService.PerformSearchAsync(request);

            if (response.IsError)
                return BadRequest(response);

            return Ok(response);

            
        }
    }
}
