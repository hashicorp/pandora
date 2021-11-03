using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.DNS.v2018_05_01.DNS
{
    internal class Definition : ApiDefinition
    {
        public string ApiVersion => "2018-05-01";
        public string Name => "DNS";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new DnsResourceReferenceGetByTargetResourcesOperation(),
        };
    }
}
