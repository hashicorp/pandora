using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.LabServices.v2021_10_01_preview.Schedule
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "b28a542b3eb4f2f4f384b14b635d0a835df818cd" 

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
