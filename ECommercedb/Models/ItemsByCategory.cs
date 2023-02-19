using Microsoft.AspNetCore.Mvc.Formatters;

namespace ECommercedb.Models
{
    public class ItemsByCategory
    {
        public int Id { get; set; }

        public string ItemName { get; set; } = string.Empty;

        public decimal Price { get; set; } = decimal.Zero;

        public string Media { get; set; } = string.Empty;

        public int ItemCategoryId { get; set; } 

        public int CategoryId { get; set; }

        public string CategoryName { get; set; } = string.Empty;
    }
}
