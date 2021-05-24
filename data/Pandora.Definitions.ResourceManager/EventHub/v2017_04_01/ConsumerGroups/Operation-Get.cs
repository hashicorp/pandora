using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2017_04_01.ConsumerGroups
{
	internal class Get : GetOperation
	{
		public override ResourceID? ResourceId()
		{
			return new ConsumergroupId();
		}

		public override object? ResponseObject()
		{
			return new ConsumerGroup();
		}
	}
}
