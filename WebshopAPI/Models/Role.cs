namespace WebshopAPI.Models
{
    public class Role : IIdentifiableByGuid
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<User> Users { get; set; }
    }
}
