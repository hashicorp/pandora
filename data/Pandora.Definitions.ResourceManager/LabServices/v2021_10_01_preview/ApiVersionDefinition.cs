using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.LabServices.v2021_10_01_preview
{
    public partial class Definition : ApiVersionDefinition
    {
        public string ApiVersion => "2021-10-01-preview";
        public bool Preview => true;

        public IEnumerable<ResourceDefinition> Apis => new List<ResourceDefinition>
        {
            new Image.Definition(),
            new Lab.Definition(),
            new LabPlan.Definition(),
            new Schedule.Definition(),
            new User.Definition(),
            new VirtualMachine.Definition(),
        };
    }
}
