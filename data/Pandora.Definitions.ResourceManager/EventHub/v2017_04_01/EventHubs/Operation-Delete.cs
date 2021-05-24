using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2017_04_01.EventHubs
{
	internal class Delete : DeleteOperation
	{
		public override IEnumerable<HttpStatusCode> ExpectedStatusCodes()
		{
			return new List<HttpStatusCode>
			{
				HttpStatusCode.OK,
				HttpStatusCode.NoContent,
			};
		}

		public override ResourceID? ResourceId()
		{
			return new EventhubId();
		}
	}
}
