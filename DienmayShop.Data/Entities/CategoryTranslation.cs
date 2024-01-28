namespace DienmayShop.Data.Entities
{
    public class CategoryTranslation
    {
        public int Id { set; get; }
        public int CategoryId { set; get; }
        public string Name { set; get; } =  string.Empty;
        public string SeoDescription { set; get; } = string.Empty;
        public string SeoTitle { set; get; } = string.Empty;
        public string LanguageId { set; get; } = string.Empty;
        public string SeoAlias { set; get; } = string.Empty;
        public Category Category { get; set; }
    }
}
