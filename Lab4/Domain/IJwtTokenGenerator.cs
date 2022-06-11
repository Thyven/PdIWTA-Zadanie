using Lab4.Data;

namespace Lab4
{
    public interface IJwtTokenGenerator
    {
        Token Generate(string user, string role);
    }
}
