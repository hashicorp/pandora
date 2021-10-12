using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.LabServices.v2021_10_01_preview.VirtualMachine
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "1b64fac98b004c439dfffff4cbe93e413ff86709" 

        public string ApiVersion => "2021-10-01-preview";
        public string Name => "VirtualMachine";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new GetOperation(),
            new LabPlansSaveImageOperation(),
            new ListByLabOperation(),
            new RedeployOperation(),
            new ReimageOperation(),
            new ResetPasswordOperation(),
            new StartOperation(),
            new StopOperation(),
        };
    }
}
