using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.EventHub.v2021_01_01_preview.AuthorizationRulesNamespaces
{
	internal class NamespacesRegenerateKeys : PostOperation
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
			return new RegenerateAccessKeyParameters();
		}

		public override ResourceID? ResourceId()
		{
			return new AuthorizationRuleId();
		}

		public override object? ResponseObject()
		{
			return new AccessKeys();
		}

		public override string? UriSuffix()
		{
			return "/regenerateKeys";
		}
	}
}
