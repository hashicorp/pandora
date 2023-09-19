// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Directory.Beta.DirectoryAdministrativeUnitExtension;

internal class DirectoryAdministrativeUnitIdExtensionId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/directory/administrativeUnits/{administrativeUnitId}/extensions/{extensionId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticDirectory", "directory"),
        ResourceIDSegment.Static("staticAdministrativeUnits", "administrativeUnits"),
        ResourceIDSegment.UserSpecified("administrativeUnitId"),
        ResourceIDSegment.Static("staticExtensions", "extensions"),
        ResourceIDSegment.UserSpecified("extensionId")
    };
}
