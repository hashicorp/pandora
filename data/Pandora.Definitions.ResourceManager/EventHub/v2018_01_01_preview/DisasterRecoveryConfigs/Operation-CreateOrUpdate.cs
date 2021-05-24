using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.DisasterRecoveryConfigs
{
	internal class CreateOrUpdate : PutOperation
	{
		public override object? RequestObject()
		{
			return new ArmDisasterRecovery();
		}

		public override ResourceID? ResourceId()
		{
			return new DisasterRecoveryConfigId();
		}
	}
}
