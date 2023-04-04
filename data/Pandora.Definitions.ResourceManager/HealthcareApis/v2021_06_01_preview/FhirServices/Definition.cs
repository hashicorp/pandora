using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.HealthcareApis.v2021_06_01_preview.FhirServices;

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
        typeof(FhirServiceKindConstant),
        typeof(ManagedServiceIdentityTypeConstant),
        typeof(ProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(FhirServiceModel),
        typeof(FhirServiceAccessPolicyEntryModel),
        typeof(FhirServiceAcrConfigurationModel),
        typeof(FhirServiceAuthenticationConfigurationModel),
        typeof(FhirServiceCorsConfigurationModel),
        typeof(FhirServiceExportConfigurationModel),
        typeof(FhirServicePatchResourceModel),
        typeof(FhirServicePropertiesModel),
        typeof(ServiceManagedIdentityIdentityModel),
    };
}
