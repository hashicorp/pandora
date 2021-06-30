using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2021_01_01_preview.DisasterRecoveryConfigs
{
	internal class Definition : ApiDefinition
	{
		public string ApiVersion => "2021-01-01-preview";
		public string Name => "DisasterRecoveryConfigs";
		public IEnumerable<ApiOperation> Operations => new List<ApiOperation>
		{
			new BreakPairing(),
			new CreateOrUpdate(),
			new Delete(),
			new FailOver(),
			new Get(),
			new List(),
		};
	}
}
