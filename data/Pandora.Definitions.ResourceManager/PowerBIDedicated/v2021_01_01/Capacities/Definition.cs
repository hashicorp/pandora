using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.PowerBIDedicated.v2021_01_01.Capacities;

internal class Definition : ResourceDefinition
{
    public string Name => "Capacities";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CheckNameAvailabilityOperation(),
        new CreateOperation(),
        new DeleteOperation(),
        new GetDetailsOperation(),
        new ListOperation(),
        new ListByResourceGroupOperation(),
        new ListSkusForCapacityOperation(),
        new ResumeOperation(),
        new SuspendOperation(),
        new UpdateOperation(),
    };
}
