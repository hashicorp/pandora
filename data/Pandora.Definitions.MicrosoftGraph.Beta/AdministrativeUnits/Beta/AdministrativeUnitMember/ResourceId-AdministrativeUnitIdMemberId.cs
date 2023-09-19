// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.AdministrativeUnits.Beta.AdministrativeUnitMember;

internal class AdministrativeUnitIdMemberId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/administrativeUnits/{administrativeUnitId}/members/{directoryObjectId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticAdministrativeUnits", "administrativeUnits"),
        ResourceIDSegment.UserSpecified("administrativeUnitId"),
        ResourceIDSegment.Static("staticMembers", "members"),
        ResourceIDSegment.UserSpecified("directoryObjectId")
    };
}
