using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.NamespacesPrivateEndpointConnections
{
	internal class PrivateEndpointConnectionsGet : GetOperation
	{
		public override ResourceID? ResourceId()
		{
			return new PrivateEndpointConnectionId();
		}

		public override object? ResponseObject()
		{
			return new PrivateEndpointConnection();
		}
	}
}
