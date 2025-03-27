// TrackOrder.cshtml.cs
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Application.Pages
{
    public class TrackOrderModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Order number is required")]
        public string OrderId { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid phone number format")]
        public string Phone { get; set; }

        public OrderDetails Order { get; set; }
        public bool HasSearched { get; set; }

        public enum OrderStatus
        {
            Placed,
            Preparing,
            Ready,
            OutForDelivery,
            Delivered,
            Cancelled
        }

        public class OrderDetails
        {
            public string Id { get; set; }
            public OrderStatus Status { get; set; }
            public DateTime OrderDate { get; set; }
            public DateTime EstimatedDelivery { get; set; }
            public string DeliveryAddress { get; set; }
            public string PaymentMethod { get; set; }
            public decimal Subtotal { get; set; }
            public decimal DeliveryFee { get; set; }
            public decimal Tax { get; set; }
            public decimal Total { get; set; }
            public List<OrderItem> Items { get; set; } = new List<OrderItem>();
        }

        public class OrderItem
        {
            public string Name { get; set; }
            public string ImageUrl { get; set; }
            public int Quantity { get; set; }
            public decimal Price { get; set; }
            public bool IsVegetarian { get; set; }
            public string SpecialInstructions { get; set; }
        }

        public void OnGet()
        {
            // For demo purposes
            if (TempData["DemoOrder"] != null)
            {
                Order = (OrderDetails)TempData["DemoOrder"];
                HasSearched = true;
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            HasSearched = true;

            // In a real app, replace this with database lookup
            if (OrderId == "KG12345" && Phone == "5551234567")
            {
                Order = GetSampleOrder();
            }

            return Page();
        }

        private OrderDetails GetSampleOrder()
        {
            return new OrderDetails
            {
                Id = "KG12345",
                Status = OrderStatus.Preparing,
                OrderDate = DateTime.Now.AddMinutes(-30),
                EstimatedDelivery = DateTime.Now.AddHours(1),
                DeliveryAddress = "123 Main St, Foodville, FK 12345",
                PaymentMethod = "Credit Card (•••• 4242)",
                Subtotal = 42.97m,
                DeliveryFee = 3.99m,
                Tax = 3.21m,
                Total = 50.17m,
                Items = new List<OrderItem>
                {
                    new OrderItem
                    {
                        Name = "Butter Chicken",
                        ImageUrl = "/images/menu/butter-chicken.jpg",
                        Quantity = 1,
                        Price = 14.99m,
                        SpecialInstructions = "Extra spicy"
                    },
                    new OrderItem
                    {
                        Name = "Garlic Naan",
                        ImageUrl = "/images/menu/naan.jpg",
                        Quantity = 2,
                        Price = 3.99m,
                        IsVegetarian = true
                    }
                }
            };
        }

        public string GetStatusBadgeClass(OrderStatus status)
        {
            return status.ToString().ToLower();
        }

        public int GetProgressPercentage(OrderStatus status)
        {
            return status switch
            {
                OrderStatus.Placed => 20,
                OrderStatus.Preparing => 40,
                OrderStatus.Ready => 60,
                OrderStatus.OutForDelivery => 80,
                OrderStatus.Delivered => 100,
                _ => 0
            };
        }

        public string GetStatusIcon(OrderStatus status)
        {
            return status switch
            {
                OrderStatus.Placed => "fas fa-clipboard-check",
                OrderStatus.Preparing => "fas fa-utensils",
                OrderStatus.Ready => "fas fa-check-circle",
                OrderStatus.OutForDelivery => "fas fa-truck",
                OrderStatus.Delivered => "fas fa-home",
                OrderStatus.Cancelled => "fas fa-times-circle",
                _ => "fas fa-question-circle"
            };
        }
    }
}