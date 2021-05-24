using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.AuthorizationRulesNamespaces
{
	internal class NamespacesGetAuthorizationRule : GetOperation
	{
		public override ResourceID? ResourceId()
		{
			return new AuthorizationRuleId();
		}

		public override object? ResponseObject()
		{
			return new AuthorizationRule();
		}
	}
}
