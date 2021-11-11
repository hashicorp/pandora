using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2021_10_01.UsageDetails
{
    internal class Definition : ApiDefinition
    {
        public string ApiVersion => "2021-10-01";
        public string Name => "UsageDetails";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new GenerateDetailedCostReportCreateOperationOperation(),
        };
    }
}
