// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupSiteInformationProtectionSensitivityLabelSublabel;

internal class GroupIdSiteIdInformationProtectionSensitivityLabelIdSublabelId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/groups/{groupId}/sites/{siteId}/informationProtection/sensitivityLabels/{sensitivityLabelId}/sublabels/{sensitivityLabelId1}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticGroups", "groups"),
        ResourceIDSegment.UserSpecified("groupId"),
        ResourceIDSegment.Static("staticSites", "sites"),
        ResourceIDSegment.UserSpecified("siteId"),
        ResourceIDSegment.Static("staticInformationProtection", "informationProtection"),
        ResourceIDSegment.Static("staticSensitivityLabels", "sensitivityLabels"),
        ResourceIDSegment.UserSpecified("sensitivityLabelId"),
        ResourceIDSegment.Static("staticSublabels", "sublabels"),
        ResourceIDSegment.UserSpecified("sensitivityLabelId1")
    };
}
