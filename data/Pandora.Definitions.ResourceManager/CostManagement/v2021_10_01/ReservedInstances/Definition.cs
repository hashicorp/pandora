using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2021_10_01.ReservedInstances;

internal class Definition : ResourceDefinition
{
    public string Name => "ReservedInstances";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GenerateReservationDetailsReportByBillingAccountIdOperation(),
        new GenerateReservationDetailsReportByBillingProfileIdOperation(),
    };
}
