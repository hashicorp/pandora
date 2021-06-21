using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.EventHub.v2021_01_01_preview.DisasterRecoveryConfigs
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
