namespace TranVanThanh_2122110005.Auth
{
    public class JwtSettings
    {
        public string SecretKey { get; set; } = "THIS_IS_A_SUPER_SECRET_KEY_1234567890_32";
        public string Issuer { get; set; } = "TranVanThanh_2122110005App";
        public string Audience { get; set; } = "TranVanThanh_2122110005Users";
        public int ExpirationMinutes { get; set; } = 60;
    }
}
