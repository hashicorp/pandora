using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2021_01_01_preview.EventHubs
{
	internal class Definition : ApiDefinition
	{
		public string ApiVersion => "2021-01-01-preview";
		public string Name => "EventHub";
		public IEnumerable<ApiOperation> Operations => new List<ApiOperation>
		{
			new DeleteAuthorizationRule(),
			new GetAuthorizationRule(),
		};
	}
}
