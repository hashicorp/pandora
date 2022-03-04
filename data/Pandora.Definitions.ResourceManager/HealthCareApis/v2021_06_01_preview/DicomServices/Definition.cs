using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.HealthCareApis.v2021_06_01_preview.DicomServices;

internal class Definition : ResourceDefinition
{
    public string Name => "DicomServices";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByWorkspaceOperation(),
        new UpdateOperation(),
    };
}
