namespace WebshopAPI.Models
{
    public class Category : IIdentifiableByGuid
    {
        #region Properties and Indexers
        public string Description { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        #endregion

        // public IEnumerable<Product> Products { get; set; }
    }
}
