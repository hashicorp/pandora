// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Identity.StableV1.IdentityConditionalAccesPolicy;

internal class IdentityConditionalAccesPolicyId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/identity/conditionalAccess/policies/{conditionalAccessPolicyId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticIdentity", "identity"),
        ResourceIDSegment.Static("staticConditionalAccess", "conditionalAccess"),
        ResourceIDSegment.Static("staticPolicies", "policies"),
        ResourceIDSegment.UserSpecified("conditionalAccessPolicyId")
    };
}
