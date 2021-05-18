using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.AppConfiguration.v2020_06_01.ConfigurationStores
{
	internal class Get : GetOperation
	{
		public override ResourceID? ResourceId()
		{
			return new ConfigurationStoreId();
		}

		public override object? ResponseObject()
		{
			return new ConfigurationStore();
		}
	}
}
