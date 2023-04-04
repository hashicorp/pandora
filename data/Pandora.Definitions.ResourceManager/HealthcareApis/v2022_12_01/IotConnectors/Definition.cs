using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.HealthcareApis.v2022_12_01.IotConnectors;

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
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(IotIdentityResolutionTypeConstant),
        typeof(ProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(IotConnectorModel),
        typeof(IotConnectorPatchResourceModel),
        typeof(IotConnectorPropertiesModel),
        typeof(IotEventHubIngestionEndpointConfigurationModel),
        typeof(IotFhirDestinationModel),
        typeof(IotFhirDestinationPropertiesModel),
        typeof(IotMappingPropertiesModel),
    };
}
