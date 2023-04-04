using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.HealthcareApis.v2023_02_28.FhirServices;

internal class Definition : ResourceDefinition
{
    public string Name => "FhirServices";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByWorkspaceOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(FhirResourceVersionPolicyConstant),
        typeof(FhirServiceKindConstant),
        typeof(PrivateEndpointConnectionProvisioningStateConstant),
        typeof(PrivateEndpointServiceConnectionStatusConstant),
        typeof(ProvisioningStateConstant),
        typeof(PublicNetworkAccessConstant),
        typeof(ServiceEventStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(FhirServiceModel),
        typeof(FhirServiceAccessPolicyEntryModel),
        typeof(FhirServiceAcrConfigurationModel),
        typeof(FhirServiceAuthenticationConfigurationModel),
        typeof(FhirServiceCorsConfigurationModel),
        typeof(FhirServiceExportConfigurationModel),
        typeof(FhirServiceImportConfigurationModel),
        typeof(FhirServicePatchResourceModel),
        typeof(FhirServicePropertiesModel),
        typeof(ImplementationGuidesConfigurationModel),
        typeof(PrivateEndpointModel),
        typeof(PrivateEndpointConnectionModel),
        typeof(PrivateEndpointConnectionPropertiesModel),
        typeof(PrivateLinkServiceConnectionStateModel),
        typeof(ResourceVersionPolicyConfigurationModel),
        typeof(ServiceOciArtifactEntryModel),
    };
}
