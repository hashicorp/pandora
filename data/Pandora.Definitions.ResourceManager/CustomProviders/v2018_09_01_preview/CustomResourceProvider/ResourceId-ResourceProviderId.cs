using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.CustomProviders.v2018_09_01_preview.CustomResourceProvider
{
    internal class ResourceProviderId : ResourceID
    {
        public string ID() => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CustomProviders/resourceProviders/{resourceProviderName}";
    }
}
