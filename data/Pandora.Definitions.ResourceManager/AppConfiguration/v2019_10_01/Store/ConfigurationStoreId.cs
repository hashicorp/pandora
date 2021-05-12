using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.AppConfiguration.v2019_10_01.Store
{
    internal class ConfigurationStoreId : ResourceID
    {
        public string ID() => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/Microsoft.AppConfiguration/configurationStores/{configStoreName}";
    }
}