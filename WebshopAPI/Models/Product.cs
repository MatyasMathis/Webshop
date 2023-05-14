namespace WebshopAPI.Models
{
    public class Product : IIdentifiableByGuid
    {
        #region Properties and Indexers
        //Navigation Properties
        public virtual Category Category { get; set; }
        public Guid CategoryId { get; set; }
        public string Description { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        #endregion
    }
}
