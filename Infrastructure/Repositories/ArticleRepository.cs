using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly MyAppContext _context;

        public ArticleRepository(MyAppContext context)
        {
            _context = context;
        }

        public async Task<List<Article>> GetArticlesAsync()
        {
            return await _context.Articles.ToListAsync();
        }

        public async Task AddArticlesAsync(List<Article> articles)
        {
            await _context.Articles.AddRangeAsync(articles);
            await _context.SaveChangesAsync();
        }
    }
}
