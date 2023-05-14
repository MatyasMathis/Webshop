namespace WebshopAPI.Models
{
    public class User : IIdentifiableByGuid
    {
        #region Properties and Indexers
        public string Email { get; set; }
        public Guid Id { get; set; }
        public string Password { get; set; }
        public virtual List<Role> Roles { get; set; }
        #endregion
    }
}
