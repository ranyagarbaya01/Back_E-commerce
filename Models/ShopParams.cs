namespace store.Models
{
    public class ShopParams
    {
        public int? BrandId { get; set; }
        public int? TypeId { get; set; }
        public string Sort { get; set; } = "name";
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 12;
        public string? Search { get; set; }
    }

}
