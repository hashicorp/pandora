using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.LabServices.v2021_10_01_preview.Schedule
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "1ec9a8fe851a92ff4c241110cef58238ced59c6c" 

        public string ApiVersion => "2021-10-01-preview";
        public string Name => "Schedule";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new CreateOrUpdateOperation(),
            new DeleteOperation(),
            new GetOperation(),
            new ListByLabOperation(),
            new UpdateOperation(),
        };
    }
}
