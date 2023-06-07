using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Attestation.v2021_06_01.AttestationProviders;

internal class Definition : ResourceDefinition
{
    public string Name => "AttestationProviders";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new GetDefaultByLocationOperation(),
        new ListOperation(),
        new ListByResourceGroupOperation(),
        new ListDefaultOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AttestationServiceStatusConstant),
        typeof(PrivateEndpointConnectionProvisioningStateConstant),
        typeof(PrivateEndpointServiceConnectionStatusConstant),
        typeof(PublicNetworkAccessTypeConstant),
        typeof(TpmAttestationAuthenticationTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AttestationProviderListResultModel),
        typeof(AttestationProvidersModel),
        typeof(AttestationServiceCreationParamsModel),
        typeof(AttestationServiceCreationSpecificParamsModel),
        typeof(AttestationServicePatchParamsModel),
        typeof(AttestationServicePatchSpecificParamsModel),
        typeof(JsonWebKeyModel),
        typeof(JsonWebKeySetModel),
        typeof(PrivateEndpointModel),
        typeof(PrivateEndpointConnectionModel),
        typeof(PrivateEndpointConnectionPropertiesModel),
        typeof(PrivateLinkServiceConnectionStateModel),
        typeof(StatusResultModel),
    };
}
