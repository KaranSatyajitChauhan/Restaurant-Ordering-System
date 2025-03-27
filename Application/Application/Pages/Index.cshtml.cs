using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Application.Pages
{
    public class IndexModel : PageModel
    {
        public List<MenuCategory> Categories { get; set; }
        public List<MenuItem> MenuItems { get; set; }

        public class MenuCategory
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Icon { get; set; }
            public int DisplayOrder { get; set; }
        }

        public class MenuItem
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
            public string Category { get; set; }
            public string ImageUrl { get; set; }
            public bool IsVegetarian { get; set; }
        }

        public void OnGet()
        {
            Categories = new List<MenuCategory>
            {
                new() { Id = 1, Name = "Appetizers", Icon = "fa-utensils", DisplayOrder = 1 },
                new() { Id = 2, Name = "Main Course", Icon = "fa-drumstick-bite", DisplayOrder = 2 },
                new() { Id = 3, Name = "Desserts", Icon = "fa-ice-cream", DisplayOrder = 3 }
            };

            MenuItems = new List<MenuItem>
            {
                // Appetizers
                new() {
                    Id = 1,
                    Name = "Paneer Tikka",
                    Description = "Cottage cheese marinated in spices and grilled",
                    Price = 8.99m,
                    Category = "Appetizers",
                    ImageUrl = "/images/menu/paneer-tikka.jpg",
                    IsVegetarian = true
                },
                new() {
                    Id = 2,
                    Name = "Chicken 65",
                    Description = "Spicy deep-fried chicken appetizer",
                    Price = 9.99m,
                    Category = "Appetizers",
                    ImageUrl = "/images/menu/chicken-65.jpg"
                },
                // Add more items as needed...
                
                // Main Course
                new() {
                    Id = 5,
                    Name = "Butter Chicken",
                    Description = "Tandoori chicken in creamy tomato sauce",
                    Price = 14.99m,
                    Category = "Main Course",
                    ImageUrl = "/images/menu/butter-chicken.jpg"
                },
                // Add more items as needed...
                
                // Desserts
                new() {
                    Id = 9,
                    Name = "Gulab Jamun",
                    Description = "Deep-fried milk balls in sugar syrup",
                    Price = 5.99m,
                    Category = "Desserts",
                    ImageUrl = "/images/menu/gulab-jamun.jpg",
                    IsVegetarian = true
                }
                // Add more items as needed...
            };
        }
    }
}