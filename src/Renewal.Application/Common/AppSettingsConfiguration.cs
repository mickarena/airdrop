using System.Collections.Generic;

namespace Renewal.Application.Common
{
    public class AppSettingsConfiguration
    {
        public PingServiceUrls PingServiceUrls { get; set; }
        public IList<Product> Products { get; set; }
        public string PaymentServiceEndpointUrl { get; set; }
        public string TokenServiceEndpointUrl { get; set; }
    }
    public class PingServiceUrls
    {
        public string IdentityServer { get; set; }
    }

    public class Product
    {
        public string Context { get; set; }
        public List<string> ApiVersions { get; set; }
        public AtlantaProduct Name { get; set; }
    }

    public enum AtlantaProduct
    {
        None,
        CarolenashRenewalPortal
    }
}
