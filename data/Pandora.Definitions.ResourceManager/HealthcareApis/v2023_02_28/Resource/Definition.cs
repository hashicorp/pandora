using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.HealthcareApis.v2023_02_28.Resource;

internal class Definition : ResourceDefinition
{
    public string Name => "Resource";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ServicesCreateOrUpdateOperation(),
        new ServicesDeleteOperation(),
        new ServicesGetOperation(),
        new ServicesUpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(KindConstant),
        typeof(PrivateEndpointConnectionProvisioningStateConstant),
        typeof(PrivateEndpointServiceConnectionStatusConstant),
        typeof(ProvisioningStateConstant),
        typeof(PublicNetworkAccessConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(PrivateEndpointModel),
        typeof(PrivateEndpointConnectionModel),
        typeof(PrivateEndpointConnectionPropertiesModel),
        typeof(PrivateLinkServiceConnectionStateModel),
        typeof(ServiceAccessPolicyEntryModel),
        typeof(ServiceAcrConfigurationInfoModel),
        typeof(ServiceAuthenticationConfigurationInfoModel),
        typeof(ServiceCorsConfigurationInfoModel),
        typeof(ServiceCosmosDbConfigurationInfoModel),
        typeof(ServiceExportConfigurationInfoModel),
        typeof(ServiceImportConfigurationInfoModel),
        typeof(ServiceOciArtifactEntryModel),
        typeof(ServicesDescriptionModel),
        typeof(ServicesPatchDescriptionModel),
        typeof(ServicesPropertiesModel),
        typeof(ServicesPropertiesUpdateParametersModel),
    };
}
