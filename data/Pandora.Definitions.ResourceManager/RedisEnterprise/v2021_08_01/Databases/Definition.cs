using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.RedisEnterprise.v2021_08_01.Databases
{
    internal class Definition : ApiDefinition
    {
        public string ApiVersion => "2021-08-01";
        public string Name => "Databases";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new CreateOperation(),
            new DeleteOperation(),
            new ExportOperation(),
            new GetOperation(),
            new ImportOperation(),
            new ListByClusterOperation(),
            new ListKeysOperation(),
            new RegenerateKeyOperation(),
            new UpdateOperation(),
        };
    }
}
