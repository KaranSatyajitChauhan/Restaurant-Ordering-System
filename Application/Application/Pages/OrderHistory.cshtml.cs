using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Application.Pages
{
    public class OrderHistoryModel : PageModel
    {
        public List<OrderDetails> Orders { get; set; } = new List<OrderDetails>();

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
            public DateTime? DeliveryDate { get; set; }
            public decimal Total { get; set; }
            public int ItemCount { get; set; }
            public string Restaurant { get; set; }
        }

        public void OnGet()
        {
            // In a real app, this would come from your database
            Orders = new List<OrderDetails>
            {
                new OrderDetails
                {
                    Id = "KG78901",
                    Status = OrderStatus.Delivered,
                    OrderDate = DateTime.Now.AddDays(-3),
                    DeliveryDate = DateTime.Now.AddDays(-3).AddHours(1),
                    Total = 32.50m,
                    ItemCount = 3,
                    Restaurant = "Curry Palace"
                },
                new OrderDetails
                {
                    Id = "KG67890",
                    Status = OrderStatus.Delivered,
                    OrderDate = DateTime.Now.AddDays(-7),
                    DeliveryDate = DateTime.Now.AddDays(-7).AddHours(1.5),
                    Total = 45.75m,
                    ItemCount = 5,
                    Restaurant = "Spice Garden"
                },
                new OrderDetails
                {
                    Id = "KG56789",
                    Status = OrderStatus.Cancelled,
                    OrderDate = DateTime.Now.AddDays(-10),
                    DeliveryDate = null,
                    Total = 28.99m,
                    ItemCount = 2,
                    Restaurant = "Tandoori Nights"
                }
            };
        }

        public string GetStatusBadgeClass(OrderStatus status)
        {
            return status switch
            {
                OrderStatus.Delivered => "bg-success",
                OrderStatus.Cancelled => "bg-danger",
                _ => "bg-primary"
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