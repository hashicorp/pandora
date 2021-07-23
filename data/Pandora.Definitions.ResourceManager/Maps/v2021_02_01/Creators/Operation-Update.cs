using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.Maps.v2021_02_01.Creators
{
	internal class Update : PatchOperation
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
			return new CreatorUpdateParameters();
		}

		public override ResourceID? ResourceId()
		{
			return new CreatorId();
		}

		public override object? ResponseObject()
		{
			return new Creator();
		}


	}
}
