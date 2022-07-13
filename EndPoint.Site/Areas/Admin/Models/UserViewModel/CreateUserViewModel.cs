
namespace EndPoint.Site.Areas.Admin.Models
{
    public class CreateUserViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
    }
}
