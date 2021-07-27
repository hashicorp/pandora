using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Maps.v2021_02_01.Accounts
{
    internal class ResourceGroupId : ResourceID
    {
        public string ID() => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}";
    }
}
