using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace SaccoPortal.Models
{
    public class User : IdentityUser // Inherit from IdentityUser
    {
        public required string UserId { get; set; }  // Unique identifier for the user (could be GUID)

        public int MemberId { get; set; }  // Foreign key to the Member table
        public  Member Member { get; set; }  // Navigation property to the Member

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;  // Date of account creation

        // Navigation properties
        public  ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}
