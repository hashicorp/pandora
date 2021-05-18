using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.AppConfiguration.v2020_06_01.ConfigurationStores
{
	internal class Update : PatchOperation
	{
		public override bool LongRunning()
		{
			return true;
		}

		public override object? RequestObject()
		{
			return new ConfigurationStoreUpdateParameters();
		}

		public override ResourceID? ResourceId()
		{
			return new ConfigurationStoreId();
		}
	}
}
