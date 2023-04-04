using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.IntegrationServiceEnvironmentManagedApi;

internal class Definition : ResourceDefinition
{
    public string Name => "IntegrationServiceEnvironmentManagedApi";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new DeleteOperation(),
        new GetOperation(),
        new PutOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ApiDeploymentParameterVisibilityConstant),
        typeof(ApiTierConstant),
        typeof(ApiTypeConstant),
        typeof(WorkflowProvisioningStateConstant),
        typeof(WsdlImportMethodConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ApiDeploymentParameterMetadataModel),
        typeof(ApiDeploymentParameterMetadataSetModel),
        typeof(ApiResourceBackendServiceModel),
        typeof(ApiResourceDefinitionsModel),
        typeof(ApiResourceGeneralInformationModel),
        typeof(ApiResourceMetadataModel),
        typeof(ApiResourcePoliciesModel),
        typeof(ContentHashModel),
        typeof(ContentLinkModel),
        typeof(IntegrationServiceEnvironmentManagedApiModel),
        typeof(IntegrationServiceEnvironmentManagedApiDeploymentParametersModel),
        typeof(IntegrationServiceEnvironmentManagedApiPropertiesModel),
        typeof(ResourceReferenceModel),
        typeof(WsdlServiceModel),
    };
}
