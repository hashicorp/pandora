using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2017_04_01.EventHubs
{
	internal class Get : GetOperation
	{
		public override ResourceID? ResourceId()
		{
			return new EventhubId();
		}

		public override object? ResponseObject()
		{
			return new Eventhub();
		}
	}
}
