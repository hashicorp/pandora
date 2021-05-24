using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.EventHubsClusters
{
	internal class ClustersCreateOrUpdate : PutOperation
	{
		public override IEnumerable<HttpStatusCode> ExpectedStatusCodes()
		{
			return new List<HttpStatusCode>
			{
				HttpStatusCode.OK,
				HttpStatusCode.Created,
				HttpStatusCode.Accepted,
			};
		}

		public override bool LongRunning()
		{
			return true;
		}

		public override object? RequestObject()
		{
			return new Cluster();
		}

		public override ResourceID? ResourceId()
		{
			return new ClusterId();
		}

		public override object? ResponseObject()
		{
			return new Cluster();
		}
	}
}
