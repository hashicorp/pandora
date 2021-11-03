using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.DNS.v2018_05_01.RecordSets
{
    internal class Definition : ApiDefinition
    {
        public string ApiVersion => "2018-05-01";
        public string Name => "RecordSets";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new CreateOrUpdateOperation(),
            new DeleteOperation(),
            new GetOperation(),
            new ListAllByDnsZoneOperation(),
            new ListByDnsZoneOperation(),
            new ListByTypeOperation(),
            new UpdateOperation(),
        };
    }
}
