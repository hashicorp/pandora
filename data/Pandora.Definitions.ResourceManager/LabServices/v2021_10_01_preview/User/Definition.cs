using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.LabServices.v2021_10_01_preview.User
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "1ec9a8fe851a92ff4c241110cef58238ced59c6c" 

        public string ApiVersion => "2021-10-01-preview";
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
