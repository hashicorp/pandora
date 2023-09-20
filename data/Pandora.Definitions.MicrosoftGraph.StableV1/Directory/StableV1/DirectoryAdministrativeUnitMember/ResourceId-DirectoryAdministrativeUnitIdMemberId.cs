// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Directory.StableV1.DirectoryAdministrativeUnitMember;

internal class DirectoryAdministrativeUnitIdMemberId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/directory/administrativeUnits/{administrativeUnitId}/members/{directoryObjectId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticDirectory", "directory"),
        ResourceIDSegment.Static("staticAdministrativeUnits", "administrativeUnits"),
        ResourceIDSegment.UserSpecified("administrativeUnitId"),
        ResourceIDSegment.Static("staticMembers", "members"),
        ResourceIDSegment.UserSpecified("directoryObjectId")
    };
}
