public class UserLoginModel
{
    public int MemberId { get; set; }  // The MemberId for login
    public string Password { get; set; }  // The user's password for login
    public bool RememberMe { get; set; }  // Option to remember the user on login

    // Optional field to capture any return URL if required for redirecting after login
    public string ReturnUrl { get; set; }
}
