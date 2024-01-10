// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserInformationProtectionPolicyLabel;

internal class UserIdInformationProtectionPolicyLabelId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/users/{userId}/informationProtection/policy/labels/{informationProtectionLabelId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticUsers", "users"),
        ResourceIDSegment.UserSpecified("userId"),
        ResourceIDSegment.Static("staticInformationProtection", "informationProtection"),
        ResourceIDSegment.Static("staticPolicy", "policy"),
        ResourceIDSegment.Static("staticLabels", "labels"),
        ResourceIDSegment.UserSpecified("informationProtectionLabelId")
    };
}
