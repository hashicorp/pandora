using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2021_10_01
{
    public partial class Definition : ApiVersionDefinition
    {
        public string ApiVersion => "2021-10-01";
        public bool Preview => false;

        public IEnumerable<ApiDefinition> Apis => new List<ApiDefinition>
        {
            new Alerts.Definition(),
            new Dimensions.Definition(),
            new Exports.Definition(),
            new Forecast.Definition(),
            new GenerateDetailedCostReportOperationStatus.Definition(),
            new Query.Definition(),
            new UsageDetails.Definition(),
            new Views.Definition(),
        };
    }
}
