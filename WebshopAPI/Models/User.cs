namespace WebshopAPI.Models
{
    public class User : IIdentifiableByGuid
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Role> Roles { get; set; }
    }
}
