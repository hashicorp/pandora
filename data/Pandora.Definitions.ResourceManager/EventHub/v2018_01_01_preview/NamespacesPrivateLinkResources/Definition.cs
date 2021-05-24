using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.NamespacesPrivateLinkResources
{
    internal class Definition : ApiDefinition
    {
        public string ApiVersion => "v2018-01-01-preview";
        public string Name => "NamespacesPrivateLinkResources";
        public IEnumerable<ApiOperation> Operations => new List<ApiOperation>
        {
            new PrivateLinkResourcesGet(),
        };
    }
}