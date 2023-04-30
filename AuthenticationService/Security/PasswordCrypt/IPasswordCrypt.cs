namespace AuthenticationService.Security.PasswordCrypt
{
    public interface IPasswordCrypt
    {
        public string HashPassword(string password);
        public bool Verify(string password, string hashedPassword);

    }
}
