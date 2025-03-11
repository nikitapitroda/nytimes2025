using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleService _articleService;

        public ArticlesController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpPost("fetch-data")]
        public async Task<IActionResult> FetchData([FromBody] string apiKey)
        {
            try
            {
                await _articleService.FetchAndStoreArticlesAsync(apiKey);
                return Ok(new { message = "Data fetched and stored successfully" });
            }
            catch (KeyNotFoundException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("get-articles")]
        public async Task<IActionResult> GetArticles()
        {
            var articles = await _articleService.GetArticlesAsync();

            var groupedArticles = articles
                .GroupBy(a => a.Section)
                .Select(sectionGroup => new
                {
                    Section = sectionGroup.Key,
                    Subsections = sectionGroup
                        .GroupBy(a => a.Subsection)
                        .Select(subsectionGroup => new
                        {
                            Subsection = subsectionGroup.Key,
                            Articles = subsectionGroup.ToList()
                        })
                        .ToList()
                }).ToList();

            return Ok(groupedArticles);
        }
    }
}


