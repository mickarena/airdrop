namespace Renewal.Application.Common
{
    public static class Configuration
    {
        public const string ConnectionString = "ConnectionStrings:Renewal";
    }

    public static class Constants
    {
        public static class HeaderInformation
        {
            public const string HeaderContext = "Context";
            public const string CorrelationId = "X-Correlation-Id";
            public const string ClientIp = "X-Forwarded-For";
            public const string IntegrationTestKey = "IntegrationTestKey";
            public const string TslTestKey = "TslTestKey";
            public static readonly string HeaderContextValueStrata = $"{AtlantaBrandCode.Atlanta};{CompanyCode.Swinton};{BrandCode.Safeguard};{ProductCode.Motorhome}";
            public static readonly string HeaderContextValueCdlClassic = $"{AtlantaBrandCode.Atlanta};{CompanyCode.Carolenash};{BrandCode.Carolenash};{ProductCode.Motorbike}";
        }

        public static class AtlantaBrandCode
        {
            public const string Atlanta = "AtlantaBrandCode";
        }

        public static class CompanyCode
        {
            public const string Swinton = "Swinton";
            public const string SwintonShorten = "SW";
            public const string Carolenash = "Carolenash";
            public const string CarolenashShorten = "CN";
            public const string Autonet = "Autonet";
            public const string AutonetShorten = "AN";
        }

        public static class BrandCode
        {
            public const string Safeguard = "safeguard";
            public const string Carolenash = "Carolenash";
        }

        public static class ProductCode
        {
            public const string Motorhome = "motorhome";
            public const string Motorbike = "motorbike";
        }

        public static class HealthCheckMessage
        {
            public const string Healthy = "Service is able to handle request.";

            public const string Unhealthy = "Service is unable to connect.";

            public const string Degraded = "Service is unavailable to connect but it does not cause impact on the functionality of the main service.";
        }

        public static class Urls
        {
            public const string HealthCheck = "/health";
            public const string SwaggerEndpoint = "/swagger/v1/swagger.json";
            public const string SwaggerEndpointV2 = "/swagger/v2/swagger.json";
            
            #region Token
            public const string GetToken = "api/token/authorize";
            #endregion

            #region Payment
            public const string GetIsLockPaymentV3 = "/api/V3/payment/payment-lock";
            #endregion
        }

        public static class ConnectionConfig
        {
            public const string ConnectionString = "ConnectionStrings:RenewalDb";
        }

        public static class CommonPattern
        {
            public const string PolicyReferenceNumberPattern = @"^([A-Za-z0-9]{7})/([A-Za-z0-9]{2})$";
            public const string NamePersonPattern = @"^[A-Za-z ,.'-]+$";
            public const string EmailPattern = @"^([a-zA-Z0-9_\-\.!#$%&'\*\?\^`\|~\+]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        }

        public static class PaymentStatus
        {
            public const string PaymentStarted = "PaymentStarted";
            public const string PaymentFailed = "PaymentFailed";
            public const string PaymentOK = "PaymentOK";
            public const string ToDo = "To Do";
            public const string InProgress = "In Progress";
            public const string Completed = "Completed";
            public const string KeepCurrentStatus = "KeepCurrentStatus";
        }
    }
}
