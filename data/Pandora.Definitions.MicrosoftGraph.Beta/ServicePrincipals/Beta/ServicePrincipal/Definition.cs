// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.ServicePrincipals.Beta.ServicePrincipal;

internal class Definition : ResourceDefinition
{
    public string Name => "ServicePrincipal";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AddServicePrincipalTokenSigningCertificateOperation(),
        new CheckServicePrincipalMemberGroupsOperation(),
        new CheckServicePrincipalMemberObjectsOperation(),
        new CreateServicePrincipalCreatePasswordSingleSignOnCredentialOperation(),
        new CreateServicePrincipalDeletePasswordSingleSignOnCredentialOperation(),
        new CreateServicePrincipalOperation(),
        new CreateServicePrincipalUpdatePasswordSingleSignOnCredentialOperation(),
        new DeleteServicePrincipalOperation(),
        new GetServicePrincipalByIdsOperation(),
        new GetServicePrincipalMemberGroupsOperation(),
        new GetServicePrincipalMemberObjectsOperation(),
        new GetServicePrincipalOperation(),
        new GetServicePrincipalPasswordSingleSignOnCredentialsOperation(),
        new GetServicePrincipalUserOwnedObjectsOperation(),
        new GetServicePrincipalsCountOperation(),
        new ListServicePrincipalsOperation(),
        new RestoreServicePrincipalOperation(),
        new UpdateServicePrincipalOperation(),
        new ValidateServicePrincipalPropertiesOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AddServicePrincipalTokenSigningCertificateRequestModel),
        typeof(CheckServicePrincipalMemberGroupsRequestModel),
        typeof(CheckServicePrincipalMemberObjectsRequestModel),
        typeof(CreateServicePrincipalCreatePasswordSingleSignOnCredentialRequestModel),
        typeof(CreateServicePrincipalDeletePasswordSingleSignOnCredentialRequestModel),
        typeof(CreateServicePrincipalUpdatePasswordSingleSignOnCredentialRequestModel),
        typeof(GetServicePrincipalByIdsRequestModel),
        typeof(GetServicePrincipalMemberGroupsRequestModel),
        typeof(GetServicePrincipalMemberObjectsRequestModel),
        typeof(GetServicePrincipalPasswordSingleSignOnCredentialsRequestModel),
        typeof(GetServicePrincipalUserOwnedObjectsRequestModel),
        typeof(ValidateServicePrincipalPropertiesRequestModel)
    };
}
