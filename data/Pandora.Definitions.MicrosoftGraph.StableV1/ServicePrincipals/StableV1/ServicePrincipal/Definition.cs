// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.ServicePrincipals.StableV1.ServicePrincipal;

internal class Definition : ResourceDefinition
{
    public string Name => "ServicePrincipal";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AddServicePrincipalByIdKeyOperation(),
        new AddServicePrincipalByIdPasswordOperation(),
        new AddServicePrincipalByIdTokenSigningCertificateOperation(),
        new CheckServicePrincipalByIdMemberGroupOperation(),
        new CheckServicePrincipalByIdMemberObjectOperation(),
        new CreateServicePrincipalOperation(),
        new DeleteServicePrincipalByIdOperation(),
        new GetServicePrincipalByIdMemberGroupOperation(),
        new GetServicePrincipalByIdMemberObjectOperation(),
        new GetServicePrincipalByIdOperation(),
        new GetServicePrincipalCountOperation(),
        new GetServicePrincipalsAvailableExtensionPropertiesOperation(),
        new GetServicePrincipalsByIdsOperation(),
        new ListServicePrincipalsOperation(),
        new RemoveServicePrincipalByIdKeyOperation(),
        new RemoveServicePrincipalByIdPasswordOperation(),
        new RestoreServicePrincipalByIdOperation(),
        new UpdateServicePrincipalByIdOperation(),
        new ValidateServicePrincipalsPropertyOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AddServicePrincipalByIdKeyRequestModel),
        typeof(AddServicePrincipalByIdPasswordRequestModel),
        typeof(AddServicePrincipalByIdTokenSigningCertificateRequestModel),
        typeof(CheckServicePrincipalByIdMemberGroupRequestModel),
        typeof(CheckServicePrincipalByIdMemberObjectRequestModel),
        typeof(GetServicePrincipalByIdMemberGroupRequestModel),
        typeof(GetServicePrincipalByIdMemberObjectRequestModel),
        typeof(GetServicePrincipalsAvailableExtensionPropertiesRequestModel),
        typeof(GetServicePrincipalsByIdsRequestModel),
        typeof(RemoveServicePrincipalByIdKeyRequestModel),
        typeof(RemoveServicePrincipalByIdPasswordRequestModel),
        typeof(ValidateServicePrincipalsPropertyRequestModel)
    };
}
