using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2017_04_01.MessagingPlan
{
	internal class NamespacesGetMessagingPlan : GetOperation
	{
		public override ResourceID? ResourceId()
		{
			return new NamespaceId();
		}

		public override object? ResponseObject()
		{
			return new MessagingPlan();
		}

		public override string? UriSuffix()
		{
			return "/messagingplan";
		}
	}
}
