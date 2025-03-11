using Core.DTO;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IArticleService
    {
        Task<List<Article>> GetArticlesAsync();
        Task FetchAndStoreArticlesAsync(string apiKey);
    }
}
