using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2017_04_01.DisasterRecoveryConfigs
{
	internal class BreakPairing : PostOperation
	{
		public override IEnumerable<HttpStatusCode> ExpectedStatusCodes()
		{
			return new List<HttpStatusCode>
			{
				HttpStatusCode.OK,
			};
		}

		public override object? RequestObject()
		{
			return null;
		}

		public override ResourceID? ResourceId()
		{
			return new DisasterRecoveryConfigId();
		}

		public override string? UriSuffix()
		{
			return "/breakPairing";
		}
	}
}
