using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2017_04_01.EventHubs
{
	internal class ListByNamespace : ListOperation
	{
		public override string? FieldContainingPaginationDetails()
		{
			return "nextLink";
		}

		public override ResourceID? ResourceId()
		{
			return new NamespaceId();
		}

		public override object NestedItemType()
		{
			return new Eventhub();
		}

		public override object? OptionsObject()
		{
			return new ListByNamespaceOptions();
		}

		public override string? UriSuffix()
		{
			return "/eventhubs";
		}
	}
	internal class ListByNamespaceOptions
	{
		[QueryStringName("$skip")]
		[Optional]
		public int Skip { get; set; }
	
		[QueryStringName("$top")]
		[Optional]
		public int Top { get; set; }
	
	}
}
