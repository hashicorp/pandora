using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.DataPlane.AppConfiguration.v1_0.KeyValues
{
	internal class GetKeyValue : GetOperation
	{
		public override object? ResponseObject()
		{
			return new KeyValue();
		}
	}
}
