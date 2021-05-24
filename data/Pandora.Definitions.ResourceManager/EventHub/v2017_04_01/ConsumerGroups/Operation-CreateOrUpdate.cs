using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2017_04_01.ConsumerGroups
{
	internal class CreateOrUpdate : PutOperation
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
			return new ConsumerGroup();
		}

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
