// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Applications.Beta.ApplicationHomeRealmDiscoveryPolicy;

internal class ApplicationIdHomeRealmDiscoveryPolicyId : ResourceID
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
