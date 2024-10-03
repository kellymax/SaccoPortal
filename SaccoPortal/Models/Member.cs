namespace SaccoPortal.Models
{
    public class Member
    {
        public required int MemberId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string PhoneNumber { get; set; }
        public required DateTime DateJoined { get; set; }
        public required bool IsActive { get; set; }

        //properties to navigate
        public required ICollection<Loan> Loans { get; set; }
        public required ICollection<Contribution> Contributions { get; set; }
    }
}
