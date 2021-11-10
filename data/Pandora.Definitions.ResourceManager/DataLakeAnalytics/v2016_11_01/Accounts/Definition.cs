using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.DataLakeAnalytics.v2016_11_01.Accounts
{
    internal class Definition : ApiDefinition
    {
        public string ApiVersion => "2016-11-01";
        public string Name => "Accounts";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new CheckNameAvailabilityOperation(),
            new CreateOperation(),
            new DeleteOperation(),
            new GetOperation(),
            new ListOperation(),
            new ListByResourceGroupOperation(),
            new UpdateOperation(),
        };
    }
}
