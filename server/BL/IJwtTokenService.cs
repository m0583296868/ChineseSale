namespace MSMA.BL
{
    public interface IJwtTokenService
    {
     Task<string> GenerateJwtToken(string username, int id, List<string> roles);
     Task<string> GenerateToken(string username);
    }
}
