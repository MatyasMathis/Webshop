namespace WebshopAPI.Models.DTOs
{
    public class ProductDto
    {
        #region Properties and Indexers
        public Category Category { get; set; }
        public Guid CategoryId { get; set; }
        public string Description { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        #endregion
    }
}
