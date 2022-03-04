using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.HealthCareApis.v2021_06_01_preview.IotConnectors;

internal class Definition : ResourceDefinition
{
    public string Name => "IotConnectors";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new FhirDestinationsListByIotConnectorOperation(),
        new GetOperation(),
        new IotConnectorFhirDestinationCreateOrUpdateOperation(),
        new IotConnectorFhirDestinationDeleteOperation(),
        new IotConnectorFhirDestinationGetOperation(),
        new ListByWorkspaceOperation(),
        new UpdateOperation(),
    };
}
