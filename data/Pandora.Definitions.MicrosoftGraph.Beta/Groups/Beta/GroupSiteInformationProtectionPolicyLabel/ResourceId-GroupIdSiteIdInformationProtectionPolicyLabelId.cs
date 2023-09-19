// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupSiteInformationProtectionPolicyLabel;

internal class GroupIdSiteIdInformationProtectionPolicyLabelId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/groups/{groupId}/sites/{siteId}/informationProtection/policy/labels/{informationProtectionLabelId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticGroups", "groups"),
        ResourceIDSegment.UserSpecified("groupId"),
        ResourceIDSegment.Static("staticSites", "sites"),
        ResourceIDSegment.UserSpecified("siteId"),
        ResourceIDSegment.Static("staticInformationProtection", "informationProtection"),
        ResourceIDSegment.Static("staticPolicy", "policy"),
        ResourceIDSegment.Static("staticLabels", "labels"),
        ResourceIDSegment.UserSpecified("informationProtectionLabelId")
    };
}
