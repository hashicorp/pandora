using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.DataPlane.AppConfiguration.v1_0.KeyValues
{
	internal class DeleteKeyValue : DeleteOperation
	{
		public override IEnumerable<HttpStatusCode> ExpectedStatusCodes()
		{
			return new List<HttpStatusCode>
			{
				HttpStatusCode.OK,
				HttpStatusCode.NoContent,
			};
		}

		public override object? ResponseObject()
		{
			return new KeyValue();
		}
	}
}
