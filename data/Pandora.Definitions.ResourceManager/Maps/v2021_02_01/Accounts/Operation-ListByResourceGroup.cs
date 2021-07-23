using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.Maps.v2021_02_01.Accounts
{
	internal class ListByResourceGroup : ListOperation
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
			return new MapsAccount();
		}

		public override string? UriSuffix()
		{
			return "/providers/Microsoft.Maps/accounts";
		}


	}
}
