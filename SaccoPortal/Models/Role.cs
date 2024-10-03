namespace SaccoPortal.Models
{
    public class Role
    {
        public required int RoleId { get; set; }
        public required string RoleName { get; set; }
        public required string Description { get; set; }

        // Navigation property
        public required ICollection<UserRole> UserRoles { get; set; }
    }

}
