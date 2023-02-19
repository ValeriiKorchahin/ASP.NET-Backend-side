namespace ECommercedb.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string ItemName { get; set; } = string.Empty;

        public decimal Price { get; set; } = decimal.Zero;

        public string Media { get; set; } = string.Empty;

        public int ItemCategoryId { get; set; }
    }
}
