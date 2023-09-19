// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.ServicePrincipals.StableV1.ServicePrincipalFederatedIdentityCredential;

internal class Definition : ResourceDefinition
{
    public string Name => "ServicePrincipalFederatedIdentityCredential";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateServicePrincipalByIdFederatedIdentityCredentialOperation(),
        new DeleteServicePrincipalByIdFederatedIdentityCredentialByIdOperation(),
        new GetServicePrincipalByIdFederatedIdentityCredentialByIdOperation(),
        new GetServicePrincipalByIdFederatedIdentityCredentialCountOperation(),
        new ListServicePrincipalByIdFederatedIdentityCredentialsOperation(),
        new UpdateServicePrincipalByIdFederatedIdentityCredentialByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
