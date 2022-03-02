using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ConfidentialLedger.v2021_05_13_preview.NameAvailability;

internal class Definition : ResourceDefinition
{
    public string Name => "NameAvailability";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CheckNameAvailabilityOperation(),
    };
}
