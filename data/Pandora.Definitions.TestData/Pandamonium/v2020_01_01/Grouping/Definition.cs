using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.TestData.Pandamonium.v2020_01_01.Grouping
{
    public class Definition : ApiDefinition
    {
        public string ApiVersion => "2020-01-01";
        public string Name => "Grouping";
        public IEnumerable<ApiOperation> Operations => new List<ApiOperation>
        {
            new PutImmediate(),
            new PutLongRunning(),
            new PatchImmediate(),
            new PostImmediate(),
            new PostLongRunning(),
            new DeleteImmediate(),
            new DeleteLongRunning(),
            new GetAnimals(),
            new GetImmediate(),
            new HeadImmediate(),
            new Restart(),
            new Paged(),
        };
        public ResourceID ResourceId => new ExampleResourceId();
    }
}