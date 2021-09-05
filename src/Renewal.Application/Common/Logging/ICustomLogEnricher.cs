namespace Renewal.Application.Common.Logging
{
    public interface ICustomLogEnricher
    {
        string CorrelationId { get; set; }
        string RequestContext { get; set; }
        string ClientIp { get; set; }
        string IntegrationTestKey { get; set; }
    }
}
