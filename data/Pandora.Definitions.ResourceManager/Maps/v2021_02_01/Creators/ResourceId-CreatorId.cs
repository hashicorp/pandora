using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Maps.v2021_02_01.Creators
{
	internal class CreatorId : ResourceID
	{
		public string ID() => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Maps/accounts/{accountName}/creators/{creatorName}";
	}
}
