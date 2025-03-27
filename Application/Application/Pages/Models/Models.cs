namespace Application.Pages.Models
{
    // Models/MenuCategory.cs
    public class MenuCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; } // Font Awesome icon
        public int DisplayOrder { get; set; }
    }

    // Models/MenuItem.cs
    public class MenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string ImageUrl { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsVegetarian { get; set; }
        public List<string> Tags { get; set; } = new();
    }
}
