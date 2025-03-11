namespace Core.DTO
{
    public class ArticleResponse
    {
        public string? Status { get; set; }
        public int NumResults { get; set; }
        public List<ArticleDTO>? Results { get; set; }
    }
}
