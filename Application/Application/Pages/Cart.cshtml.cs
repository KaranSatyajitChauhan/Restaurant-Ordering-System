using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

public class CartModel : PageModel
{
    public List<CartItem> CartItems { get; set; } = new();
    public DeliveryAddress DelAddress { get; set; } = new();
    public decimal Subtotal { get; set; }
    public decimal DeliveryFee { get; set; } = 3.99m;
    public decimal Tax { get; set; }
    public decimal Total { get; set; }

    public class CartItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public bool IsVegetarian { get; set; }
        public string SpecialInstructions { get; set; }
    }

    public class DeliveryAddress
    {
        [Required]
        public string FullName { get; set; }

        [Required, Phone]
        public string Phone { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string PostalCode { get; set; }

        public string Instructions { get; set; }
    }

    public void OnGet()
    {
        // Sample data - replace with real cart data
        CartItems = new List<CartItem>
            {
                new CartItem
                {
                    Id = "1",
                    Name = "Butter Chicken",
                    ImageUrl = "/images/menu/butter-chicken.jpg",
                    Quantity = 1,
                    Price = 14.99m,
                    SpecialInstructions = "Extra spicy"
                },
                new CartItem
                {
                    Id = "2",
                    Name = "Garlic Naan",
                    ImageUrl = "/images/menu/naan.jpg",
                    Quantity = 2,
                    Price = 3.99m,
                    IsVegetarian = true
                }
            };

        Subtotal = CartItems.Sum(i => i.Quantity * i.Price);
        Tax = Subtotal * 0.08m;
        Total = Subtotal + DeliveryFee + Tax;
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        // Process order and redirect to confirmation
        return RedirectToPage("OrderConfirmation");
    }
}