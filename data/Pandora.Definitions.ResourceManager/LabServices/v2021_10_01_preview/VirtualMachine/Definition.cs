using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.LabServices.v2021_10_01_preview.VirtualMachine
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "1ec9a8fe851a92ff4c241110cef58238ced59c6c" 

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
