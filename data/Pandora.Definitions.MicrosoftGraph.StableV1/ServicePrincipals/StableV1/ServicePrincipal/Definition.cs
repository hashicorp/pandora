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
        new AddServicePrincipalKeyOperation(),
        new AddServicePrincipalPasswordOperation(),
        new AddServicePrincipalTokenSigningCertificateOperation(),
        new CheckServicePrincipalMemberGroupsOperation(),
        new CheckServicePrincipalMemberObjectsOperation(),
        new CreateServicePrincipalOperation(),
        new DeleteServicePrincipalOperation(),
        new GetServicePrincipalAvailableExtensionPropertiesOperation(),
        new GetServicePrincipalByIdsOperation(),
        new GetServicePrincipalMemberGroupsOperation(),
        new GetServicePrincipalMemberObjectsOperation(),
        new GetServicePrincipalOperation(),
        new GetServicePrincipalsCountOperation(),
        new ListServicePrincipalsOperation(),
        new RemoveServicePrincipalKeyOperation(),
        new RemoveServicePrincipalPasswordOperation(),
        new RestoreServicePrincipalOperation(),
        new UpdateServicePrincipalOperation(),
        new ValidateServicePrincipalPropertiesOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AddServicePrincipalKeyRequestModel),
        typeof(AddServicePrincipalPasswordRequestModel),
        typeof(AddServicePrincipalTokenSigningCertificateRequestModel),
        typeof(CheckServicePrincipalMemberGroupsRequestModel),
        typeof(CheckServicePrincipalMemberObjectsRequestModel),
        typeof(GetServicePrincipalAvailableExtensionPropertiesRequestModel),
        typeof(GetServicePrincipalByIdsRequestModel),
        typeof(GetServicePrincipalMemberGroupsRequestModel),
        typeof(GetServicePrincipalMemberObjectsRequestModel),
        typeof(RemoveServicePrincipalKeyRequestModel),
        typeof(RemoveServicePrincipalPasswordRequestModel),
        typeof(ValidateServicePrincipalPropertiesRequestModel)
    };
}
