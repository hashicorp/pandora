using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2017_04_01.ConsumerGroups
{
	internal class ListByEventHub : ListOperation
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
			return new ConsumerGroup();
		}

		public override object? OptionsObject()
		{
			return new ListByEventHubOptions();
		}

		public override string? UriSuffix()
		{
			return "/consumergroups";
		}
	}
	internal class ListByEventHubOptions
	{
		[QueryStringName("$top")]
		[Optional]
		public int Top { get; set; }
	
		[QueryStringName("$skip")]
		[Optional]
		public int Skip { get; set; }
	}
}
