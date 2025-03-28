namespace Application.Model
{
    public class Review
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }

        public int Rating {  get; set; }

        public string OrderID { get; set; }
    }
}
