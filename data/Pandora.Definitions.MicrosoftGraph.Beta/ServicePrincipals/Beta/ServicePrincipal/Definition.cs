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
        new AddServicePrincipalByIdTokenSigningCertificateOperation(),
        new CheckServicePrincipalByIdMemberGroupOperation(),
        new CheckServicePrincipalByIdMemberObjectOperation(),
        new CreateServicePrincipalByIdCreatePasswordSingleSignOnCredentialOperation(),
        new CreateServicePrincipalByIdDeletePasswordSingleSignOnCredentialOperation(),
        new CreateServicePrincipalOperation(),
        new DeleteServicePrincipalByIdOperation(),
        new GetServicePrincipalByIdMemberGroupOperation(),
        new GetServicePrincipalByIdMemberObjectOperation(),
        new GetServicePrincipalByIdOperation(),
        new GetServicePrincipalByIdPasswordSingleSignOnCredentialOperation(),
        new GetServicePrincipalCountOperation(),
        new GetServicePrincipalsByIdsOperation(),
        new GetServicePrincipalsUserOwnedObjectOperation(),
        new ListServicePrincipalsOperation(),
        new RestoreServicePrincipalByIdOperation(),
        new UpdateServicePrincipalByIdOperation(),
        new UpdateServicePrincipalByIdPasswordSingleSignOnCredentialOperation(),
        new ValidateServicePrincipalsPropertyOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AddServicePrincipalByIdTokenSigningCertificateRequestModel),
        typeof(CheckServicePrincipalByIdMemberGroupRequestModel),
        typeof(CheckServicePrincipalByIdMemberObjectRequestModel),
        typeof(CreateServicePrincipalByIdCreatePasswordSingleSignOnCredentialRequestModel),
        typeof(CreateServicePrincipalByIdDeletePasswordSingleSignOnCredentialRequestModel),
        typeof(GetServicePrincipalByIdMemberGroupRequestModel),
        typeof(GetServicePrincipalByIdMemberObjectRequestModel),
        typeof(GetServicePrincipalByIdPasswordSingleSignOnCredentialRequestModel),
        typeof(GetServicePrincipalsByIdsRequestModel),
        typeof(GetServicePrincipalsUserOwnedObjectRequestModel),
        typeof(UpdateServicePrincipalByIdPasswordSingleSignOnCredentialRequestModel),
        typeof(ValidateServicePrincipalsPropertyRequestModel)
    };
}
