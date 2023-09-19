// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.AdministrativeUnits.Beta.AdministrativeUnit;

internal class AdministrativeUnitId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/administrativeUnits/{administrativeUnitId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticAdministrativeUnits", "administrativeUnits"),
        ResourceIDSegment.UserSpecified("administrativeUnitId")
    };
}
