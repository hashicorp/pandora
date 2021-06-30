using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.EventHub.v2021_01_01_preview.ConsumerGroups
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
