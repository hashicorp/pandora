using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.EventHub.v2021_01_01_preview.AuthorizationRulesEventHubs
{
	internal class EventHubsListAuthorizationRules : ListOperation
	{
		public override string? FieldContainingPaginationDetails()
		{
			return "nextLink";
		}

		public override ResourceID? ResourceId()
		{
			return new EventhubId();
		}

		public override object NestedItemType()
		{
			return new AuthorizationRule();
		}

		public override string? UriSuffix()
		{
			return "/authorizationRules";
		}
	}
}
