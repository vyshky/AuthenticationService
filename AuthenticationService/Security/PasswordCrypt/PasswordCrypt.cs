namespace AuthenticationService.Security.PasswordCrypt
{
    public class PasswordCrypt : IPasswordCrypt
    {
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool Verify(string password, string hashedPassword)
        {
            try
            {
                return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
            }
            catch
            {
                return false;
            }           
        }
    }
}
