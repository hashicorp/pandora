// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserInformationProtectionDataLossPreventionPolicy;

internal class UserIdInformationProtectionDataLossPreventionPolicyId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/users/{userId}/informationProtection/dataLossPreventionPolicies/{dataLossPreventionPolicyId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticUsers", "users"),
        ResourceIDSegment.UserSpecified("userId"),
        ResourceIDSegment.Static("staticInformationProtection", "informationProtection"),
        ResourceIDSegment.Static("staticDataLossPreventionPolicies", "dataLossPreventionPolicies"),
        ResourceIDSegment.UserSpecified("dataLossPreventionPolicyId")
    };
}
