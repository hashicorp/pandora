using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.Maps.v2021_02_01.Accounts
{
	internal class Get : GetOperation
	{
		public override ResourceID? ResourceId()
		{
			return new AccountId();
		}

		public override object? ResponseObject()
		{
			return new MapsAccount();
		}


	}
}
