using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.EventHubsClusters
{
	internal class ClustersDelete : DeleteOperation
	{
		public override IEnumerable<HttpStatusCode> ExpectedStatusCodes()
		{
			return new List<HttpStatusCode>
			{
				HttpStatusCode.Accepted,
				HttpStatusCode.NoContent,
				HttpStatusCode.OK,
			};
		}

		public override bool LongRunning()
		{
			return true;
		}

		public override ResourceID? ResourceId()
		{
			return new ClusterId();
		}
	}
}
