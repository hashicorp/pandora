using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.TestData.Pandamonium.v2020_01_01.Grouping
{
    public class Definition : ApiDefinition
    {
        public string Name => "Grouping";
        public IEnumerable<ApiOperation> Operations => new List<ApiOperation>
        {
            new DeleteImmediate(),
            new DeleteLongRunning(),
            new GetAnimals(),
            new GetImmediate(),
            new GetListOfModelImmediate(),
            new GetStringImmediate(),
            new HeadImmediate(),
            new Restart(),
            new Paged(),
            new PagedListOfStringsImmediate(),
            new PatchImmediate(),
            new PostImmediate(),
            new PostLongRunning(),
            new PutImmediate(),
            new PutLongRunning(),
            new PutStringImmediate(),
        };
    }
}