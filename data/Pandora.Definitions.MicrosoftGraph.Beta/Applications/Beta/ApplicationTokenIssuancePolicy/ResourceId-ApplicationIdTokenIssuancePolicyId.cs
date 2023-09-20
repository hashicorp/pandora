// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Applications.Beta.ApplicationTokenIssuancePolicy;

internal class ApplicationIdTokenIssuancePolicyId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/applications/{applicationId}/tokenIssuancePolicies/{tokenIssuancePolicyId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticApplications", "applications"),
        ResourceIDSegment.UserSpecified("applicationId"),
        ResourceIDSegment.Static("staticTokenIssuancePolicies", "tokenIssuancePolicies"),
        ResourceIDSegment.UserSpecified("tokenIssuancePolicyId")
    };
}
