using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2017_04_01.Namespaces
{
	internal class ListByResourceGroup : ListOperation
	{
		public override string? FieldContainingPaginationDetails()
		{
			return "nextLink";
		}

		public override object NestedItemType()
		{
			return new EHNamespace();
		}

		public override ResourceID? ResourceId()
		{
			return new ResourceGroupId();
		}

		public override string? UriSuffix()
		{
			return "/providers/Microsoft.EventHub/namespaces";
		}
	}
}
