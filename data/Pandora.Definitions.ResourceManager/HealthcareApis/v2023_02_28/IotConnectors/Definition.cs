using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.HealthcareApis.v2023_02_28.IotConnectors;

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
