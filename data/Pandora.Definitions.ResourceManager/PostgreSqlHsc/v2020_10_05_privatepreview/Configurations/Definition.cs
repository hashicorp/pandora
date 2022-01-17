using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.PostgreSqlHsc.v2020_10_05_privatepreview.Configurations
{
    internal class Definition : ApiDefinition
    {
        public string ApiVersion => "2020-10-05-privatepreview";
        public string Name => "Configurations";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new GetOperation(),
            new ListByServerOperation(),
            new ListByServerGroupOperation(),
            new UpdateOperation(),
        };
    }
}
