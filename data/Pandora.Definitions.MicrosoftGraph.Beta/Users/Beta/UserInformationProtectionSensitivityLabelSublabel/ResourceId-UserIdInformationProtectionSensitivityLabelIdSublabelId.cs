// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserInformationProtectionSensitivityLabelSublabel;

internal class UserIdInformationProtectionSensitivityLabelIdSublabelId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/users/{userId}/informationProtection/sensitivityLabels/{sensitivityLabelId}/sublabels/{sensitivityLabelId1}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticUsers", "users"),
        ResourceIDSegment.UserSpecified("userId"),
        ResourceIDSegment.Static("staticInformationProtection", "informationProtection"),
        ResourceIDSegment.Static("staticSensitivityLabels", "sensitivityLabels"),
        ResourceIDSegment.UserSpecified("sensitivityLabelId"),
        ResourceIDSegment.Static("staticSublabels", "sublabels"),
        ResourceIDSegment.UserSpecified("sensitivityLabelId1")
    };
}
