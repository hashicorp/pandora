using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2017_04_01.Namespaces
{
	internal class CreateOrUpdate : PutOperation
	{
		public override IEnumerable<HttpStatusCode> ExpectedStatusCodes()
		{
			return new List<HttpStatusCode>
			{
				HttpStatusCode.OK,
				HttpStatusCode.Created,
				HttpStatusCode.Accepted,
			};
		}

		public override bool LongRunning()
		{
			return true;
		}

		public override object? RequestObject()
		{
			return new EHNamespace();
		}

		public override ResourceID? ResourceId()
		{
			return new NamespaceId();
		}

		public override object? ResponseObject()
		{
			return new EHNamespace();
		}
	}
}
