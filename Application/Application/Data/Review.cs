namespace Application.Data
{
    public class Review
    {
        //userid
        public string Id { get; set; }
        //userName
        public string Name { get; set; }
        public string ReviewText { get; set; }
        public decimal Rating { get; set; }
        //orderid
        public string OrderId { get; set; }
    }
}
