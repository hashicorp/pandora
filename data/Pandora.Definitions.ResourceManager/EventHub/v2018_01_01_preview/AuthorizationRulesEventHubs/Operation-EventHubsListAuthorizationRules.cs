using Pandora.Definitions.Operations;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.AuthorizationRulesEventHubs
{
	internal class EventHubsListAuthorizationRules : ListOperation
	{
		public override string? FieldContainingPaginationDetails()
		{
			return "nextLink";
		}

		public override object NestedItemType()
		{
			return new AuthorizationRule();
		}

		public override ResourceID? ResourceId()
		{
			return new EventhubId();
		}

		public override string? UriSuffix()
		{
			return "/authorizationRules";
		}
	}
}
