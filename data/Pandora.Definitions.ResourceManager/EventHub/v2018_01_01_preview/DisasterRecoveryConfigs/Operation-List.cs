using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.DisasterRecoveryConfigs
{
	internal class List : ListOperation
	{
		public override string? FieldContainingPaginationDetails()
		{
			return "nextLink";
		}

		public override object NestedItemType()
		{
			return new ArmDisasterRecovery();
		}

		public override ResourceID? ResourceId()
		{
			return new NamespaceId();
		}

		public override string? UriSuffix()
		{
			return "/disasterRecoveryConfigs";
		}
	}
}
