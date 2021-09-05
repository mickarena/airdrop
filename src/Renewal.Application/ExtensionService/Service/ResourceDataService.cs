using Renewal.Application.ExtensionService.IService;
using System.Resources;

namespace Renewal.Application.ExtensionService.Service
{
    public class ResourceDataService : IResourceDataService
    {
        public string GetValue(string name)
        {
            System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("en-GB");
            ResourceManager resourceManager = new ResourceManager(typeof(Renewal.Application.Common.Resources));
            string bodyResource = resourceManager.GetString(name, ci);
            return bodyResource;
        }
    }
}
