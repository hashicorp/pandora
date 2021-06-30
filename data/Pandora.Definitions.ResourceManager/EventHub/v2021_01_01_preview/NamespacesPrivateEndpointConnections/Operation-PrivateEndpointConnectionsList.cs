using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.EventHub.v2021_01_01_preview.NamespacesPrivateEndpointConnections
{
	internal class PrivateEndpointConnectionsList : ListOperation
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
			return new PrivateEndpointConnection();
		}

		public override string? UriSuffix()
		{
			return "/privateEndpointConnections";
		}
	}
}
