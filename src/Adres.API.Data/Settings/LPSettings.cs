namespace Adres.API.Data.Settings
{
    public class LPSettings
    {
        public string ApiBaseUrl { get; set; }
        public string ApiAuthPath { get; set; }
        public string ClientId { get; set; }
        
        public string AuthSanbox { get; set; }
        public string ClientSecret { get; set; }
        public bool SandboxApi { get; set; }

        public int TokenLifetime { get; set; }

        public string ProviderName { get; set; }
        public string GranType { get; set; }
        public string ApiKey { get; set; }
        public string SecretKeyLP { get; set; }
    }
}