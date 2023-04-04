using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.IntegrationServiceEnvironments;

internal class Definition : ResourceDefinition
{
    public string Name => "IntegrationServiceEnvironments";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(IntegrationServiceEnvironmentAccessEndpointTypeConstant),
        typeof(IntegrationServiceEnvironmentSkuNameConstant),
        typeof(WorkflowProvisioningStateConstant),
        typeof(WorkflowStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(FlowEndpointsModel),
        typeof(FlowEndpointsConfigurationModel),
        typeof(IPAddressModel),
        typeof(IntegrationServiceEnvironmenEncryptionConfigurationModel),
        typeof(IntegrationServiceEnvironmenEncryptionKeyReferenceModel),
        typeof(IntegrationServiceEnvironmentModel),
        typeof(IntegrationServiceEnvironmentAccessEndpointModel),
        typeof(IntegrationServiceEnvironmentPropertiesModel),
        typeof(IntegrationServiceEnvironmentSkuModel),
        typeof(NetworkConfigurationModel),
        typeof(ResourceReferenceModel),
    };
}
