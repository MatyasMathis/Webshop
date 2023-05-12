namespace WebshopAPI.Models.DTOs
{
    public class UploadProductDto
    {
        #region Properties and Indexers
        public Guid CategoryId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        #endregion
    }
}
