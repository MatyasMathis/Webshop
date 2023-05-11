namespace WebshopAPI.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Guid RoleId { get; set; }

        //Navigation property
        public Role Role { get; set; }
    }
}
