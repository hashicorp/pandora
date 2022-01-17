using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ChaosStudio.v2021_09_15_preview.Experiments
{
    internal class Definition : ApiDefinition
    {
        public string ApiVersion => "2021-09-15-preview";
        public string Name => "Experiments";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new CancelOperation(),
            new CreateOrUpdateOperation(),
            new DeleteOperation(),
            new GetOperation(),
            new GetExecutionDetailsOperation(),
            new GetStatusOperation(),
            new ListOperation(),
            new ListAllOperation(),
            new ListAllStatusesOperation(),
            new ListExecutionDetailsOperation(),
            new StartOperation(),
        };
    }
}
