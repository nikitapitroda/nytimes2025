namespace Core.DTO
{
    public class ArticleDTO
    {
        public string? Section { get; set; }
        public string? Subsection { get; set; }
        public string? Title { get; set; }
        public string? Abstract { get; set; }
        public string? Url { get; set; }
        public string? Byline { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}
