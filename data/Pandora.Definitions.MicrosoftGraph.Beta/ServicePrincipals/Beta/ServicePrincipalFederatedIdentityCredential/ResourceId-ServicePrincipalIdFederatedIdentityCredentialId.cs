// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.ServicePrincipals.Beta.ServicePrincipalFederatedIdentityCredential;

internal class ServicePrincipalIdFederatedIdentityCredentialId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/servicePrincipals/{servicePrincipalId}/federatedIdentityCredentials/{federatedIdentityCredentialId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticServicePrincipals", "servicePrincipals"),
        ResourceIDSegment.UserSpecified("servicePrincipalId"),
        ResourceIDSegment.Static("staticFederatedIdentityCredentials", "federatedIdentityCredentials"),
        ResourceIDSegment.UserSpecified("federatedIdentityCredentialId")
    };
}
