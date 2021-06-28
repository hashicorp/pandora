using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.EventHub.v2021_01_01_preview.NamespacesPrivateEndpointConnections
{
	internal class PrivateEndpointConnectionsDelete : DeleteOperation
	{
		public override IEnumerable<HttpStatusCode> ExpectedStatusCodes()
		{
			return new List<HttpStatusCode>
			{
				HttpStatusCode.OK,
				HttpStatusCode.Accepted,
				HttpStatusCode.NoContent,
			};
		}

		public override bool LongRunning()
		{
			return true;
		}

		public override ResourceID? ResourceId()
		{
			return new PrivateEndpointConnectionId();
		}
	}
}
