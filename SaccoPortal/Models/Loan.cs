namespace SaccoPortal.Models
{
    public class Loan
    {
        public required int LoanId { get; set; }
        public required int MemberId { get; set; }
        public required decimal Amount { get; set; }
        public required DateTime DateApplied { get; set; }
        public required string Status { get; set; }

        // Navigation property
        public required Member Member { get; set; }
    }
}