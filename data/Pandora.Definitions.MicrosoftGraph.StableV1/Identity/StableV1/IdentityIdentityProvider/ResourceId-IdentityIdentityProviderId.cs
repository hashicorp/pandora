// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Identity.StableV1.IdentityIdentityProvider;

internal class IdentityIdentityProviderId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/identity/identityProviders/{identityProviderBaseId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticIdentity", "identity"),
        ResourceIDSegment.Static("staticIdentityProviders", "identityProviders"),
        ResourceIDSegment.UserSpecified("identityProviderBaseId")
    };
}
