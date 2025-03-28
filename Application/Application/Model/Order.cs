namespace Application.Model
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        public int OrderId { get; set; }

        public int OrderStatus { get; set; }

        public string ClientMO {get; set; }

        public string ClientAddress { get; set; }
        public string ClientName { get; set; }

        public string DeliveryInstructions { get; set; }
    }
}
