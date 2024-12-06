namespace TestApp.Authmodels
{
    public class JwtOptions
    {
        public string Issuer { get; set; }
        public List<string> Audience { get; set; }
        public int Lifetime { get; set; }
        public string SigningKey { get; set; }
    }
}
