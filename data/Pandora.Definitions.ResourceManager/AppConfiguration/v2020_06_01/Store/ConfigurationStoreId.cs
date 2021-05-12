using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.AppConfiguration.v2020_06_01.Store
{
    internal class ConfigurationStoreId : ResourceID
    {
        public string ID() => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/Microsoft.AppConfiguration/configurationStores/{configStoreName}";
    }
}