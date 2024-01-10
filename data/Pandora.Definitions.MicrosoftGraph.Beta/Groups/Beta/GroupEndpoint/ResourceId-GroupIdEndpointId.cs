// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupEndpoint;

internal class GroupIdEndpointId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/groups/{groupId}/endpoints/{endpointId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticGroups", "groups"),
        ResourceIDSegment.UserSpecified("groupId"),
        ResourceIDSegment.Static("staticEndpoints", "endpoints"),
        ResourceIDSegment.UserSpecified("endpointId")
    };
}
