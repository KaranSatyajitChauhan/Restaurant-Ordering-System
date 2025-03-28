using System.Xml.Linq;

namespace Application.Model
{
    public class Menu
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; } 

        public Menu(int id, string name, string description, decimal price)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
        }
    }
}
