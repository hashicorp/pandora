using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.DataPlane.AppConfiguration.v1_0.KeyValues
{
	internal class PutKeyValue : PutOperation
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
			return new KeyValue();
		}

		public override object? ResponseObject()
		{
			return new KeyValue();
		}
	}
}
