namespace WebshopAPI.Models
{
    public class Role : IIdentifiableByGuid
    {
        #region Properties and Indexers
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<User> Users { get; set; }
        #endregion
    }
}
