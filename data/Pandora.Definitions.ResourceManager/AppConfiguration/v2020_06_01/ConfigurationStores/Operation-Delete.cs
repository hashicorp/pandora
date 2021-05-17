using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.AppConfiguration.v2020_06_01.ConfigurationStores
{
	internal class Delete : DeleteOperation
	{
		public override IEnumerable<HttpStatusCode> ExpectedStatusCodes()
		{
			return new List<HttpStatusCode>
			{
				HttpStatusCode.NoContent,
				HttpStatusCode.OK,
				HttpStatusCode.Accepted,
			};
		}

		public override bool LongRunning()
		{
			return true;
		}

		public override ResourceID? ResourceId()
		{
			return new ConfigurationStoreId();
		}
	}
}
