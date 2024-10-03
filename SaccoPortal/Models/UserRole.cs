namespace SaccoPortal.Models
{
    public class UserRole
    {
        public required int UserRoleId { get; set; }
        public required string UserId { get; set; }
        public required int RoleId { get; set; }

        // Navigation properties
        public required Role Role { get; set; }
    }

}
