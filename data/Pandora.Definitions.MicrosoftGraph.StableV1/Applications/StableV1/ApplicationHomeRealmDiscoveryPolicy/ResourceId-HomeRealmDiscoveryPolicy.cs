// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Applications.StableV1.ApplicationHomeRealmDiscoveryPolicy;

internal class HomeRealmDiscoveryPolicyId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/applications/{applicationId}/homeRealmDiscoveryPolicies/{homeRealmDiscoveryPolicyId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticApplications", "applications"),
        ResourceIDSegment.UserSpecified("applicationId"),
        ResourceIDSegment.Static("staticHomeRealmDiscoveryPolicies", "homeRealmDiscoveryPolicies"),
        ResourceIDSegment.UserSpecified("homeRealmDiscoveryPolicyId")
    };
}
