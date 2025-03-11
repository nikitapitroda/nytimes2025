using Core.DTO;
using Core.Entities;
using Core.Interfaces;
using Newtonsoft.Json;

namespace Infrastructure.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task<List<Article>> GetArticlesAsync()
        {
            return await _articleRepository.GetArticlesAsync();
        }

        public async Task FetchAndStoreArticlesAsync(string apiKey)
        {
            var url = $"https://api.nytimes.com/svc/topstories/v2/home.json?api-key={apiKey}";
            using (var client = new HttpClient())
            {
                var response = await client.GetStringAsync(url);

                var articleResponse = JsonConvert.DeserializeObject<ArticleResponse>(response);

                if (articleResponse?.Results == null || articleResponse.Results.Count == 0)
                {
                    throw new KeyNotFoundException("No articles found in the response.");
                }

                var articles = new List<Article>();
                foreach (var article in articleResponse.Results)
                {
                    var articleEntity = new Article
                    {
                        Section = article.Section,
                        Subsection = article.Subsection,
                        Title = article.Title,
                        Abstract = article.Abstract,
                        Url = article.Url,
                        Byline = article.Byline,
                        UpdatedDate = article.UpdatedDate,
                        CreatedDate = article.CreatedDate,
                        PublishedDate = article.PublishedDate
                    };

                    articles.Add(articleEntity);
                }

                await _articleRepository.AddArticlesAsync(articles);
            }
        }
    }
}
