// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Groups.StableV1.GroupSetting;

internal class GroupIdSettingId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/groups/{groupId}/settings/{groupSettingId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticGroups", "groups"),
        ResourceIDSegment.UserSpecified("groupId"),
        ResourceIDSegment.Static("staticSettings", "settings"),
        ResourceIDSegment.UserSpecified("groupSettingId")
    };
}
