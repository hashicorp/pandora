using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.IntegrationServiceEnvironmentManagedApis;

internal class Definition : ResourceDefinition
{
    public string Name => "IntegrationServiceEnvironmentManagedApis";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new IntegrationServiceEnvironmentManagedApiOperationsListOperation(),
        new ListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ApiDeploymentParameterVisibilityConstant),
        typeof(ApiTierConstant),
        typeof(ApiTypeConstant),
        typeof(StatusAnnotationConstant),
        typeof(SwaggerSchemaTypeConstant),
        typeof(WorkflowProvisioningStateConstant),
        typeof(WsdlImportMethodConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ApiDeploymentParameterMetadataModel),
        typeof(ApiDeploymentParameterMetadataSetModel),
        typeof(ApiOperationModel),
        typeof(ApiOperationAnnotationModel),
        typeof(ApiOperationPropertiesDefinitionModel),
        typeof(ApiReferenceModel),
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
        typeof(SwaggerCustomDynamicListModel),
        typeof(SwaggerCustomDynamicPropertiesModel),
        typeof(SwaggerCustomDynamicSchemaModel),
        typeof(SwaggerCustomDynamicTreeModel),
        typeof(SwaggerCustomDynamicTreeCommandModel),
        typeof(SwaggerCustomDynamicTreeParameterModel),
        typeof(SwaggerCustomDynamicTreeSettingsModel),
        typeof(SwaggerExternalDocumentationModel),
        typeof(SwaggerSchemaModel),
        typeof(SwaggerXmlModel),
        typeof(WsdlServiceModel),
    };
}
