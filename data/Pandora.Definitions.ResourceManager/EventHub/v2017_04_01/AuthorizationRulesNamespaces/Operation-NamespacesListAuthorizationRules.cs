using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2017_04_01.AuthorizationRulesNamespaces
{
	internal class NamespacesListAuthorizationRules : ListOperation
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
			return new NamespaceId();
		}

		public override string? UriSuffix()
		{
			return "/authorizationRules";
		}
	}
}
