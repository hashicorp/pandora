using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Maintenance.v2022_07_01_preview.ApplyUpdates;

internal class ScopedApplyUpdateId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/{scope}/providers/Microsoft.Maintenance/applyUpdates/{applyUpdateName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Scope("scope"),
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftMaintenance", "Microsoft.Maintenance"),
        ResourceIDSegment.Static("staticApplyUpdates", "applyUpdates"),
        ResourceIDSegment.UserSpecified("applyUpdateName"),
    };
}
