using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.AuthorizationRulesDisasterRecoveryConfigs
{
	internal class DisasterRecoveryConfigsListAuthorizationRules : ListOperation
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
			return new DisasterRecoveryConfigId();
		}

		public override string? UriSuffix()
		{
			return "/authorizationRules";
		}
	}
}
