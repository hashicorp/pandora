using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.EventHub.v2021_01_01_preview.EventHubs
{
	internal class DeleteAuthorizationRule : DeleteOperation
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
			return new AuthorizationRuleId();
		}
	}
}
