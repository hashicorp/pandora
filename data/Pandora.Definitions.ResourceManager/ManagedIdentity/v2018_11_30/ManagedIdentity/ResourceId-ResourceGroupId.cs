using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ManagedIdentity.v2018_11_30.ManagedIdentity
{
	internal class ResourceGroupId : ResourceID
	{
		public string ID() => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}";
	}
}
