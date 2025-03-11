using Core.Entities;

namespace Core.Interfaces
{
    public interface IArticleRepository
    {
        Task<List<Article>> GetArticlesAsync();
        Task AddArticlesAsync(List<Article> articles);
    }
}
