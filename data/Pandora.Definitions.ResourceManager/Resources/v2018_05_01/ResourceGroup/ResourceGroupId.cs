using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Resources.v2018_05_01.ResourceGroup
{
    internal class ResourceGroupId : ResourceID
    {
        public string ID() => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}";
    }
}