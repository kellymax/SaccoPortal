namespace SaccoPortal.Models
{
    public class Contribution
    {
        public int ContributionId { get; set; }
        public int MemberId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        // Navigation property
        public required Member Member { get; set; }
    }

}
