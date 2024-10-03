public class RegisterModel
{
    public int MemberId { get; set; }  // The MemberId for registration (links to existing SACCO member)
    public string Email { get; set; }  // The email for the user
    public string Password { get; set; }  // The user's password
    public string ConfirmPassword { get; set; }  // Password confirmation
}
