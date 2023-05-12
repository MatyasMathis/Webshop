namespace WebshopAPI.Models
{
    public class Product : IIdentifiableByGuid
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }

        //Navigation Properties
        public Category Category { get; set; }

    }
}
