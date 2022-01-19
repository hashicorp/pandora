using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.LabServices.v2021_10_01_preview.User
{
    internal class Definition : ApiDefinition
    {
        public string Name => "User";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new CreateOrUpdateOperation(),
            new DeleteOperation(),
            new GetOperation(),
            new InviteOperation(),
            new ListByLabOperation(),
            new UpdateOperation(),
        };
    }
}
