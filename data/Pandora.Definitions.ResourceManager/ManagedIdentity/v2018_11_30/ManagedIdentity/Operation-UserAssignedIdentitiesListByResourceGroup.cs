using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.ManagedIdentity.v2018_11_30.ManagedIdentity
{
	internal class UserAssignedIdentitiesListByResourceGroup : ListOperation
	{
		public override string? FieldContainingPaginationDetails()
		{
			return "nextLink";
		}

		public override ResourceID? ResourceId()
		{
			return new ResourceGroupId();
		}

		public override object NestedItemType()
		{
			return new Identity();
		}

		public override string? UriSuffix()
		{
			return "/providers/Microsoft.ManagedIdentity/userAssignedIdentities";
		}


	}
}
