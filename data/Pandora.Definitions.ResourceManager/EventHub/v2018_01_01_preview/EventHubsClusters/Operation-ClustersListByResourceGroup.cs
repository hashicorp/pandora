using Pandora.Definitions.Operations;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.EventHubsClusters
{
	internal class ClustersListByResourceGroup : ListOperation
	{
		public override string? FieldContainingPaginationDetails()
		{
			return "nextLink";
		}

		public override object NestedItemType()
		{
			return new Cluster();
		}

		public override ResourceID? ResourceId()
		{
			return new ResourceGroupId();
		}

		public override string? UriSuffix()
		{
			return "/providers/Microsoft.EventHub/clusters";
		}
	}
}
