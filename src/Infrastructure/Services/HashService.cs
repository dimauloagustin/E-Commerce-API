using Application.Interfaces.Services;

namespace Infrastructure.Services
{
    public class HashService : IHashService
    {
        public string Hash(string value)
        {
            return BCrypt.Net.BCrypt.HashPassword(value);
        }

        public bool Verify(string value, string hashedValue)
        {
            return BCrypt.Net.BCrypt.Verify(value, hashedValue);
        }
    }
}
