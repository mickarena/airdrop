using Renewal.Application.Common;
using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Options;

namespace Renewal.Application.Models
{
    public interface ITenantRequestModel
    {
        string ServiceProviderVersion { get; }

        string ApiVersion { get; }

        string Context { get; }

        string CompanyCode { get; set; }

        AtlantaProduct AtlantaProduct { get; }

        bool IsValid();
    }

    public class TenantRequestModel : ITenantRequestModel
    {
        public string ServiceProviderVersion { get; private set; }

        public string ApiVersion { get; private set; }

        public string Context { get; private set; }

        public string CompanyCode { get; set; }

        public AtlantaProduct AtlantaProduct { get; private set; }

        private readonly IActionContextAccessor _actionContextAccessor;
        private readonly IOptions<AppSettingsConfiguration> _config;

        public TenantRequestModel(IHttpContextAccessor httpContextAccessor,
                                  IActionContextAccessor actionContextAccessor,
                                  IOptions<AppSettingsConfiguration> config)
        {
            if (!(httpContextAccessor?.HttpContext is HttpContext httpContext))
                return;

            _actionContextAccessor = actionContextAccessor;
            _config = config;

            SetInfo(httpContext);
        }

        private void SetInfo(HttpContext httpContext)
        {
            var headers = httpContext.Request.Headers;
            var headerContext = headers[Constants.HeaderInformation.HeaderContext].ToString();

            var routeValues = _actionContextAccessor.ActionContext?.RouteData?.Values;
            if (routeValues == null)
                return;

            routeValues.TryGetValue("version", out var objVersion);

            if (string.IsNullOrWhiteSpace(headerContext) || objVersion == null)
            {
                return;
            }

            var apiVersion = objVersion.ToString();

            var product = GetProduct(headerContext, apiVersion);

            if (product != null)
            {
                ApiVersion = apiVersion;
                Context = product.Context;
                AtlantaProduct = product.Name;

                SetTrackingInfo();
            }
        }

        private void SetTrackingInfo()
        {
            switch (AtlantaProduct)
            {
                case AtlantaProduct.CarolenashRenewalPortal:
                    CompanyCode = Constants.CompanyCode.CarolenashShorten;
                    break;
            }
        }

        public bool IsValid()
        {
            if (string.IsNullOrEmpty(Context))
                return true;
            return AtlantaProduct != AtlantaProduct.None;
        }

        private Product GetProduct(string headerContext, string apiVersion)
        {
            var products = _config.Value.Products;
            Product product  = null;

            var renewalContextKey = "-;CN;Carole Nash Renewals";
            var isRenewalContext = headerContext.Contains(renewalContextKey, StringComparison.OrdinalIgnoreCase);

            if (isRenewalContext)
            {
                product = products.FirstOrDefault(x => x.Context.Contains(renewalContextKey, StringComparison.OrdinalIgnoreCase) && x.ApiVersions.Contains(apiVersion));
            }
            else
            {
                product = products.FirstOrDefault(x => x.Context.Equals(headerContext, StringComparison.OrdinalIgnoreCase) && x.ApiVersions.Contains(apiVersion));
            }
            
            return product;
        }
    }
}
